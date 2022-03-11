
namespace WindowsFormsApp1
{
    partial class 商品更新視窗
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DTPakerProductDate = new System.Windows.Forms.DateTimePicker();
            this.chBDisplay = new System.Windows.Forms.CheckBox();
            this.picBProductPhoto = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIngredient = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStorelD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubCategoryID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductInfo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBProductPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 20);
            this.button1.TabIndex = 46;
            this.button1.Text = "載入圖片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 28);
            this.button2.TabIndex = 45;
            this.button2.Text = "更新資料";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DTPakerProductDate
            // 
            this.DTPakerProductDate.Location = new System.Drawing.Point(324, 336);
            this.DTPakerProductDate.Name = "DTPakerProductDate";
            this.DTPakerProductDate.Size = new System.Drawing.Size(150, 22);
            this.DTPakerProductDate.TabIndex = 44;
            // 
            // chBDisplay
            // 
            this.chBDisplay.AutoSize = true;
            this.chBDisplay.Location = new System.Drawing.Point(572, 59);
            this.chBDisplay.Name = "chBDisplay";
            this.chBDisplay.Size = new System.Drawing.Size(15, 14);
            this.chBDisplay.TabIndex = 43;
            this.chBDisplay.UseVisualStyleBackColor = true;
            // 
            // picBProductPhoto
            // 
            this.picBProductPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBProductPhoto.Location = new System.Drawing.Point(572, 88);
            this.picBProductPhoto.Name = "picBProductPhoto";
            this.picBProductPhoto.Size = new System.Drawing.Size(174, 106);
            this.picBProductPhoto.TabIndex = 42;
            this.picBProductPhoto.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(491, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 41;
            this.label7.Text = "ProductPhoto:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "ProductDate:";
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(320, 293);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(127, 22);
            this.txtSupplierID.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(234, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "SupplierID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "Display:";
            // 
            // txtIngredient
            // 
            this.txtIngredient.Location = new System.Drawing.Point(320, 251);
            this.txtIngredient.Name = "txtIngredient";
            this.txtIngredient.Size = new System.Drawing.Size(127, 22);
            this.txtIngredient.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "Ingredient:";
            // 
            // txtStorelD
            // 
            this.txtStorelD.Location = new System.Drawing.Point(320, 212);
            this.txtStorelD.Name = "txtStorelD";
            this.txtStorelD.Size = new System.Drawing.Size(127, 22);
            this.txtStorelD.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "StorelD:";
            // 
            // txtProductDetail
            // 
            this.txtProductDetail.Location = new System.Drawing.Point(320, 172);
            this.txtProductDetail.Name = "txtProductDetail";
            this.txtProductDetail.Size = new System.Drawing.Size(127, 22);
            this.txtProductDetail.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "ProductDetail:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(320, 134);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(127, 22);
            this.txtUnitPrice.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "UnitPrice:";
            // 
            // txtSubCategoryID
            // 
            this.txtSubCategoryID.Location = new System.Drawing.Point(320, 94);
            this.txtSubCategoryID.Name = "txtSubCategoryID";
            this.txtSubCategoryID.Size = new System.Drawing.Size(127, 22);
            this.txtSubCategoryID.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "SubCategoryID:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(320, 56);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(127, 22);
            this.txtProductName.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "ProductName:";
            // 
            // txtProductInfo
            // 
            this.txtProductInfo.Location = new System.Drawing.Point(101, 56);
            this.txtProductInfo.Name = "txtProductInfo";
            this.txtProductInfo.Size = new System.Drawing.Size(127, 22);
            this.txtProductInfo.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 12);
            this.label11.TabIndex = 47;
            this.label11.Text = "ProductInfoID:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // 商品更新視窗
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtProductInfo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DTPakerProductDate);
            this.Controls.Add(this.chBDisplay);
            this.Controls.Add(this.picBProductPhoto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIngredient);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStorelD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProductDetail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubCategoryID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label1);
            this.Name = "商品更新視窗";
            this.Text = "商品更新視窗";
            ((System.ComponentModel.ISupportInitialize)(this.picBProductPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker DTPakerProductDate;
        private System.Windows.Forms.CheckBox chBDisplay;
        private System.Windows.Forms.PictureBox picBProductPhoto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIngredient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStorelD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubCategoryID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}