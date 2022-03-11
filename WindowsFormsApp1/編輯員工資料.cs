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
    public partial class 編輯員工資料 : Form
    {
        public 編輯員工資料()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();
        //新增員工資料
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee
                {
                    EmployeeName = txtEmployeeName.Text,
                    Phone = txtPhone.Text,
                    HireDate = dtpHireDate.Value,
                    Salary = int.Parse(txtSalary.Text),
                    Address = txtAddress.Text,
                    PositionID = int.Parse(txtPositionID.Text),
                    ManagerID = int.Parse(txtManagerID.Text),
                    DateOfBirth = dtpDateOfBirth.Value,
                    Mail = txtMail.Text
                };
                this.dbContext.Employees.Add(employee);
                this.dbContext.SaveChanges();
                MessageBox.Show("新增成功");
            }
            catch (Exception)
            {
                MessageBox.Show("請輸入正確資料");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = (from em in this.dbContext.Employees.AsEnumerable()
                           where em.EmployeeID == int.Parse(this.txtEmployeeID.Text)
                           select em).FirstOrDefault();
                emp.EmployeeID = int.Parse(txtEmployeeID.Text);
                emp.Phone = txtPhone.Text;
                emp.HireDate = dtpHireDate.Value;
                emp.Salary = int.Parse(txtSalary.Text);
                emp.Address = txtAddress.Text;
                emp.PositionID = int.Parse(txtPositionID.Text);
                emp.ManagerID = int.Parse(txtManagerID.Text);
                emp.DateOfBirth = dtpDateOfBirth.Value;
                emp.Mail = txtMail.Text;
                this.dbContext.SaveChanges();
                MessageBox.Show("修改成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDlete_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = (from em in this.dbContext.Employees.AsEnumerable()
                           where em.EmployeeID == int.Parse(this.txtEmployeeID.Text)
                           select em).FirstOrDefault();
                this.dbContext.Employees.Remove(emp);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("請輸入正確資料");
            }
        }
    }
}
