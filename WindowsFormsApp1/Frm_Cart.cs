using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using System.IO;

namespace MidTermReport
{
    public partial class Frm_Cart : Form
    {
        public Frm_Cart()
        {
            InitializeComponent();
            MyDBEntities MyDB = new MyDBEntities();
            var q = from i in MyDB.Products
                    where i.UnitsinStock > 0
                    select new
                    {
                        商品編號 = i.ProductID,
                        商品 = i.ProductInfo.ProductName,
                        顏色 = i.Color.ColorName,
                        尺寸 = i.Size.SizeName,
                        單價 = i.ProductInfo.UnitPrice
                    };
            this.dataGridView1.DataSource = q.ToList();
            ClearCart();
            Box_ID.Text = CurrentLogin.ID.ToString();
        }

        MyDBEntities MyDB = new MyDBEntities();
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                int PdID = ((int)dataGridView2.CurrentRow.Cells[0].Value);
                var q3 = (from c in MyDB.Carts
                          where c.ProductID == PdID
                          select c).SingleOrDefault();
                this.MyDB.Carts.Remove(q3);
                this.MyDB.SaveChanges();
                RefreshCart();
            }
            else
            {
                MessageBox.Show("購物車內無已選商品");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItems();
            RefreshCart();
        }

        private void RefreshCart()
        {
            var q2 = from i in MyDB.Carts
                     //group i by i.ProductID into g
                     select new
                     {
                         商品編號 = i.ProductID,
                         商品 = i.Product.ProductInfo.ProductName,
                         顏色 = i.Product.Color.ColorName,
                         尺寸 = i.Product.Size.SizeName,
                         單價 = i.SalesPrice,
                         數量 = i.Quantity,
                         總價 = (i.SalesPrice*i.Quantity),
                     };
            this.dataGridView2.DataSource = q2.ToList();

            decimal amg = 0;
            for (int i =0; i < this.dataGridView2.Rows.Count; i++)
            {
                amg += (decimal)this.dataGridView2.Rows[i].Cells[6].Value;
            }
            this.Lab_sum.Text = "總金額為 $" + $"{decimal.Round(amg, 2).ToString():c2}";
        }

        private void AddItems()
        {
            int PdID = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
            string PdName = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string Col = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string Size = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            decimal UPrice = (decimal)this.dataGridView1.CurrentRow.Cells[4].Value;
            decimal Qty = this.Num_Qty.Value;

            //Duplicated
            bool Dup = false;
            for (int i = 0; i < this.dataGridView2.RowCount; i++)
            {
                Dup = ((int)this.dataGridView2.Rows[i].Cells[0].Value == PdID);
            }

            if (Dup)
            {
                var q = this.MyDB.Carts.Where(c => c.ProductID == PdID).Select(c => c);
                foreach (var c in q)
                {
                    c.Quantity += (int)this.Num_Qty.Value;
                }
                this.MyDB.SaveChanges();
                this.Num_Qty.Value = 0;
            }

            else
            {
                Cart Ct = new Cart
                {
                    MemberID = int.Parse(this.Box_ID.Text),
                    ProductID = PdID,
                    SalesPrice = UPrice,
                    Quantity = (int)Qty,
                };
                this.MyDB.Carts.Add(Ct);
                this.MyDB.SaveChanges();
                this.Num_Qty.Value = 0;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ClearCart();
            RefreshCart();
        }

        private void ClearCart()
        {
            var C = this.MyDB.Carts.ToList();
            if (C == null) 
            {
                return;
            }
            this.MyDB.Carts.RemoveRange(C);
            this.MyDB.SaveChanges();
        }

        //todone 繫節圖片
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var q = from p in MyDB.Products.AsEnumerable()
                    where p.ProductID == ((int)this.dataGridView1.CurrentRow.Cells[0].Value)
                    select p.ProductInfo.ProductPhoto;
            foreach (var p in q)
            {
                MemoryStream ms = new MemoryStream(p);
                this.pictureBox1.Image = Image.FromStream(ms);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否送出訂單?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //todo status & shipping 選擇
                Order Odr = new Order
                {
                    MemberID = int.Parse(this.Box_ID.Text),
                    OrderDate = DateTime.Now,
                    StatusID = 1,
                    ShippingID = 1,
                };
                this.MyDB.Orders.Add(Odr);
                this.MyDB.SaveChanges();

                //var q = from d in MyDB.Orders.AsEnumerable()
                //        where d.OrderID == Odr.OrderID
                //        select d;

                //foreach (var i in q)
                //{
                //    try
                //    {
                //        OrderDetail Od = new OrderDetail
                //        {
                //            OrderID = i.OrderID,
                //            ProductID = i.
                //            Quantity = 0,
                //            SalesPrice = 0,
                //        };
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}
                ClearCart();
                RefreshCart();

                MessageBox.Show("訂單已成立");
            }
        }
    }
}
