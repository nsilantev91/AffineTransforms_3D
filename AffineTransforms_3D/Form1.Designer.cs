﻿namespace AffineTransforms_3D
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
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxZ1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxY1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxZ2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxY2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.usingLineCheckBox = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Saver = new System.Windows.Forms.Button();
            this.Opener = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // showFigure_btn
            // 
            this.showFigure_btn.Location = new System.Drawing.Point(9, 110);
            this.showFigure_btn.Name = "showFigure_btn";
            this.showFigure_btn.Size = new System.Drawing.Size(155, 29);
            this.showFigure_btn.TabIndex = 1;
            this.showFigure_btn.Text = "Отобразить";
            this.showFigure_btn.UseVisualStyleBackColor = true;
            this.showFigure_btn.Click += new System.EventHandler(this.showFigure_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
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
            this.proj_box.Location = new System.Drawing.Point(9, 70);
            this.proj_box.Name = "proj_box";
            this.proj_box.Size = new System.Drawing.Size(155, 24);
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
            this.figures_box.Location = new System.Drawing.Point(9, 12);
            this.figures_box.Name = "figures_box";
            this.figures_box.Size = new System.Drawing.Size(155, 24);
            this.figures_box.TabIndex = 4;
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(9, 155);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(155, 29);
            this.clear_btn.TabIndex = 5;
            this.clear_btn.Text = "Очистить";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(9, 453);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 25);
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
            this.transformComboBox.Location = new System.Drawing.Point(9, 426);
            this.transformComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.transformComboBox.Name = "transformComboBox";
            this.transformComboBox.Size = new System.Drawing.Size(138, 24);
            this.transformComboBox.TabIndex = 9;
            this.transformComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transform type:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(9, 384);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Angle";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "X";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(9, 263);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(37, 22);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "1";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Y";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(51, 263);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(37, 22);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "1";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Z";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(92, 263);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(37, 22);
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
            this.planeComboBox.Location = new System.Drawing.Point(9, 222);
            this.planeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.planeComboBox.Name = "planeComboBox";
            this.planeComboBox.Size = new System.Drawing.Size(138, 24);
            this.planeComboBox.TabIndex = 18;
            this.planeComboBox.SelectedIndexChanged += new System.EventHandler(this.planeComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Coordinate plane:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // centerFigureCheckBox
            // 
            this.centerFigureCheckBox.AutoSize = true;
            this.centerFigureCheckBox.Location = new System.Drawing.Point(11, 310);
            this.centerFigureCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.centerFigureCheckBox.Name = "centerFigureCheckBox";
            this.centerFigureCheckBox.Size = new System.Drawing.Size(18, 17);
            this.centerFigureCheckBox.TabIndex = 20;
            this.centerFigureCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.centerFigureCheckBox.UseVisualStyleBackColor = true;
            this.centerFigureCheckBox.CheckedChanged += new System.EventHandler(this.centerFigureCheckBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(42, 298);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(105, 69);
            this.textBox5.TabIndex = 22;
            this.textBox5.Text = "Transform relative to the center of the figure";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(169, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(678, 520);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(993, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Z1";
            // 
            // textBoxZ1
            // 
            this.textBoxZ1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxZ1.Location = new System.Drawing.Point(996, 101);
            this.textBoxZ1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxZ1.Name = "textBoxZ1";
            this.textBoxZ1.Size = new System.Drawing.Size(37, 22);
            this.textBoxZ1.TabIndex = 28;
            this.textBoxZ1.Text = "0";
            this.textBoxZ1.TextChanged += new System.EventHandler(this.textBoxZ1_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(951, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Y1";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBoxY1
            // 
            this.textBoxY1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxY1.Location = new System.Drawing.Point(954, 101);
            this.textBoxY1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(37, 22);
            this.textBoxY1.TabIndex = 26;
            this.textBoxY1.Text = "0";
            this.textBoxY1.TextChanged += new System.EventHandler(this.textBoxY1_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(909, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "X1";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxX1.Location = new System.Drawing.Point(912, 101);
            this.textBoxX1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(37, 22);
            this.textBoxX1.TabIndex = 24;
            this.textBoxX1.Text = "0";
            this.textBoxX1.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(993, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Z2";
            // 
            // textBoxZ2
            // 
            this.textBoxZ2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxZ2.Location = new System.Drawing.Point(996, 162);
            this.textBoxZ2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxZ2.Name = "textBoxZ2";
            this.textBoxZ2.Size = new System.Drawing.Size(37, 22);
            this.textBoxZ2.TabIndex = 34;
            this.textBoxZ2.Text = "1";
            this.textBoxZ2.TextChanged += new System.EventHandler(this.textBoxZ2_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(951, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Y2";
            // 
            // textBoxY2
            // 
            this.textBoxY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxY2.Location = new System.Drawing.Point(954, 162);
            this.textBoxY2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(37, 22);
            this.textBoxY2.TabIndex = 32;
            this.textBoxY2.Text = "1";
            this.textBoxY2.TextChanged += new System.EventHandler(this.textBoxY2_TextChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(909, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 17);
            this.label14.TabIndex = 31;
            this.label14.Text = "X2";
            // 
            // textBoxX2
            // 
            this.textBoxX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxX2.Location = new System.Drawing.Point(912, 162);
            this.textBoxX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(37, 22);
            this.textBoxX2.TabIndex = 30;
            this.textBoxX2.Text = "1";
            this.textBoxX2.TextChanged += new System.EventHandler(this.textBoxX2_TextChanged);
            // 
            // usingLineCheckBox
            // 
            this.usingLineCheckBox.AutoSize = true;
            this.usingLineCheckBox.Location = new System.Drawing.Point(870, 206);
            this.usingLineCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usingLineCheckBox.Name = "usingLineCheckBox";
            this.usingLineCheckBox.Size = new System.Drawing.Size(163, 21);
            this.usingLineCheckBox.TabIndex = 36;
            this.usingLineCheckBox.Text = "using line for rotation";
            this.usingLineCheckBox.UseVisualStyleBackColor = true;
            this.usingLineCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Figure";
            // 
            // Saver
            // 
            this.Saver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Saver.Location = new System.Drawing.Point(895, 453);
            this.Saver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Saver.Name = "Saver";
            this.Saver.Size = new System.Drawing.Size(138, 25);
            this.Saver.TabIndex = 37;
            this.Saver.Text = "Save";
            this.Saver.UseVisualStyleBackColor = true;
            this.Saver.Click += new System.EventHandler(this.Saver_Click);
            // 
            // Opener
            // 
            this.Opener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Opener.Location = new System.Drawing.Point(895, 482);
            this.Opener.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Opener.Name = "Opener";
            this.Opener.Size = new System.Drawing.Size(138, 25);
            this.Opener.TabIndex = 38;
            this.Opener.Text = "Open";
            this.Opener.UseVisualStyleBackColor = true;
            this.Opener.Click += new System.EventHandler(this.Opener_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1054, 550);
            this.Controls.Add(this.Opener);
            this.Controls.Add(this.Saver);
            this.Controls.Add(this.usingLineCheckBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxZ2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxY2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxZ1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxY1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxX1);
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxZ1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxZ2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxY2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.CheckBox usingLineCheckBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Saver;
        private System.Windows.Forms.Button Opener;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

