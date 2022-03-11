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
    public partial class 會員修改 : Form
    {
        public 會員修改()
        {
            InitializeComponent();
        }

        private void memberBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.memberBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.teDataSet);

        }

        MyDBEntities dbContext = new MyDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var q = from w in dbContext.Members.AsEnumerable()
                    where w.MemberID == int.Parse(this.memberIDTextBox.Text)
                    select w;
            foreach (var w in q)
            {
                w.Account = this.accountTextBox.Text;
                w.RegisteredDate = this.registeredDateDateTimePicker.Value;
                w.Password = this.passwrodTextBox.Text;
                w.RealName = this.realNameTextBox.Text;
                w.IDNumber = this.iDNumberTextBox.Text;
                w.Address = this.addressTextBox.Text;
                w.NickName = this.nickNameTextBox.Text;
                w.Gender = this.genderTextBox.Text;
                w.Email = this.emailTextBox.Text;
                w.DateOfBirth = this.dateOfBirthDateTimePicker.Value;
                w.Phone = this.phoneTextBox.Text;
                w.MemberLevel = this.memberLevelTextBox.Text;
                w.Exp = this.expTextBox.Text;
                w.Point = int.Parse(this.pointTextBox.Text);
            }
            this.dbContext.SaveChanges();
            MessageBox.Show("更新成功");
        }
    }
}
