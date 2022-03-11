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
    public partial class 員工管理 : Form
    {

        public 員工管理()
        {
            InitializeComponent();
            //combox顯示員工姓名
            LoadEmployeeName();
        }
        //創建實體資料庫
        MyDBEntities dbContext = new MyDBEntities();

        //載入employee到combobox
        private void LoadEmployeeName()
        {
            var emp = from em in this.dbContext.Employees
                      orderby em.EmployeeName ascending
                      select em.EmployeeName;
            foreach (string s in emp)
            {
                this.comboBox1.Items.Add(s);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            this.dataGridView3.DataSource = null;
            //顯示所有員工
            var emp = from em in this.dbContext.Employees
                      select new
                      {
                          員工編號ID = em.EmployeeID,
                          員工名稱 = em.EmployeeName,
                          手機電話 = em.Phone,
                          入職日期 = em.HireDate,
                          薪水 = em.Salaries,
                          聯絡地址 = em.Address,
                          職位編號 = em.PositionID,
                          主管編號 = em.ManagerID,
                          信箱 = em.Mail,
                          出生日期 = em.DateOfBirth
                      };
            this.dataGridView1.DataSource = emp.ToList();
            //顯示員工薪水
            var sal = from sa in this.dbContext.Salaries
                      select new
                      {
                          薪水ID = sa.SalaryID,
                          員工編號 = sa.EmployeeID,
                          年資 = sa.Seniority,
                          薪水 = sa.Salary1,
                          津貼 = sa.Allowance,
                          津貼明細 = sa.AllowanceDetail,
                          給薪紀錄 = sa.PaidHistory
                      }
                      ;
            this.dataGridView2.DataSource = sal.ToList();
            //顯示員工職位
            var pos = from po in this.dbContext.Positions
                      select new
                      {
                          職位id = po.PositionID,
                          職位名稱 = po.PositionName
                      };
            this.dataGridView3.DataSource = pos.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string empName = this.comboBox1.SelectedItem.ToString();

            //用導覽屬性找employeename
            var emp = from em in this.dbContext.Employees
                      where em.EmployeeName == empName
                      select em;
            this.dataGridView1.DataSource = emp.ToList();

            //用導覽屬性找employeename
            var sal = from s in dbContext.Salaries
                      where s.Employee.EmployeeName == empName
                      select s;
            this.dataGridView2.DataSource = sal.ToList();

            //用導覽屬性找employeename
            var pos = from s in dbContext.Employees
                      where s.EmployeeName == empName
                      select s.Position;
            this.dataGridView3.DataSource = pos.ToList();            
        }

        //修改員工薪資
        private void button2_Click(object sender, EventArgs e)
        {

            this.splitContainer1.Panel2.Controls.Clear();
            編輯員工薪水 creat = new 編輯員工薪水();
            creat.TopLevel = false;
            creat.Show();
            this.splitContainer1.Panel2.Controls.Add(creat);
        }
        //修改員工職位
        private void button6_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            編輯員工職位 creat = new 編輯員工職位();
            creat.TopLevel = false;
            creat.Show();
            this.splitContainer1.Panel2.Controls.Add(creat);
        }

        //編輯員工資料
        private void button3_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            編輯員工資料 creat = new 編輯員工資料();
            creat.TopLevel = false;
            creat.Show();
            this.splitContainer1.Panel2.Controls.Add(creat);
        }
    }
}
