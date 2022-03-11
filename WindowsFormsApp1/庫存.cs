using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class 庫存 : Form
    {
        public 庫存()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();

        private void button2_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                var q = from w in dbContext.Products.AsEnumerable()
                        where w.ProductID == int.Parse(this.textBox1.Text)
                        select w;
                foreach (var w in q)
                {
                    w.UnitsinStock = int.Parse(this.textBox2.Text);
                }
                this.dbContext.SaveChanges();
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = (from w in dbContext.Products.AsEnumerable()
                                                 where w.ProductID == int.Parse(this.textBox1.Text)
                                                 select new
                                                 {
                                                     產品編號=w.ProductID,
                                                     產品名稱 = w.ProductInfo.ProductName,
                                                     尺寸 = w.Size.SizeName,
                                                     顏色 = w.Color.ColorName,
                                                     庫存 = w.UnitsinStock
                                                 }).ToList();
                MessageBox.Show("庫存修改成功!");
            }
            else
            {
                MessageBox.Show("請想一下你忘了甚麼");
            }
        }
        private void 庫存_Load(object sender, EventArgs e)
        {
            var q = from w in dbContext.Products
                        //group w.ProductInfo.ProductName by w.UnitsinStock into g
                    select new
                    {
                        產品編號 = w.ProductID,
                        產品名稱 = w.ProductInfo.ProductName,
                        尺寸 = w.Size.SizeName,
                        顏色 = w.Color.ColorName,
                        庫存 = w.UnitsinStock
                    };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                var q = from w in dbContext.Products.AsEnumerable()
                        where w.ProductID == int.Parse(this.textBox1.Text)
                        select new
                        {
                            產品編號 = w.ProductID,
                            產品名稱 = w.ProductInfo.ProductName,
                            尺寸 = w.Size.SizeName,
                            顏色 = w.Color.ColorName,
                            庫存 = w.UnitsinStock
                        };
                this.dataGridView1.DataSource = q.ToList();
            }
            else
            {
                var z = from x in dbContext.Products.AsEnumerable()
                        select new
                        {
                            產品編號 = x.ProductID,
                            產品名稱 = x.ProductInfo.ProductName,
                            尺寸 = x.Size.SizeName,
                            顏色 = x.Color.ColorName,
                            庫存 = x.UnitsinStock
                        };
                this.dataGridView1.DataSource = z.ToList();
            }
        }
    }
}
