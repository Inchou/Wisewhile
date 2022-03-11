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
    public partial class 編輯員工薪水 : Form
    {
        public 編輯員工薪水()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();
        //s判斷員工ID變數
        string s;
        //新增員工薪水
        private void btnNew_Click(object sender, EventArgs e)
        {
            var q = from w in dbContext.Salaries.AsEnumerable()
                    where w.EmployeeID == int.Parse(this.txtEmployeeID.Text)
                    select w;

            foreach (var w in q)
            {
                s = w.EmployeeID.ToString();
            }
            if (this.txtEmployeeID.Text != s)
            {
                try
                {
                    Salary salary = new Salary
                    {
                        EmployeeID = int.Parse(txtEmployeeID.Text),
                        Seniority = int.Parse(txtSeniority.Text),
                        Salary1 = Convert.ToDecimal(txtSalary.Text),
                        Allowance = Convert.ToDecimal(txtAllowance.Text),
                        AllowanceDetail = txtAllowanceDetail.Text,
                        PaidHistory = txtPaidHistory.Text
                    };
                    this.dbContext.Salaries.Add(salary);
                    this.dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("輸入重複ID");
            }
        }

        //修改員工薪水
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                var sal = (from s in this.dbContext.Salaries.AsEnumerable()
                           where s.SalaryID == int.Parse(this.txtSalaryID.Text)
                           select s).FirstOrDefault();
                sal.EmployeeID = int.Parse(txtEmployeeID.Text);
                sal.Seniority = int.Parse(txtSeniority.Text);
                sal.Salary1 = Convert.ToDecimal(txtSalary.Text);
                sal.Allowance = Convert.ToDecimal(txtAllowance.Text);
                sal.AllowanceDetail = txtAllowanceDetail.Text;
                sal.PaidHistory = txtPaidHistory.Text;

                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("請輸入完整資料");
            }
        }

        //刪除員工薪水
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var sal = (from s in this.dbContext.Salaries.AsEnumerable()
                           where s.SalaryID == int.Parse(this.txtSalaryID.Text)
                           select s).FirstOrDefault();
                this.dbContext.Salaries.Remove(sal);
                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("請輸入完整資料");
            }
        }
    }
}
