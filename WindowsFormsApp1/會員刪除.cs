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
    public partial class 會員刪除 : Form
    {
        public 會員刪除()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            string d = "";

            var q = (from w in dbContext.Members.AsEnumerable()
                    where w.MemberID == int.Parse(this.textBox1.Text)
                    select w).FirstOrDefault();
            var q1 = from w in dbContext.Members.AsEnumerable()
                     where w.MemberID == int.Parse(this.textBox1.Text)
                     select w;
            foreach(var a in q1)
            {
                s = a.Account;
            }
            foreach(var b in q1)
            {
                d = b.Password;
            }
            DialogResult result = MessageBox.Show("請確認是否刪除 帳號:"+s+",密碼:"+d+"的會員資料", "刪除視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.dbContext.Members.Remove(q);
                this.dbContext.SaveChanges();
                MessageBox.Show("刪除成功");
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
