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
    public partial class 商品更新視窗 : Form
    {
        public 商品更新視窗()
        {
            InitializeComponent();
        }
        MyDBEntities dbContext = new MyDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.picBProductPhoto.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.picBProductPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.GetBuffer();
                var q = (from w in dbContext.ProductInfoes.AsEnumerable()
                         where w.ProductInfoID == int.Parse(this.txtProductInfo.Text)
                         select w).FirstOrDefault();

                q.ProductName = this.txtProductName.Text;
                q.SubCategoryID = int.Parse(this.txtSubCategoryID.Text);
                q.UnitPrice = decimal.Parse(this.txtUnitPrice.Text);
                q.ProductDetail = this.txtProductDetail.Text;
                //q.StorelD = int.Parse(this.txtStorelD.Text);
                q.Ingredient = this.txtIngredient.Text;
                q.SupplierID = int.Parse(this.txtSupplierID.Text);
                q.ProductDate = this.DTPakerProductDate.Value;
                q.Display = this.chBDisplay.Checked;
                q.ProductPhoto = bytes;

                this.dbContext.SaveChanges();
                MessageBox.Show("更新成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //商品上下架 f = new 商品上下架();
            ////f.button3_Click(sender, e);
            ////f.DaDis();
            ////f.LabelDis();
            ////f.listboxDis();
            //this.DialogResult = DialogResult.OK;
            this.Close();
            //string connString = Settings.Default.MyDBConnectionString;
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(connString))
            //    {                   
            //        System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //        this.picBProductPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        byte[] bytes = ms.GetBuffer();
            //        conn.Open();
            //        SqlCommand command = new SqlCommand();
            //        command.CommandText = $"UPDATE ProductInfo SET ProductPhoto = {bytes}" +
            //        $",ProductName = {this.txtProductName.Text}" +
            //        $",SubCategoryID = {this.txtSubCategoryID.Text}" +
            //        $",UnitPrice = {this.txtUnitPrice.Text}" +
            //        $",ProductDetail = {this.txtProductDetail.Text}" +
            //        $",StorelD = {this.txtStorelD.Text}" +
            //        $",Ingredient = {this.txtIngredient.Text}" +
            //        $",Display = {this.chBDisplay.Checked}" +
            //        $",SupplierID = {this.txtSupplierID.Text}" +
            //        $",ProductDate = {this.DTPakerProductDate.Value} where ProductInfoID = {this.txtProductInfo.Text}";
            //        command.Connection = conn;
            //        //command.Parameters.("@ProductName", SqlDbType.Text).Value = this.txtProductName.Text;
            //        //command.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = int.Parse(this.txtSubCategoryID.Text);
            //        //command.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = decimal.Parse(this.txtUnitPrice.Text);
            //        //command.Parameters.Add("@ProductDetail", SqlDbType.Text).Value = this.txtProductDetail.Text;
            //        //command.Parameters.Add("@StorelD", SqlDbType.Int).Value = int.Parse(this.txtStorelD.Text);
            //        //command.Parameters.Add("@Ingredient", SqlDbType.Text).Value = this.txtIngredient.Text;
            //        //command.Parameters.Add("@SupplierID", SqlDbType.Int).Value = int.Parse(this.txtSupplierID.Text);
            //        //command.Parameters.Add("@ProductDate", SqlDbType.DateTime).Value = this.DTPakerProductDate.Value;
            //        //command.Parameters.Add("@Display", SqlDbType.Bit).Value = this.chBDisplay.Checked;
            //        //command.Parameters.Add("ProductPhoto", SqlDbType.VarBinary).Value = bytes;
            //        command.ExecuteNonQuery();
            //        MessageBox.Show("successfully");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
