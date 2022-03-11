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
    public partial class 會員管理 : Form
    {
        public 會員管理()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();
        //private void 會員管理(object sender, EventArgs e)
        //{
        //    var q = from w in dbContext.Members
        //            select w;
        //    this.dataGridView1.DataSource = q.ToList();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            var a = from s in dbContext.Members
                    where s.Account == this.textBox1.Text
                    select s;
            string Act = "";
            foreach (var z in a)
            {
                Act = z.Account;
            }
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                if (this.textBox1.Text != Act)
                {
                    try
                    {
                        Member member = new Member
                        {
                            Account = this.textBox1.Text,
                            RegisteredDate = DateTime.Now.Date,
                            Password = $"{int.Parse(this.textBox2.Text)}",
                            RealName = "",
                            IDNumber = "",
                            Address = "",
                            NickName = "",
                            Gender = "",
                            Email = "",
                            DateOfBirth = DateTime.Now.Date,
                            Phone = "",
                            MemberLevel = "",
                            Exp = "",
                            Point = 0
                        };
                        this.dbContext.Members.Add(member);
                        this.dbContext.SaveChanges();
                        MessageBox.Show("會員新增成功");
                        this.dataGridView1.DataSource = null;
                        this.dataGridView1.DataSource = this.dbContext.Members.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("此帳戶已被註冊");
                }
            }
            else
            {
                MessageBox.Show("是不是又忘了甚麼");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            會員刪除 f = new 會員刪除();
            f.ShowDialog();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dbContext.Members.ToList();
        }
        #region
        //int a = 0;
        //string b = "";
        //string c = "";
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    int Num = 0;

        //    bool isNum = int.TryParse(textBox1.Text, out Num);
        //    if (isNum)
        //    {
        //        var q = from w in dbContext.Members
        //                 where w.Account == this.textBox1.Text
        //                 select w;
        //        foreach (var z in q)
        //        {
        //            a = z.MemberID;
        //        }
        //        foreach (var x in q)
        //        {
        //            b = x.Account;
        //        }
        //        foreach (var y in q)
        //        {
        //            c = y.Password;
        //        }
        //        if (a != 0)
        //        {
        //            MessageBox.Show("MemberID:" + a + "\nAccount:" + b + "\nPassword:" + c);
        //        }
        //        else
        //        {
        //            MessageBox.Show("查無資料，請確認輸入的帳號密碼");
        //        }

        //    }
        //    else
        //    {
        //        var q1 = from w in dbContext.Members
        //                select w;
        //        this.dataGridView1.DataSource = q1.ToList();
        //    }

        //}
        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
             
            會員修改 f = new 會員修改();
            f.ShowDialog();
            var q = from w in dbContext.Members
                    select new
                    {
                        MemberID=w.MemberID,
                        Account=w.Account,
                        RegisteredDate=w.RegisteredDate,
                        Password=w.Password,
                        RealName=w.RealName,
                        IDNumber=w.IDNumber,
                        Address=w.Address,
                        NickName=w.NickName,
                        Gender=w.Gender,
                        Email=w.Email,
                        DateOfBirth=w.DateOfBirth,
                        Phone=w.Phone,
                        MemberLevel=w.MemberLevel,
                        Exp=w.Exp,
                        Point=w.Point
                    };
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void 會員管理_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dbContext.Members.ToList();
        }
    }
}
