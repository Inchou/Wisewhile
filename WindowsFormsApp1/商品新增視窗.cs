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

namespace WindowsFormsApp1
{
    public partial class 商品新增視窗 : Form
    {
        public 商品新增視窗()
        {
            InitializeComponent();
            this.picBProductPhoto.AllowDrop = true;
            this.picBProductPhoto.DragEnter += picBProductPhoto_DragEnter;
            this.picBProductPhoto.DragDrop += picBProductPhoto1_DragDrop;
        }

        private void picBProductPhoto1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.picBProductPhoto.Image = Image.FromFile(files[0]);
        }

        private void picBProductPhoto_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        //MyDBEntities1 dbContext = new MyDBEntities1();
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var q = new ProductInfo
        //        {
        //            ProductName = this.txtProductName.Text,
        //            SubCategoryID = int.Parse(this.txtSubCategoryID.Text),
        //            UnitPrice = decimal.Parse(this.txtUnitPrice.Text),
        //            ProductDetail = this.txtProductDetail.Text,
        //            StorelD = int.Parse(this.txtStorelD.Text),
        //            Ingredient = this.txtIngredient.Text,
        //            SupplierID = int.Parse(this.txtSupplierID.Text),
        //            ProductDate = this.DTPakerProductDate.Value,
        //            Display = this.chBDisplay.Checked.ToString(),
        //            ProductPhoto = this.picBProductPhoto
        //        };
        //        this.dbContext.ProductInfoes.Add(q);
        //        this.dbContext.SaveChanges();

        //        if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            this.picBProductPhoto.Image = Image.FromFile(this.openFileDialog1.FileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + ",請確認欄位是否有空並輸入正確資料");
        //    }
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            string connString = Settings.Default.MyDBConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into ProductInfo (ProductName,SubCategoryID,CostPrice,UnitPrice,ProductDetail,Ingredient,SupplierID,ProductDate,Display,ProductPhoto) " +
                        "values (@ProductName,@SubCategoryID,@CostPrice,@UnitPrice,@ProductDetail,@Ingredient,@SupplierID,@ProductDate,@Display,@ProductPhoto)";
                    command.Connection = conn;

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.picBProductPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.GetBuffer();

                    command.Parameters.Add("@ProductName", SqlDbType.Text).Value = this.txtProductName.Text;
                    command.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = int.Parse(this.txtSubCategoryID.Text);
                    command.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = decimal.Parse(this.txtUnitPrice.Text);
                    command.Parameters.Add("@ProductDetail", SqlDbType.Text).Value = this.txtProductDetail.Text;
                    command.Parameters.Add("@CostPrice", SqlDbType.Int).Value = int.Parse(this.txtCostPrice.Text);
                    command.Parameters.Add("@Ingredient", SqlDbType.Text).Value = this.txtIngredient.Text;
                    command.Parameters.Add("@SupplierID", SqlDbType.Int).Value = int.Parse(this.txtSupplierID.Text);
                    command.Parameters.Add("@ProductDate", SqlDbType.DateTime).Value = this.DTPakerProductDate.Value;
                    command.Parameters.Add("@Display", SqlDbType.Bit).Value = this.chBDisplay.Checked;
                    command.Parameters.Add("ProductPhoto", SqlDbType.VarBinary).Value = bytes;

                    command.ExecuteNonQuery();
                    MessageBox.Show("successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.picBProductPhoto.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }
    }
}

