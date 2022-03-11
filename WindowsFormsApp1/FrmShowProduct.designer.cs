
namespace Wisewhile
{
    partial class FrmShowProduct
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.cbxSubCategory = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelForProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(49, 45);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(41, 12);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "分類：";
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(96, 42);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(120, 20);
            this.cbxCategory.TabIndex = 1;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // cbxSubCategory
            // 
            this.cbxSubCategory.FormattingEnabled = true;
            this.cbxSubCategory.Location = new System.Drawing.Point(222, 42);
            this.cbxSubCategory.Name = "cbxSubCategory";
            this.cbxSubCategory.Size = new System.Drawing.Size(120, 20);
            this.cbxSubCategory.TabIndex = 2;
            this.cbxSubCategory.SelectedIndexChanged += new System.EventHandler(this.cbxSubCategory_SelectedIndexChanged);
            // 
            // flowLayoutPanelForProduct
            // 
            this.flowLayoutPanelForProduct.AutoScroll = true;
            this.flowLayoutPanelForProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelForProduct.Location = new System.Drawing.Point(51, 154);
            this.flowLayoutPanelForProduct.Name = "flowLayoutPanelForProduct";
            this.flowLayoutPanelForProduct.Size = new System.Drawing.Size(683, 246);
            this.flowLayoutPanelForProduct.TabIndex = 3;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(49, 81);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(41, 12);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "尺寸：";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(49, 117);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(41, 12);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "顏色：";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(376, 45);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 12);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "價錢：";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(423, 40);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(101, 22);
            this.txtMin.TabIndex = 3;
            this.txtMin.TextChanged += new System.EventHandler(this.txtMin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "~";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(547, 40);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(101, 22);
            this.txtMax.TabIndex = 4;
            this.txtMax.TextChanged += new System.EventHandler(this.txtMax_TextChanged);
            // 
            // FrmShowProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.flowLayoutPanelForProduct);
            this.Controls.Add(this.cbxSubCategory);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.lblCategory);
            this.Name = "FrmShowProduct";
            this.Text = "商品";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.ComboBox cbxSubCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelForProduct;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMax;
    }
}

