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
    public partial class 訂單狀態 : Form
    {
        public 訂單狀態()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                var q = from w in dbContext.Orders.AsEnumerable()
                        where w.OrderID == int.Parse(this.textBox1.Text)
                        select new
                        {
                            OrderID= w.OrderID,
                            StatusID = w.OrderStatu.StatusID,
                            StatusName = w.OrderStatu.StatusName
                        };

                    
                this.dataGridView1.DataSource = q.ToList();
            }
            else
            {
                var q = from w in dbContext.Orders.AsEnumerable()
                        select new
                        {
                            訂單編號=w.OrderID,
                            會員編號=w.MemberID,
                            員工編號=w.EmployeeID,
                            狀態編號=w.StatusID,
                            運送方式=w.ShippingID,
                            訂單日期=w.OrderDate,
                            抵達日期=w.ArrivedDate
                        };
                this.dataGridView1.DataSource = q.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                var q = from w in dbContext.Orders.AsEnumerable()
                        where w.OrderID == int.Parse(this.textBox1.Text)
                        select w;
                foreach (var w in q)
                {
                    w.StatusID = int.Parse(this.textBox2.Text);
                }
                this.dbContext.SaveChanges();
                MessageBox.Show("更新成功");
                var q1 = from w in dbContext.Orders.AsEnumerable()
                         where w.OrderID == int.Parse(this.textBox1.Text)
                         select new
                         {
                             OrderID = w.OrderID,
                             StatusID=w.OrderStatu.StatusID,
                             StatusName = w.OrderStatu.StatusName
                         };
                this.dataGridView1.DataSource = q1.ToList();
            }
            else
            {
                MessageBox.Show("你又忘了甚麼");
            }


        }

        private void 訂單狀態_Load(object sender, EventArgs e)
        {
            var q = from w in dbContext.Orders
                    select new
                    {
                        訂單編號 = w.OrderID,
                        會員編號 = w.MemberID,
                        員工編號 = w.EmployeeID,
                        狀態編號 = w.StatusID,
                        運送方式 = w.ShippingID,
                        訂單日期 = w.OrderDate,
                        抵達日期 = w.ArrivedDate
                    };
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
