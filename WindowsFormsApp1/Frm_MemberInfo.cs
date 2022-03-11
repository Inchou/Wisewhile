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
    public partial class Frm_MemberInfo : Form
    {
        public Frm_MemberInfo()
        {
            InitializeComponent();
            Box_ID.Text = CurrentLogin.ID.ToString();
        }
        MyDBEntities myDB = new MyDBEntities();

        private void Btn_LoadInfo_Click(object sender, EventArgs e)
        {
            var q = from m in myDB.Members.AsEnumerable()
                   where m.MemberID == int.Parse(this.Box_ID.Text)
                   select m;

            //this.dataGridView1.DataSource = q.ToList();
            foreach (var m in q)
            {
                this.Box_Acc.Text = m.Account;
                this.Box_Name.Text = m.RealName;
                this.Box_IDNum.Text = m.IDNumber;
                this.Box_Gender.SelectedIndex = this.Box_Gender.FindStringExact(m.Gender);
                this.Box_DOB.Text = m.DateOfBirth.ToString();
                this.Box_Addr.Text = m.Address;
                this.Box_Email.Text = m.Email;
                this.Box_Phone.Text = m.Phone;
                this.Box_Nick.Text = m.NickName;
                this.Box_Level.Text = m.MemberLevel;
                this.Box_Exp.Text = m.Exp.ToString();
                this.Box_Point.Text = m.Point.ToString();
                this.Box_RDate.Text = m.RegisteredDate.ToString();
                this.textBox1.Text = m.Password;
            }


        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("未儲存任何資料更動，是否仍關閉視窗?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否儲存已做資料更動?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var q = from m in myDB.Members.AsEnumerable()
                        where m.MemberID == int.Parse(this.Box_ID.Text)
                        select m;

                foreach (var f in q)
                {
                    try
                    {
                        f.RealName = this.Box_Name.Text;
                        f.IDNumber = this.Box_IDNum.Text;
                        f.Gender = this.Box_Gender.SelectedItem.ToString();
                        f.DateOfBirth = Convert.ToDateTime(this.Box_DOB.Text);
                        f.Address = this.Box_Addr.Text;
                        f.Email = this.Box_Email.Text;
                        f.Phone = this.Box_Phone.Text;
                        f.NickName = this.Box_Nick.Text;
                        f.Password = this.textBox1.Text;
                        myDB.SaveChanges();
                        MessageBox.Show("資料更新已儲存");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                if (MessageBox.Show("是否關閉此視窗 ? ", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
