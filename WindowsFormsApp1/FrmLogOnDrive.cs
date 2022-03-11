using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1;

namespace Test
{
    public partial class FrmLogOnDrive : Form
    {
        public FrmLogOnDrive()
        {
            InitializeComponent();
           
        }
        //int tryCount = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            FrmMemberList member = new FrmMemberList();
            member.ShowDialog();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            FrmModifycode code = new FrmModifycode();
            code.Show();
        }
        MyDBEntities myDB = new MyDBEntities();


        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;

            /*tryCount += 1;
            if (tryCount > 1)
            {
                this.Close();
                return;
            }*/
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyDBConnectionString))
                {

                    using (SqlCommand comm = new SqlCommand())
                    {
                        conn.Open();
                        comm.CommandText = "select*from member where Account=@Account and Password= @Password";
                        comm.Connection = conn;
                        comm.Parameters.Add("@Account", SqlDbType.NVarChar, 50).Value = this.textBox1.Text;
                        comm.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = this.textBox2.Text;                       
                        SqlDataReader dataReader = comm.ExecuteReader();                     
                        if (dataReader.HasRows)
                        {
                            // TODONE 會員顯示
                            CurrentLogin.loginID = Form1.LoginID.Member;
                            CurrentLogin.ID = (from n in myDB.Members where n.Account == textBox1.Text select n.MemberID).ToList()[0];
                            CurrentLogin.frm.ShowCurrentLogin(CurrentLogin.loginID, CurrentLogin.ID);
                            MessageBox.Show("登入成功");
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            //this.Dispose();
                            //this.Hide();
                            //this.Close();
                        }
                        else {
                            MessageBox.Show("登入失敗");
                            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            //this.Dispose();
                            //this.Close();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAdmin ad = new FrmAdmin();
            if (ad.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "sWAbvnfc9ZJ1";
            this.textBox2.Text = "5QkM6BVq";
        }
    }
}
