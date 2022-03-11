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

namespace 專題
{
    public partial class 編輯員工職位 : Form
    {
        public 編輯員工職位()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();

        //新增員工職位
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Position position = new Position
                {
                    PositionName = txtPositionName.Text
                };
                this.dbContext.Positions.Add(position);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("請輸入完整資料");
            }
        }

        //修改員工職位
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var pos = (from f in this.dbContext.Positions.AsEnumerable()
                           where f.PositionID == int.Parse(this.txtPositionID.Text)
                           select f).FirstOrDefault();
                pos.PositionName = txtPositionName.Text;
                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("請輸入完整資料");
            }
        }

        //刪除員工職位
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var pos = (from f in this.dbContext.Positions.AsEnumerable()
                           where f.PositionID == int.Parse(this.txtPositionID.Text)
                           select f).FirstOrDefault();
                this.dbContext.Positions.Remove(pos);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("請輸入完整資料");
            }
        }
    }
}
