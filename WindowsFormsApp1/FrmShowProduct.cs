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

namespace Wisewhile
{
    public partial class FrmShowProduct : Form
    {
        public FrmShowProduct()
        {
            InitializeComponent();
            LoadComboBox();
            LoadSizeColor();
            //ShowProduct();
        }

        MyDBEntities dbContext = new MyDBEntities();
        System.Drawing.Color myColor = System.Drawing.Color.Yellow;

        private void LoadComboBox()
        {
            var q = from n in dbContext.Categories select n.CategoryName;
            var s = q.Append("所有分類").Concat(q);
            int c = q.Count();
            cbxCategory.DataSource = s.Skip(c).ToList();
            cbxCategory.SelectedIndex = 0;
        }

        private void LoadSizeColor()
        {
            //LoadSize
            List<string> s = (from n in dbContext.Sizes select n.SizeName).ToList();
            s = OrderBySize(s);
            Panel panelSize = new Panel();
            panelSize.Name = "panelSize";
            panelSize.AutoSize = true;
            panelSize.Height = 30;
            panelSize.Location = new Point(lblSize.Left + 50, lblSize.Top - 10);
            for (int i = 0; i < s.Count; i++)
            {
                Label lbl = new Label();
                lbl.Width = 30;
                lbl.Height = 30;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Text = s[i];
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Location = new Point(0 + 50 * i, 0);
                lbl.Click += Lbl_Click1;
                panelSize.Controls.Add(lbl);
            }
            Controls.Add(panelSize);

            //LoadColor
            List<string> c = (from n in dbContext.Colors select n.ColorName).ToList();
            Panel panelColor = new Panel();
            panelColor.Name = "panelColor";
            panelColor.AutoSize = true;
            panelColor.Height = 30;
            panelColor.Location = new Point(lblColor.Left + 50, lblColor.Top - 10);
            for (int i = 0; i < c.Count; i++)
            {
                Label lbl = new Label();
                lbl.Width = 30;
                lbl.Height = 30;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Text = c[i];
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Location = new Point(0 + 50 * i, 0);
                lbl.Click += Lbl_Click1;
                panelColor.Controls.Add(lbl);
            }
            Controls.Add(panelColor);

        }

        private void Lbl_Click1(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == myColor)
            {
                ((Label)sender).BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                ((Label)sender).BackColor = myColor;
            }
            ShowProduct();
        }

        private List<string> OrderBySize(List<string> s)
        {
            List<string> strS = new List<string>();
            List<string> strM = new List<string>();
            List<string> strL = new List<string>();
            List<string> strOther = new List<string>();
            foreach (string str in s) 
            {
                if (str.ToLower().Contains("s"))
                {
                    strS.Add(str);
                }
                else if (str.ToLower() == "m") 
                {
                    strM.Add(str);
                }
                else if (str.ToLower().Contains("l"))
                {
                    strL.Add(str);
                }
                else
                {
                    strOther.Add(str);
                }
            }
            for (int i = 0; i < strS.Count; i++) 
            {
                for (int j = i; j < strS.Count; j++)
                {
                    if (strS[j].Length > strS[i].Length || (strS[j].Length == strS[i].Length && strS[j].ToLower().Contains("x"))) 
                    {
                        string t = strS[i];
                        strS[i] = strS[j];
                        strS[j] = t;
                    }
                }
            }
            for (int i = 0; i < strL.Count; i++)
            {
                for (int j = i; j < strL.Count; j++)
                {
                    if (strL[j].Length < strL[i].Length || (strL[j].Length == strL[i].Length && strL[j].ToLower().Contains("x")))
                    {
                        string t = strL[i];
                        strL[i] = strL[j];
                        strL[j] = t;
                    }
                }
            }
            strOther.Sort();
            List<string> result = new List<string>();
            return result.Concat(strS).Concat(strM).Concat(strL).Concat(strOther).ToList();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // todone 1 和購物車連接
            if (CurrentLogin.loginID == Form1.LoginID.None)
            {
                MessageBox.Show("請先登入會員");
            }
            ((Button)sender).FindForm().DialogResult = DialogResult.OK;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /*private void TextBox_Leave(object sender, EventArgs e)
        {
            int s = ((TextBox)sender).SelectionStart;
            int.TryParse(((TextBox)sender).Text, out int num);
            int maxStock = 0;
            foreach (object o in ((TextBox)sender).Parent.Controls)
            {
                if (o is Label)
                {
                    if (((Label)o).Text.Substring(0, 2) == "庫存")
                    {
                        int.TryParse(((Label)o).Text.Substring(3), out maxStock);
                    }
                }
            }

            if (num > maxStock)
            {
                ((TextBox)sender).Text = maxStock.ToString();
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            }
            else if(num == 0)
            {
                ((TextBox)sender).Text = "1";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            }
            else
            {
                ((TextBox)sender).Text = num.ToString();
                ((TextBox)sender).SelectionStart = s;
            }
        }*/



        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProduct();
            if (cbxCategory.Text == "所有分類")
            {
                cbxSubCategory.DataSource = null;
                cbxSubCategory.Visible = false;
            }
            else
            {
                LoadSecondComboBox();
                cbxSubCategory.Visible = true;
            }

        }

