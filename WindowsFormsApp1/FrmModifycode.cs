using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Test
{
    public partial class FrmModifycode : Form
    {
        public FrmModifycode()
        {
            InitializeComponent();
            this.dbContext.Database.Log = Console.WriteLine;
        }
        MyDBEntities dbContext = new MyDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var word = (from w in this.dbContext.Members.AsEnumerable()
                        where w.Account.Contains($"{this.textBox1.Text}")
                        select w).FirstOrDefault();
            if (word == null) return;
            if (textBox2.Text== textBox3.Text && IsCorrectPW(textBox3.Text))
            {
                word.Password = textBox2.Text;
                this.dbContext.SaveChanges();
                MessageBox.Show("修改成功");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("修改的密碼與確認的密碼不一致");
            }
            else
            {
                MessageBox.Show("密碼格式不符");
            }


        }
        bool IsCorrectPW(string account)
        {
            return Regex.IsMatch(account, @"^[A-Za-z0-9].{8,16}$");
        }

    }
}
