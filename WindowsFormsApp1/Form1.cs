using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wisewhile;
using MidTermReport;
using Test;
using Report;
using 專題;

namespace WindowsFormsApp1
{
    public struct CurrentLogin
    {
        public static Form1 frm;
        public static Form1.LoginID loginID;
        public static int ID;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            splitContainer6.Panel1.Controls.Clear();
            splitContainer6.Panel1Collapsed = true;
            CurrentLogin.frm = this;
            CurrentLogin.loginID = LoginID.None;
            CurrentLogin.ID = 0;
        }

        MyDBEntities dbContext = new MyDBEntities();
        public enum LoginID { Member, Employee, None };

        public void ShowCurrentLogin(LoginID loginID,int ID = 0)
        {
            splitContainer6.Panel1.Controls.Clear();
            if (loginID == LoginID.None || ID == 0) 
            {
                CurrentLogin.frm.label1.Visible = false;
                CurrentLogin.frm.button1.Visible = false;
                splitContainer6.Panel1Collapsed = true;
                button7.Enabled = true;
            }
            else if (loginID == LoginID.Member)
            {
                CurrentLogin.frm.label1.Visible = true;
                CurrentLogin.frm.button1.Visible = true;
                string q = (from n in dbContext.Members where n.MemberID == ID select n.NickName).ToList()[0];
                label1.Text = $"會員 {q} 您好";
                splitContainer6.Panel1Collapsed = false;
                button7.Enabled = false;
                string[] strs = { "會員資料", "訂單紀錄" };
                for (int i = 0; i < strs.Length; i++) 
                {
                    Button button = new Button();
                    button.Location = new Point(20, 20 + 50 * i);
                    button.Size = new System.Drawing.Size(150, 40);
                    button.Text = strs[i];
                    button.Click += Button_Click;
                    splitContainer6.Panel1.Controls.Add(button);
                }
            }
            else if (loginID == LoginID.Employee)
            {
                CurrentLogin.frm.label1.Visible = true;
                CurrentLogin.frm.button1.Visible = true;
                string q = (from n in dbContext.Employees where n.EmployeeID == ID select n.EmployeeName).ToList()[0];
                label1.Text = $"管理員 {q} 您好";
                splitContainer6.Panel1Collapsed = false;
                button7.Enabled = false;
                string[] strs = { "商品管理", "庫存管理", "員工管理", "會員管理", "訂單管理", "評論管理" };
                for (int i = 0; i < strs.Length; i++)
                {
                    Button button = new Button();
                    button.Location = new Point(20, 20 + 50 * i);
                    button.Size = new System.Drawing.Size(150, 40);
                    button.Text = strs[i];
                    button.Click += Button_Click;
                    splitContainer6.Panel1.Controls.Add(button);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "會員資料":
                    Frm_MemberInfo f = new Frm_MemberInfo();
                    f.ShowDialog();
                    break;
                case "訂單紀錄":
                    Frm_View f1 = new Frm_View();
                    f1.ShowDialog();
                    break;
                case "商品管理":
                    商品上下架 f2 = new 商品上下架();
                    f2.ShowDialog();
                    break;
                case "庫存管理":
                    庫存 f3 = new 庫存();
                    f3.ShowDialog();
                    break;
                case "員工管理":
                    員工管理 f4 = new 員工管理();
                    f4.ShowDialog();
                    break;
                case "會員管理":
                    會員管理 f5 = new 會員管理();
                    f5.ShowDialog();
                    break;
                case "訂單管理":
                    訂單狀態 f6 = new 訂單狀態();
                    f6.ShowDialog();
                    break;
                case "評論管理":
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //顯示會員登入表單，一般使用者登入之後才能看購物車、自己的會員資料及訂單紀錄
            //管理員登入之後才能看到後台管理頁面
            FrmLogOnDrive f = new FrmLogOnDrive();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //顯示商品頁面
            FrmShowProduct f = new FrmShowProduct();
            if (f.ShowDialog()==DialogResult.OK)
            {
                // todone 1 和購物車連接
                if (CurrentLogin.loginID == LoginID.Member)
                {
                    Frm_Cart f1 = new Frm_Cart();
                    f1.ShowDialog();
                }
                else if(CurrentLogin.loginID == LoginID.None)
                {
                    FrmLogOnDrive f1 = new FrmLogOnDrive();
                    f1.ShowDialog();
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //顯示購物車
            if (CurrentLogin.loginID == LoginID.Member) 
            {
                Frm_Cart f = new Frm_Cart();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("請先登入會員");
                FrmLogOnDrive f = new FrmLogOnDrive();
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentLogin.loginID = LoginID.None;
            CurrentLogin.ID = 0;
            CurrentLogin.frm.ShowCurrentLogin(CurrentLogin.loginID, CurrentLogin.ID);
            MessageBox.Show("成功登出");
        }
    }
}
