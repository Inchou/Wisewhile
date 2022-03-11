
using WindowsFormsApp1;

namespace Test
{
    partial class FrmMemberList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMemberList));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.testDataSet11 = new WindowsFormsApp1.testDataSet1();
            this.memberTableAdapter1 = new WindowsFormsApp1.testDataSet1TableAdapters.MemberTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "會員註冊";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(220, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "設定帳號:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(220, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "設定密碼:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(220, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "電話號碼:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(220, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 27);
            this.label5.TabIndex = 4;
            this.label5.Text = "中文姓名:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(220, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 27);
            this.label6.TabIndex = 5;
            this.label6.Text = "電子信箱:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 674);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(561, 459);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 33;
            this.label17.Text = "身分證明";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(569, 352);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "電話確認";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(561, 303);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 31;
            this.label15.Text = "電子信箱";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(555, 238);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 30;
            this.label14.Text = "密碼格式";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(641, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 27);
            this.button3.TabIndex = 29;
            this.button3.Text = "帳號確認";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(555, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "帳號格式";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(555, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "中文格式";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(355, 449);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(191, 22);
            this.textBox8.TabIndex = 26;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(220, 444);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 27);
            this.label11.TabIndex = 25;
            this.label11.Text = "身分證明:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "男性",
            "女性"});
            this.comboBox1.Location = new System.Drawing.Point(355, 556);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 20);
            this.comboBox1.TabIndex = 24;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(355, 501);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(442, 35);
            this.textBox7.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(220, 501);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 27);
            this.label10.TabIndex = 22;
            this.label10.Text = "居住地址:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(250, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 27);
            this.label9.TabIndex = 17;
            this.label9.Text = "性別";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(585, 634);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 37);
            this.button2.TabIndex = 16;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(248, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 37);
            this.button1.TabIndex = 15;
            this.button1.Text = "註冊";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(355, 345);
            this.textBox6.MaxLength = 10;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(191, 22);
            this.textBox6.TabIndex = 14;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(358, 292);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(191, 22);
            this.textBox5.TabIndex = 13;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(358, 231);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(191, 22);
            this.textBox4.TabIndex = 12;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(358, 171);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(191, 27);
            this.textBox3.TabIndex = 11;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(358, 110);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 30);
            this.textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 47);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 35);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(358, 398);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(191, 22);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(220, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 27);
            this.label8.TabIndex = 7;
            this.label8.Text = "設定暱稱:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(220, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 27);
            this.label7.TabIndex = 6;
            this.label7.Text = "出生日期:";
            // 
            // testDataSet11
            // 
            this.testDataSet11.DataSetName = "testDataSet1";
            this.testDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // memberTableAdapter1
            // 
            this.memberTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmMemberList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1151, 750);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "FrmMemberList";
            this.Text = "會員註冊";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label10;
        private testDataSet1 testDataSet11;
        private WindowsFormsApp1.testDataSet1TableAdapters.MemberTableAdapter memberTableAdapter1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}

