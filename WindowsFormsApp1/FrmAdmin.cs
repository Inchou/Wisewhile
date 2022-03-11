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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }


        //int tryCount = 0;
        //bool IsToForm1 = false;
        MyDBEntities myDB = new MyDBEntities();

        private void button1_Click(object sender, EventArgs e)
        {

            //Form1 form = new Form1();
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
                        comm.CommandText = "select*from employees where EmployeeID=@Employee and Phone= @Phone";
                        comm.Connection = conn;
                        int.TryParse(this.textBox1.Text, out int t1);
                        comm.Parameters.Add("@Employee", SqlDbType.Int).Value = t1;
                        comm.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = textBox2.Text;
                        SqlDataReader dataReader = comm.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            // TODONE 管理員顯示
                            CurrentLogin.loginID = Form1.LoginID.Employee;
                            CurrentLogin.ID = t1;
                            CurrentLogin.frm.ShowCurrentLogin(CurrentLogin.loginID, CurrentLogin.ID);
                            MessageBox.Show("登入成功");
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            //this.Dispose();
                            //this.Hide();                            
                            //this.Close(); 
                            //form.Show();
                        }
                        else
                        {
                            MessageBox.Show("登入失敗");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "13";
            this.textBox2.Text = "920000000";
        }
        //protected override void OnClosing(CancelEventArgs e) //在視窗關閉時觸發
        //{
        //    base.OnClosing(e);
        //    if (IsToForm1) //判斷是否要回到Form1
        //    {
        //        this.DialogResult = DialogResult.Yes; //利用DialogResult傳遞訊息
        //        Form1 form1 = (Form1)this.Owner; //取得父視窗的參考

        //    }
        //    else
        //    {
        //        this.DialogResult = DialogResult.No;
        //    }
        //}
    }
}
