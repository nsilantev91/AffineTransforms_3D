namespace AffineTransforms_3D
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.showFigure_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.proj_box = new System.Windows.Forms.ComboBox();
            this.figures_box = new System.Windows.Forms.ComboBox();
            this.clear_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.transformComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.planeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.centerFigureCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // showFigure_btn
            // 
            this.showFigure_btn.Location = new System.Drawing.Point(10, 138);
            this.showFigure_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showFigure_btn.Name = "showFigure_btn";
            this.showFigure_btn.Size = new System.Drawing.Size(174, 36);
            this.showFigure_btn.TabIndex = 1;
            this.showFigure_btn.Text = "Отобразить";
            this.showFigure_btn.UseVisualStyleBackColor = true;
            this.showFigure_btn.Click += new System.EventHandler(this.showFigure_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Проекция:";
            // 
            // proj_box
            // 
            this.proj_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.proj_box.FormattingEnabled = true;
            this.proj_box.Items.AddRange(new object[] {
            "Перспективная",
            "Изометрическая",
            "Триметрическая",
            "Диметрическая"});
            this.proj_box.Location = new System.Drawing.Point(10, 88);
            this.proj_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.proj_box.Name = "proj_box";
            this.proj_box.Size = new System.Drawing.Size(174, 28);
            this.proj_box.TabIndex = 3;
            this.proj_box.SelectedIndexChanged += new System.EventHandler(this.proj_box_SelectedIndexChanged);
            // 
            // figures_box
            // 
            this.figures_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figures_box.FormattingEnabled = true;
            this.figures_box.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр",
            "Икосаэдр",
            "Додэкаэдр"});
            this.figures_box.Location = new System.Drawing.Point(10, 15);
            this.figures_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.figures_box.Name = "figures_box";
            this.figures_box.Size = new System.Drawing.Size(174, 28);
            this.figures_box.TabIndex = 4;
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(10, 194);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(174, 36);
            this.clear_btn.TabIndex = 5;
            this.clear_btn.Text = "Очистить";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(10, 583);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "Transform";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // transformComboBox
            // 
            this.transformComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.transformComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transformComboBox.FormattingEnabled = true;
            this.transformComboBox.Items.AddRange(new object[] {
            "Transposition",
            "Rotate",
            "Scale",
            "Reflect"});
            this.transformComboBox.Location = new System.Drawing.Point(10, 549);
            this.transformComboBox.Name = "transformComboBox";
            this.transformComboBox.Size = new System.Drawing.Size(155, 28);
            this.transformComboBox.TabIndex = 9;
            this.transformComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 529);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transform type:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(10, 497);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 26);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Angle";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "X";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(10, 346);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 26);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "1";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Y";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(57, 346);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(41, 26);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "1";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Z";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(104, 346);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(41, 26);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "1";
            // 
            // planeComboBox
            // 
            this.planeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.planeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.planeComboBox.FormattingEnabled = true;
            this.planeComboBox.Items.AddRange(new object[] {
            "XY",
            "XZ",
            "YZ"});
            this.planeComboBox.Location = new System.Drawing.Point(10, 295);
            this.planeComboBox.Name = "planeComboBox";
            this.planeComboBox.Size = new System.Drawing.Size(155, 28);
            this.planeComboBox.TabIndex = 18;
            this.planeComboBox.SelectedIndexChanged += new System.EventHandler(this.planeComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Coordinate plane:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // centerFigureCheckBox
            // 
            this.centerFigureCheckBox.AutoSize = true;
            this.centerFigureCheckBox.Location = new System.Drawing.Point(12, 388);
            this.centerFigureCheckBox.Name = "centerFigureCheckBox";
            this.centerFigureCheckBox.Size = new System.Drawing.Size(22, 21);
            this.centerFigureCheckBox.TabIndex = 20;
            this.centerFigureCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.centerFigureCheckBox.UseVisualStyleBackColor = true;
            this.centerFigureCheckBox.CheckedChanged += new System.EventHandler(this.centerFigureCheckBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 389);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(47, 386);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(118, 75);
            this.textBox5.TabIndex = 22;
            this.textBox5.Text = "Scale relative to the center of the figure";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(199, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1233, 677);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1444, 704);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.centerFigureCheckBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.planeComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.transformComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.figures_box);
            this.Controls.Add(this.proj_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showFigure_btn);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button showFigure_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox proj_box;
        private System.Windows.Forms.ComboBox figures_box;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox transformComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox planeComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox centerFigureCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

