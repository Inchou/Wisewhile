using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Test
{
    public partial class FrmMemberList : Form
    {
        public FrmMemberList()
        {
            InitializeComponent();
            checkany();

            this.dbContext.Database.Log = Console.WriteLine;

        }
        private void checkany()
        {           
            //中文名字
            //var RegChn = / ^[\u4e00 - \u9fa5] *$/;
            string text = textBox1.Text.ToString().Replace(" ", String.Empty);
            char[] c = text.ToCharArray();
            bool check_chi = true;
            if (text == "")
            {
                label12.Text = " 要輸入文字！";

            }
            else if (text.Length >= 2)
            {
                for (int i = 0; i < text.Length; i++)
                {

                    if (c[i] < 0x4e00 || c[i] > 0x9fff)
                    {
                        check_chi = false;
                        label12.Text = " 只能有中文字";
                    }
                    if (check_chi == false)
                    {
                        break;
                    }
                }
                if (check_chi == true)
                {
                    label12.Text = " 正確！";
                }
            }
            else if (text.Length < 2)
            {
                label12.Text = " 至少兩個字以上！";

            }

        }

        MyDBEntities dbContext = new MyDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox1.Controls.Cast<Control>().Where(T=>T is TextBox).All(T=>(T as TextBox).Text.Trim().Length>0)) 
            {
                Member member = new Member
                {
                    RealName = $"{this.textBox1.Text}",
                    NickName = $"{this.textBox2.Text}",
                    Account = $"{this.textBox3.Text}",
                    Password = $"{this.textBox4.Text}",
                    Email = $"{this.textBox5.Text}",
                    Phone = $"{this.textBox6.Text}",
                    DateOfBirth = this.dateTimePicker1.Value,
                    Address = $"{this.textBox7.Text}",
                    IDNumber = $"{this.textBox8.Text}",
                    Gender = this.comboBox1.SelectedItem.ToString(),
                    RegisteredDate = DateTime.Now,
                    MemberLevel = "0",
                    Point = 0,
                    Exp = "",
                };
                this.dbContext.Members.Add(member);
                this.dbContext.SaveChanges();
                MessageBox.Show("註冊成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("尚有未完成填寫的欄位");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.comboBox1.Items.Clear();
            this.dateTimePicker1.CustomFormat = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkany();
        }
        bool IsCorrectPW(string account)
        {
            return Regex.IsMatch(account, @"^[A-Za-z0-9].{8,16}$");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {        
            label13.Text = IsCorrectPW(textBox3.Text) ? "格式正確" : "格式錯誤";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var q = from o in this.dbContext.Members
                    where o.Account == this.textBox3.Text
                    select o;
            int x = 0;
            foreach (var v in q)
            {
                x++;
            }
            if (x > 0)
            {
                MessageBox.Show("該賬戶已被註冊");
            }
            else
            {
                MessageBox.Show("該賬戶未被註冊");
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label14.Text = IsCorrectPW(textBox4.Text) ? "格式正確" : "格式錯誤";
        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label15.Text = IsValidEmail(textBox5.Text) ? "格式正確" : "格式錯誤";
        }
        bool correctPhone(int phone) {
            return Regex.IsMatch(phone.ToString(), @"(^(\d{2,8})$)");
                }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label16.Text = correctPhone(textBox6.Text.Length) ? "格式正確" : "格式錯誤";
        }
        public string Check(string id)
        {
            // 使用「正規表達式」檢驗格式 [A~Z] {1}個數字 [0~9] {9}個數字
            var regex = new Regex("^[A-Z]{1}[0-9]{9}$");
            if (!regex.IsMatch(id))
            {
                //Regular Expression 驗證失敗，回傳 ID 錯誤
                return "身分證基本格式錯誤";
            }

            //除了檢查碼外每個數字的存放空間 
            int[] seed = new int[10];

            //建立字母陣列(A~Z)
            //A=10 B=11 C=12 D=13 E=14 F=15 G=16 H=17 J=18 K=19 L=20 M=21 N=22
            //P=23 Q=24 R=25 S=26 T=27 U=28 V=29 X=30 Y=31 W=32  Z=33 I=34 O=35            
            string[] charMapping = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
            string target = id.Substring(0, 1); //取第一個英文數字
            for (int index = 0; index < charMapping.Length; index++)
            {
                if (charMapping[index] == target)
                {
                    index += 10;
                    //10進制的高位元放入存放空間   (權重*1)
                    seed[0] = index / 10;

                    //10進制的低位元*9後放入存放空間 (權重*9)
                    seed[1] = (index % 10) * 9;

                    break;
                }
            }
            for (int index = 2; index < 10; index++) //(權重*8~1)
            {   //將剩餘數字乘上權數後放入存放空間                
                seed[index] = Convert.ToInt32(id.Substring(index - 1, 1)) * (10 - index);
            }
            //檢查是否符合檢查規則，10減存放空間所有數字和除以10的餘數的個位數字是否等於檢查碼            
            //(10 - ((seed[0] + .... + seed[9]) % 10)) % 10 == 身分證字號的最後一碼   
            if ((10 - (seed.Sum() % 10)) % 10 != Convert.ToInt32(id.Substring(9, 1)))
            {
                return "請輸入正確身分證";
            }

            return "身分證號碼正確";
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label17.Text = Check(textBox8.Text);
        }
    }
    
}

