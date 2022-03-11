
namespace 專題
{
    partial class 編輯員工職位
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
            this.txtPositionName = new System.Windows.Forms.TextBox();
            this.txtPositionID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPositionName
            // 
            this.txtPositionName.Location = new System.Drawing.Point(177, 55);
            this.txtPositionName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Size = new System.Drawing.Size(148, 27);
            this.txtPositionName.TabIndex = 24;
            // 
            // txtPositionID
            // 
            this.txtPositionID.Location = new System.Drawing.Point(177, 9);
            this.txtPositionID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPositionID.Name = "txtPositionID";
            this.txtPositionID.Size = new System.Drawing.Size(148, 27);
            this.txtPositionID.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 16F);
            this.label7.Location = new System.Drawing.Point(15, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 22);
            this.label7.TabIndex = 22;
            this.label7.Text = "PositionName :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 16F);
            this.label6.Location = new System.Drawing.Point(42, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "PositionID :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 120);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 25;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 120);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 31);
            this.button2.TabIndex = 26;
            this.button2.Text = "編輯";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 120);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 31);
            this.button3.TabIndex = 27;
            this.button3.Text = "刪除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // 編輯員工職位
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 165);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPositionName);
            this.Controls.Add(this.txtPositionID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "編輯員工職位";
            this.Text = "編輯員工職位";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPositionName;
        private System.Windows.Forms.TextBox txtPositionID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}