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

namespace Report
{
    public partial class Frm_View : Form
    {
        public Frm_View()
        {
            InitializeComponent();
            Box_ID.Text = CurrentLogin.ID.ToString();

        }

        MyDBEntities myDB = new MyDBEntities();

        private void Btn_CheckHist_Click(object sender, EventArgs e)
        {
            var q = from h in myDB.Orders.AsEnumerable()
                    where h.MemberID == int.Parse(this.Box_ID.Text)
                    select new { h.OrderID, h.OrderDate, h.OrderStatu.StatusName };

            this.dataGridView1.DataSource = q.ToList();
            this.Lab_Count.Text = "總共: " + this.dataGridView1.Rows.Count + "筆訂單";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var q2 = from d in myDB.OrderDetails.AsEnumerable()
                     where d.OrderID == (int)this.dataGridView1.CurrentRow.Cells[0].Value
                     select new { d.OrderID, d.Product.ProductInfo.ProductName, d.Quantity, d.SalesPrice, Amount = d.Quantity*d.SalesPrice };
            this.dataGridView2.DataSource = q2.ToList();
            //-------------------------------------
            decimal amg = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                amg += (decimal)dataGridView2.Rows[i].Cells[4].Value;
            }
            this.Lab_Sum.Text = "訂單編號" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString() + " 的金額為 $" + $"{amg:C2}".ToString();
        }
    }
}