        private void LoadSecondComboBox()
        {
            var q = from n in dbContext.SubCategories where n.Category.CategoryName == cbxCategory.Text select n.SubCategoryName;
            var s = q.Append("所有分類").Concat(q);
            int c = q.Count();
            cbxSubCategory.DataSource = s.Skip(c).ToList();
            cbxSubCategory.SelectedIndex = 0;
        }

        private void cbxSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProduct();
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            ShowProduct();
        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            ShowProduct();
        }

        private void ShowProduct()
        {
            IQueryable<ProductInfo> qInfo;
            IQueryable<Product> qP = from n in dbContext.Products select n;
            bool sizeChange = false, colorChange = false;
            List<string> sizes = new List<string>(), colors = new List<string>();
            foreach (object o in Controls)
            {
                if (o is Panel)
                {
                    if (((Panel)o).Name == "panelSize")
                    {
                        foreach (Label label in ((Panel)o).Controls)
                        {
                            if (label.BackColor == myColor)
                            {
                                sizeChange = true;
                                sizes.Add(label.Text);
                            }
                        }
                    }
                    else if (((Panel)o).Name == "panelColor")
                    {
                        foreach (Label label in ((Panel)o).Controls)
                        {
                            if (label.BackColor == myColor)
                            {
                                colorChange = true;
                                colors.Add(label.Text);
                            }
                        }
                    }
                }
            }

            if (sizeChange)
            {
                qP = from n in qP where sizes.Contains(n.Size.SizeName) select n;
                //qP.Where(n => sizes.Contains(n.Size.SizeName));
            }
            if (colorChange)
            {
                //qP.Where(n => colors.Contains(n.Color.ColorName) && n.ColorID == n.Color.ColorID);
                qP = from n in qP where colors.Contains(n.Color.ColorName) select n;
            }

            //qInfo = qP.Select(n => n.ProductInfo);

            if (cbxCategory.Text == "所有分類")
            {
                //qInfo = from n in dbContext.ProductInfoes where n.Products.Any(p => p.UnitsinStock > 0) select n;
                qInfo = qP.Where(n => n.UnitsinStock > 0).Select(n => n.ProductInfo);
            }
            else if (cbxSubCategory.Text == "所有分類")
            {
                //qInfo = from n in dbContext.ProductInfoes where n.Products.Any(p => p.UnitsinStock > 0) && n.SubCategory.Category.CategoryName == cbxCategory.Text select n;
                qInfo = qP.Where(n => n.UnitsinStock > 0).Select(n => n.ProductInfo).Where(n => n.SubCategory.Category.CategoryName == cbxCategory.Text);
            }
            else
            {
                //qInfo = from n in dbContext.ProductInfoes where n.Products.Any(p => p.UnitsinStock > 0) && n.SubCategory.SubCategoryName == cbxSubCategory.Text && n.SubCategory.Category.CategoryName == cbxCategory.Text select n;
                qInfo = qP.Where(n => n.UnitsinStock > 0).Select(n => n.ProductInfo).Where(n => n.SubCategory.Category.CategoryName == cbxCategory.Text && n.SubCategory.SubCategoryName == cbxSubCategory.Text);
            }

            qInfo = qInfo.Distinct();

            if (double.TryParse(txtMin.Text, out double min))
            {
                qInfo = qInfo.Where(n => (double)n.UnitPrice >= min);
            }
            if (double.TryParse(txtMax.Text, out double max))
            {
                qInfo = qInfo.Where(n => (double)n.UnitPrice <= max);
            }

            CreateProductInForm(qInfo);
        }

        private void CreateProductInForm(IQueryable<ProductInfo> q)
        {
            flowLayoutPanelForProduct.Controls.Clear();

            foreach (ProductInfo p in q)
            {
                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 270;
                PictureBox pictureBox = new PictureBox();
                byte[] bytes = p.ProductPhoto;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pictureBox.Image = Image.FromStream(ms);
                pictureBox.Parent = panel;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 180;
                pictureBox.Height = 180;
                pictureBox.Top = 10;
                pictureBox.Left = 10;
                pictureBox.Click += PictureBox_Click;
                pictureBox.Tag = p.ProductInfoID;
                Label label = new Label();
                label.Parent = panel;
                label.Text = p.ProductName;
                label.AutoEllipsis = true;
                label.Width = 120;
                label.Top = 210;
                label.Left = 10;
                Label label1 = new Label();
                label1.Parent = panel;
                label1.AutoSize = true;
                label1.Text = $"{p.UnitPrice:c0}";
                label1.Top = 210;
                label1.Left = 140;
                flowLayoutPanelForProduct.Controls.Add(panel);
            }
        }

        #region 生成詳細商品頁面的表單
        private void PictureBox_Click(object sender, EventArgs e)
        {
            //透過ProductInfoID查詢這個產品的明細
            var qInfo = from n in dbContext.ProductInfoes.AsEnumerable() where n.ProductInfoID == int.Parse(((PictureBox)sender).Tag.ToString()) select n;
            var qP = from n in dbContext.Products.AsEnumerable() where n.ProductInfoID == int.Parse(((PictureBox)sender).Tag.ToString()) select n;

            Form f = new Form();
            f.Width = 520;
            f.Height = 700;
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.Tag = ((PictureBox)sender).Tag;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = ((PictureBox)sender).Image;
            pictureBox.Parent = panel;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = 400;
            pictureBox.Height = 400;
            pictureBox.Top = 50;
            pictureBox.Left = 50;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            Label labelName = new Label();
            labelName.Text = qInfo.ToList()[0].ProductName;
            labelName.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelName.AutoEllipsis = true;
            labelName.Width = 300;
            labelName.Top = 460;
            labelName.Left = 50;
            panel.Controls.Add(labelName);
            Label labelPrice = new Label();
            labelPrice.Text = $"{qInfo.ToList()[0].UnitPrice:c0}";
            labelPrice.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelPrice.AutoSize = true;
            labelPrice.Top = 460;
            labelPrice.Left = 450 - labelPrice.Width;
            panel.Controls.Add(labelPrice);

            //以上完成PictureBox和名字、價錢的設置，往下建立Panel裝尺寸

            Panel panelSize = new Panel();
            panelSize.AutoSize = true;
            panelSize.Height = 50;
            panelSize.Top = 490;
            panelSize.Left = 50;
            Label labelSize = new Label();
            labelSize.Text = "尺寸：";
            labelSize.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelSize.AutoSize = true;
            labelSize.Top = 16;
            panelSize.Controls.Add(labelSize);
            var sizes = qP.Select(n => n.Size.SizeName).Distinct().ToList();
            sizes = OrderBySize(sizes);
            for (int i = 0; i < sizes.Count; i++)
            {
                Label lbl = new Label();
                lbl.Width = 50;
                lbl.Height = 50;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Text = sizes[i];
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Location = new Point(70 + 60 * i, 0);
                lbl.Click += Lbl_Click;
                panelSize.Controls.Add(lbl);
            }
            panel.Controls.Add(panelSize);

            //建立Panel裝顏色

            Panel panelColor = new Panel();
            panelColor.AutoSize = true;
            panelColor.Height = 50;
            panelColor.Top = 550;
            panelColor.Left = 50;
            Label labelColor = new Label();
            labelColor.Text = "顏色：";
            labelColor.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelColor.AutoSize = true;
            labelColor.Top = 16;
            panelColor.Controls.Add(labelColor);
            var colors = qP.OrderBy(n=>n.ColorID).Select(n => n.Color.ColorName).Distinct().ToList();
            for (int i = 0; i < colors.Count; i++)
            {
                Label lbl = new Label();
                lbl.Width = 50;
                lbl.Height = 50;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Text = colors[i];
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Location = new Point(70 + 60 * i, 0);
                lbl.Click += Lbl_Click;
                panelColor.Controls.Add(lbl);
            }
            panel.Controls.Add(panelColor);

            //建立Panel裝數量

            Panel panelQuantity = new Panel();
            panelQuantity.AutoSize = true;
            panelQuantity.Height = 30;
            panelQuantity.Top = 610;
            panelQuantity.Left = 50;
            /*Label labelQuantity = new Label();
            labelQuantity.Text = "數量：";
            labelQuantity.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelQuantity.AutoSize = true;
            labelQuantity.Top = 16;
            panelQuantity.Controls.Add(labelQuantity);
            TextBox textBox = new TextBox();
            textBox.Text = "1";
            textBox.Width = 100;
            textBox.Location = new Point(70, 14);
            textBox.KeyPress += TextBox_KeyPress;
            //textBox.Leave += TextBox_Leave;
            panelQuantity.Controls.Add(textBox);*/
            Label labelInStock = new Label();
            labelInStock.Name = "labelInStock";
            labelInStock.Text = $"庫存：{qP.Select(n => n.UnitsinStock).Sum()}";
            labelInStock.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelInStock.AutoSize = true;
            labelInStock.Top = 16;
            //labelInStock.Left = 200;
            panelQuantity.Controls.Add(labelInStock);
            if (CurrentLogin.loginID != Form1.LoginID.Employee)
            {
                Button button = new Button();
                button.Size = new System.Drawing.Size(100, 40);
                button.Text = "前往購物";
                button.Location = new Point(300, 5);
                button.Click += Button_Click;
                panelQuantity.Controls.Add(button);
            }
            panel.Controls.Add(panelQuantity);

            //建立Panel裝描述

            Panel panelDescription = new Panel();
            panelDescription.AutoSize = true;
            panelDescription.Height = 30;
            panelDescription.Top = 650;
            panelDescription.Left = 50;
            Label labelDescription = new Label();
            labelDescription.Text = "描述：";
            labelDescription.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelDescription.AutoSize = true;
            labelDescription.Top = 16;
            panelDescription.Controls.Add(labelDescription);
            TextBox txtDescription = new TextBox();
            txtDescription.Text = qInfo.Select(n => n.ProductDetail).ToList()[0];
            txtDescription.Font = new Font("新細明體", 10, FontStyle.Regular);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Multiline = true;
            txtDescription.ReadOnly = true;
            //txtDescription.AutoSize = true;
            txtDescription.Width = 400;
            txtDescription.Height = 200;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Top = 48;
            panelDescription.Controls.Add(txtDescription);
            panel.Controls.Add(panelDescription);

            //建立Panel裝評論

            Panel panelComment = new Panel();
            panelComment.AutoSize = true;
            panelComment.Height = 30;
            panelComment.Top = 900;
            panelComment.Left = 50;
            panelComment.Margin = new Padding(0, 0, 0, 30);
            Label labelComment = new Label();
            labelComment.Text = "評論：";
            labelComment.Font = new Font("新細明體", 12, FontStyle.Bold);
            labelComment.AutoSize = true;
            labelComment.Top = 16;
            panelComment.Controls.Add(labelComment);
            /*TextBox txtComment = new TextBox();
            txtComment.Text = "暫無評論";// todo 2 實際上就是施工中，但是我又不想明講
            txtComment.Font = new Font("新細明體", 10, FontStyle.Regular);
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Multiline = true;
            txtComment.ReadOnly = true;
            txtComment.Width = 400;
            txtComment.Height = 200;
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Top = 48;
            panelComment.Controls.Add(txtComment);*/
            DataGridView dataGridView = new DataGridView();
            //dataGridView.DataSource = from n in dbContext.Comments where n.Product.ProductInfo.ProductInfoID == (int)panel.Tag select n;
            dataGridView.Width = 400;
            dataGridView.Height = 200;
            dataGridView.Top = 48;
            panelComment.Controls.Add(dataGridView);
            panel.Controls.Add(panelComment);

            f.Controls.Add(panel);
            var qC = from n in dbContext.Comments.AsEnumerable() where n.Product.ProductInfo.ProductInfoID == int.Parse(panel.Tag.ToString())
                     select new
                     {
                         會員 = n.Member.NickName,
                         內容 = n.Description,
                         星等 = n.Star,
                         尺寸 = n.Product.Size.SizeName,
                         顏色 = n.Product.Color.ColorName,
                         評論日期 = n.CommentDate,
                         照片 = n.CommentPicture,
                     };
            dataGridView.DataSource = qC.ToList();
            if (f.ShowDialog()==DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
            }

        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            foreach (object o in ((Label)sender).Parent.Controls)
            {
                if (o is Label)
                {
                    if ((Label)o == (Label)sender)
                    {
                        if (((Label)sender).BackColor == myColor)
                        {
                            ((Label)sender).BackColor = System.Drawing.Color.Transparent;
                        }
                        else
                        {
                            ((Label)sender).BackColor = myColor;
                        }
                    }
                    else
                    {
                        ((Label)o).BackColor = System.Drawing.Color.Transparent;
                    }
                }
            }
            string size = "none";
            string color = "none";
            IEnumerable<Product> q = from n in dbContext.Products.AsEnumerable() where n.ProductInfoID == int.Parse(((Label)sender).Parent.Parent.Tag.ToString()) select n;
            foreach (object o in ((Label)sender).Parent.Parent.Controls)
            {
                if (o is Panel)
                {
                    foreach (object o1 in ((Panel)o).Controls)
                    {
                        if (o1 is Label)
                        {
                            if (((Label)((Label)o1).Parent.Controls[0]).Text == "尺寸：" && ((Label)o1).BackColor == myColor)
                            {
                                size = ((Label)o1).Text;
                                q = q.Where(n => n.Size.SizeName == size);
                            }
                            else if (((Label)((Label)o1).Parent.Controls[0]).Text == "顏色：" && ((Label)o1).BackColor == myColor)
                            {
                                color = ((Label)o1).Text;
                                q = q.Where(n => n.Color.ColorName == color);
                            }
                            else if (((Label)((Label)o1).Parent.Controls[0]).Text.Substring(0, 3) == "庫存：")
                            {
                                ((Label)o1).Text = $"庫存：{q.Select(n => n.UnitsinStock).Sum()}";
                            }
                        }
                        /*else if (o1 is TextBox)
                        {
                            ((TextBox)o1).Text = "1";
                            ((TextBox)o1).SelectionStart = ((TextBox)o1).Text.Length;
                            ((Panel)o).Controls["labelInStock"].Text = $"庫存：{q.Select(n => n.UnitsinStock).Sum()}";
                            ChangeEnabled(sender, size, color);
                            return;
                        }*/
                        /*if (o1 is DataGridView)
                        {
                            var qC = from n in dbContext.Comments where n.Product.ProductInfo.ProductInfoID == 1 select n;
                            ((DataGridView)o1).DataSource = qC.ToList();
                        }*/
                    }
                }
            }

            ChangeEnabled(sender, size, color);
        }

        private void ChangeEnabled(object sender, string size, string color)
        {
            IEnumerable<Product> q = from n in dbContext.Products.AsEnumerable() where n.ProductInfoID == int.Parse(((Label)sender).Parent.Parent.Tag.ToString()) select n;
            foreach (object o in ((Label)sender).Parent.Parent.Controls)
            {
                if (o is Panel)
                {
                    foreach (object o1 in ((Panel)o).Controls)
                    {
                        if (o1 is Label)
                        {
                            if (((Label)((Label)o1).Parent.Controls[0]).Text == "顏色：")
                            {
                                if (size != "none")
                                {
                                    var q1 = q.Where(n => n.Size.SizeName == size).Select(n => n.Color.ColorName).ToList();
                                    if (((Label)o1).Text != "顏色：")
                                    {
                                        ((Label)o1).Enabled = false;
                                    }
                                    foreach (string s in q1)
                                    {
                                        if (((Label)o1).Text == s)
                                        {
                                            ((Label)o1).Enabled = true;
                                        }
                                    }
                                }
                                else
                                {
                                    ((Label)o1).Enabled = true;
                                }
                            }
                            else if (((Label)((Label)o1).Parent.Controls[0]).Text == "尺寸：")
                            {
                                if (color != "none")
                                {
                                    var q1 = q.Where(n => n.Color.ColorName == color).Select(n => n.Size.SizeName).ToList();
                                    if (((Label)o1).Text != "尺寸：")
                                    {
                                        ((Label)o1).Enabled = false;
                                    }
                                    foreach (string s in q1)
                                    {
                                        if (((Label)o1).Text == s)
                                        {
                                            ((Label)o1).Enabled = true;
                                        }
                                    }
                                }
                                else
                                {
                                    ((Label)o1).Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
