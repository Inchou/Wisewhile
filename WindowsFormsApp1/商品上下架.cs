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
    public partial class 商品上下架 : Form
    {
        public 商品上下架()
        {
            InitializeComponent();
            LoadCategoey();
        }
        MyDBEntities dbContext = new MyDBEntities();
        private void LoadCategoey()
        {
            var q = from w in dbContext.Categories
                    select w.CategoryName;
            this.comboBox1.Items.Clear();
            foreach (string s in q)
            {
                this.comboBox1.Items.Add(s);
            }
            var q1 = from w in dbContext.ProductInfoes
                     select new
                     {
                         產品編號=w.ProductInfoID,
                         產品照片=w.ProductPhoto,
                         產品名稱=w.ProductName,
                         副類別編號=w.SubCategoryID,
                         單價=w.CostPrice,
                         售價=w.UnitPrice,
                         產品細節=w.ProductDetail,
                         成分=w.Ingredient,
                         供應商編號=w.SupplierID,
                         生產日期=w.ProductDate
                     };
            this.dataGridView1.DataSource = q1.ToList();
            //===================
            this.label3.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //主類別Category:男上、男下、女上、女下 => 副類
            var q = from w in dbContext.SubCategories
                    where w.Category.CategoryName==this.comboBox1.SelectedItem.ToString()
                    select w.SubCategoryName;
            this.comboBox2.Items.Clear();
            foreach (string s in q)
            {
                this.comboBox2.Items.Add(s);
            }
            this.comboBox2.Enabled = true;
            //=========================================
            //DataGridView => Category
            var q1 = from w in dbContext.ProductInfoes
                     where w.SubCategory.Category.CategoryName == this.comboBox1.SelectedItem.ToString()
                     select new
                     {
                         產品編號 = w.ProductInfoID,
                         產品照片 = w.ProductPhoto,
                         產品名稱 = w.ProductName,
                         副類別編號 = w.SubCategoryID,
                         單價 = w.CostPrice,
                         售價 = w.UnitPrice,
                         產品細節 = w.ProductDetail,
                         成分 = w.Ingredient,
                         供應商編號 = w.SupplierID,
                         生產日期 = w.ProductDate
                     };
            this.dataGridView1.DataSource = q1.ToList();
            //===================
            this.label3.Text = "";
            this.listBox1.Items.Clear();
            this.button4.Enabled = false;
            this.button1.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //副類別SubCategory:短袖長袖之類的分類
            if (Enabled)
            {
            var q = from w in dbContext.ProductInfoes
                    where w.SubCategory.SubCategoryName== this.comboBox2.SelectedItem.ToString() && w.SubCategory.Category.CategoryName == this.comboBox1.SelectedItem.ToString()
                    select new
                    {
                        產品編號 = w.ProductInfoID,
                        產品照片 = w.ProductPhoto,
                        產品名稱 = w.ProductName,
                        副類別編號 = w.SubCategoryID,
                        單價 = w.CostPrice,
                        售價 = w.UnitPrice,
                        產品細節 = w.ProductDetail,
                        成分 = w.Ingredient,
                        供應商編號 = w.SupplierID,
                        生產日期 = w.ProductDate
                    };
                this.dataGridView1.DataSource = q.ToList();
            }
            //=========================================
            //下方共幾筆資料
            LabelDis();
            //=========================================
            //DataGridView => SubCategory
            //var q1 = from w in dbContext.ProductInfoes
            //         where w.SubCategory.SubCategoryName == this.comboBox2.SelectedItem.ToString() && w.SubCategory.Category.CategoryName == this.comboBox1.SelectedItem.ToString()
            //         select new
            //         {
            //             產品編號 = w.ProductInfoID,
            //             產品照片 = w.ProductPhoto,
            //             產品名稱 = w.ProductName,
            //             副類別編號 = w.SubCategoryID,
            //             單價 = w.CostPrice,
            //             售價 = w.UnitPrice,
            //             產品細節 = w.ProductDetail,
            //             成分 = w.Ingredient,
            //             供應商編號 = w.SupplierID,
            //             生產日期 = w.ProductDate
            //         };
            //this.dataGridView1.DataSource = q1.ToList();

            //=========================================
            //listbox
            listboxDis();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                var q = from w in dbContext.ProductInfoes
                        where w.ProductName == this.listBox1.SelectedItem.ToString()
                        select new
                        {
                            產品名稱 = w.ProductName,
                            產品照片 = w.ProductPhoto,
                            顯示 = w.Display
                        };
                this.dataGridView2.DataSource = null;
                this.dataGridView2.DataSource = q.ToList();
                this.button1.Enabled = true;
                this.button4.Enabled = true;
            }

            //=========================================
            //var q1 = from w in dbContext.ProductInfoes
            //         where w.ProductName == this.listBox1.SelectedItem.ToString()
            //         select w.ProductName;
            //var q2 = from w in dbContext.ProductInfoes
            //         where w.ProductName == this.listBox1.SelectedItem.ToString()
            //         select w.Display;
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] bytes = ms.GetBuffer();
            //foreach (string w in q1)
            //{
            //    this.label4.Text = w;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //刪除
            var q = (from w in dbContext.ProductInfoes
                    where w.ProductName == this.listBox1.SelectedItem.ToString()
                    select w).FirstOrDefault();
            this.dbContext.ProductInfoes.Remove(q);
            this.dbContext.SaveChanges();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dbContext.ProductInfoes.ToList();
            //下方共幾筆資料
            LabelDis();
            //更新DataGridView
            var q1 = from w in dbContext.ProductInfoes
                    where w.SubCategory.SubCategoryName == this.comboBox2.SelectedItem.ToString()
                    select new
                    {
                        產品編號 = w.ProductInfoID,
                        產品照片 = w.ProductPhoto,
                        產品名稱 = w.ProductName,
                        副類別編號 = w.SubCategoryID,
                        單價 = w.CostPrice,
                        售價 = w.UnitPrice,
                        產品細節 = w.ProductDetail,
                        成分 = w.Ingredient,
                        供應商編號 = w.SupplierID,
                        生產日期 = w.ProductDate
                    };
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = q1.ToList();
            //更新listbox
            listboxDis();
            this.dataGridView2.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //跳至新增視窗
            this.Hide();
            商品新增視窗 f = new 商品新增視窗();
            f.ShowDialog();
            this.Show();
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            if (this.comboBox2.Enabled == true)
            {
                DaDis();
                listboxDis();
                LabelDis();
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            //修改
            this.Hide();
            商品更新視窗 f = new 商品更新視窗();
            DialogResult dialogResult = f.ShowDialog();
            this.Show();
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            DaDis();
            LabelDisForup();
            listboxDisForup();
        }
        bool Flag;
        private void button4_Click(object sender, EventArgs e)
        {
            Flag = !Flag;
            var q = from w in dbContext.ProductInfoes
                    where w.ProductName == this.listBox1.SelectedItem.ToString()
                    select w;
            foreach(var s in q)
            {
                Flag = s.Display;
            }
            if (button4.Enabled)
            {
                if (!Flag)
                {
                    var aaa = from w in dbContext.ProductInfoes
                            where w.ProductName == this.listBox1.SelectedItem.ToString() && w.Display == false
                            select w;
                    foreach (var s in aaa)
                    {
                        s.Display = true;
                    }
                    this.dbContext.SaveChanges();
                    MessageBox.Show("產品上架成功");
                    var q1 = from w in dbContext.ProductInfoes
                             where w.ProductName == this.listBox1.SelectedItem.ToString()
                             select new
                             {
                                 產品名稱 = w.ProductName,
                                 產品照片 = w.ProductPhoto,
                                 顯示 = w.Display
                             };
                    this.dataGridView2.DataSource = q1.ToList();
                }
                else
                {
                    var bbb = from w in dbContext.ProductInfoes
                            where w.ProductName == this.listBox1.SelectedItem.ToString() && w.Display == true
                            select w;
                    foreach (var s in bbb)
                    {
                        s.Display = false;
                    }
                    this.dbContext.SaveChanges();
                    MessageBox.Show("產品下架成功");
                    var q1 = from w in dbContext.ProductInfoes
                             where w.ProductName == this.listBox1.SelectedItem.ToString()
                             select new
                             {
                                 產品名稱 = w.ProductName,
                                 產品照片 = w.ProductPhoto,
                                 顯示 = w.Display
                             };
                    this.dataGridView2.DataSource = q1.ToList();
                }
            }
        }
        public void DaDis()
        {
            var q = from w in dbContext.ProductInfoes
                    select new
                    {
                        產品編號 = w.ProductInfoID,
                        產品照片 = w.ProductPhoto,
                        產品名稱 = w.ProductName,
                        副類別編號 = w.SubCategoryID,
                        單價 = w.CostPrice,
                        售價 = w.UnitPrice,
                        產品細節 = w.ProductDetail,
                        成分 = w.Ingredient,
                        供應商編號 = w.SupplierID,
                        生產日期 = w.ProductDate
                    };
            this.dataGridView1.DataSource = q.ToList();
            if (this.dataGridView1.DataSource == null)
            {
                return;
            }
        }

        public void LabelDis()
        {
            var q = from w in dbContext.ProductInfoes
                    where w.SubCategory.SubCategoryName == this.comboBox2.SelectedItem.ToString() && w.SubCategory.Category.CategoryName == this.comboBox1.SelectedItem.ToString()
                    select w;
            string s = "共" + q.Count() + "筆資料";
            this.label3.Text = s;
        }
        public void listboxDis()
        {
            var q = from w in dbContext.ProductInfoes
                    where w.SubCategory.SubCategoryName == this.comboBox2.SelectedItem.ToString() && w.SubCategory.Category.CategoryName==this.comboBox1.SelectedItem.ToString()
                    select w.ProductName;
            this.listBox1.Items.Clear();
            foreach (string s in q)
            {
                this.listBox1.Items.Add(s);
            }
            this.button4.Enabled = false;
            this.button1.Enabled = false;
        }
        public void LabelDisForup()
        {
            var q = from w in dbContext.ProductInfoes
                    where w.SubCategory.SubCategoryName == this.comboBox2.SelectedItem.ToString()
                    select w;
            string s = "共" + q.Count() + "筆資料";
            this.label3.Text = s;
        }
        public void listboxDisForup()
        {
            var q = from w in dbContext.ProductInfoes
                    where w.SubCategory.SubCategoryName == this.comboBox2.SelectedItem.ToString()
                    select w.ProductName;
            this.listBox1.Items.Clear();
            foreach (string s in q)
            {
                this.listBox1.Items.Add(s);
            }
            this.button4.Enabled = false;
            this.button1.Enabled = false;
        }
    }
}
