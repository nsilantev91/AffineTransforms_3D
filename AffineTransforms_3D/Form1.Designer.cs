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
            this.label15 = new System.Windows.Forms.Label();
            this.forming_z_box = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.forming_y_box = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.forming_x_box = new System.Windows.Forms.TextBox();
            this.add_point_btn = new System.Windows.Forms.Button();
            this.axis_box = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.num_parts_box = new System.Windows.Forms.TextBox();
            this.create_fig_btn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Saver = new System.Windows.Forms.Button();
            this.Opener = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label19 = new System.Windows.Forms.Label();
            this.funComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.y1FunTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.x1FunTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.y0FunTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.x0FunTextBox = new System.Windows.Forms.TextBox();
            this.stepCountTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.zBuf_check_btn = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.vectorZtextBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.vectorYtextBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.vectorXtextBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cameraZTextBox = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cameraYTextBox = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cameraXTextBox = new System.Windows.Forms.TextBox();
            this.zFarTextBox = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.zNearTextBox = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.fovYtextBox = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.fovXtextBox = new System.Windows.Forms.TextBox();
            this.rotateCameraButton = new System.Windows.Forms.Button();
            this.RemoveEdges = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
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
            "Додэкаэдр",
            "Пользовательская",
            "График",
            "Плавающий горизонт"});
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
            this.button2.Location = new System.Drawing.Point(8, 517);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "Transform";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.transformButton_Click);
            // 
            // transformComboBox
            // 
            this.transformComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transformComboBox.FormattingEnabled = true;
            this.transformComboBox.Items.AddRange(new object[] {
            "Transposition",
            "Rotate",
            "Scale",
            "Reflect"});
            this.transformComboBox.Location = new System.Drawing.Point(8, 489);
            this.transformComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.transformComboBox.Name = "transformComboBox";
            this.transformComboBox.Size = new System.Drawing.Size(165, 24);
            this.transformComboBox.TabIndex = 9;
            this.transformComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transform type:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(10, 447);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Angle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "X";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(8, 335);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(37, 22);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Y";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(51, 335);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(37, 22);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Z";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(94, 335);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(37, 22);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "1";
            // 
            // planeComboBox
            // 
            this.planeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.planeComboBox.FormattingEnabled = true;
            this.planeComboBox.Items.AddRange(new object[] {
            "XY",
            "XZ",
            "YZ"});
            this.planeComboBox.Location = new System.Drawing.Point(9, 290);
            this.planeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.planeComboBox.Name = "planeComboBox";
            this.planeComboBox.Size = new System.Drawing.Size(162, 24);
            this.planeComboBox.TabIndex = 18;
            this.planeComboBox.SelectedIndexChanged += new System.EventHandler(this.planeComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Coordinate plane:";
            // 
            // centerFigureCheckBox
            // 
            this.centerFigureCheckBox.AutoSize = true;
            this.centerFigureCheckBox.Location = new System.Drawing.Point(26, 391);
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
            this.label8.Location = new System.Drawing.Point(47, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(50, 361);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(105, 69);
            this.textBox5.TabIndex = 22;
            this.textBox5.Text = "Transform relative to the center of the figure";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(186, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(688, 520);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1155, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Z1";
            // 
            // textBoxZ1
            // 
            this.textBoxZ1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxZ1.Location = new System.Drawing.Point(1159, 34);
            this.textBoxZ1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxZ1.Name = "textBoxZ1";
            this.textBoxZ1.Size = new System.Drawing.Size(37, 22);
            this.textBoxZ1.TabIndex = 28;
            this.textBoxZ1.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1108, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Y1";
            // 
            // textBoxY1
            // 
            this.textBoxY1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxY1.Location = new System.Drawing.Point(1112, 34);
            this.textBoxY1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(37, 22);
            this.textBoxY1.TabIndex = 26;
            this.textBoxY1.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1061, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "X1";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxX1.Location = new System.Drawing.Point(1064, 34);
            this.textBoxX1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(37, 22);
            this.textBoxX1.TabIndex = 24;
            this.textBoxX1.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1155, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Z2";
            // 
            // textBoxZ2
            // 
            this.textBoxZ2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxZ2.Location = new System.Drawing.Point(1159, 111);
            this.textBoxZ2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxZ2.Name = "textBoxZ2";
            this.textBoxZ2.Size = new System.Drawing.Size(37, 22);
            this.textBoxZ2.TabIndex = 34;
            this.textBoxZ2.Text = "1";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1108, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Y2";
            // 
            // textBoxY2
            // 
            this.textBoxY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxY2.Location = new System.Drawing.Point(1112, 111);
            this.textBoxY2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(37, 22);
            this.textBoxY2.TabIndex = 32;
            this.textBoxY2.Text = "1";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1061, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 17);
            this.label14.TabIndex = 31;
            this.label14.Text = "X2";
            // 
            // textBoxX2
            // 
            this.textBoxX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxX2.Location = new System.Drawing.Point(1064, 111);
            this.textBoxX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(37, 22);
            this.textBoxX2.TabIndex = 30;
            this.textBoxX2.Text = "1";
            // 
            // usingLineCheckBox
            // 
            this.usingLineCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usingLineCheckBox.AutoSize = true;
            this.usingLineCheckBox.Location = new System.Drawing.Point(1064, 145);
            this.usingLineCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usingLineCheckBox.Name = "usingLineCheckBox";
            this.usingLineCheckBox.Size = new System.Drawing.Size(163, 21);
            this.usingLineCheckBox.TabIndex = 36;
            this.usingLineCheckBox.Text = "using line for rotation";
            this.usingLineCheckBox.UseVisualStyleBackColor = true;
            this.usingLineCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1155, 227);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 17);
            this.label15.TabIndex = 42;
            this.label15.Text = "Z";
            // 
            // forming_z_box
            // 
            this.forming_z_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.forming_z_box.Location = new System.Drawing.Point(1159, 247);
            this.forming_z_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.forming_z_box.Name = "forming_z_box";
            this.forming_z_box.Size = new System.Drawing.Size(37, 22);
            this.forming_z_box.TabIndex = 41;
            this.forming_z_box.Text = "0";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(-16, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 17);
            this.label16.TabIndex = 84;
            // 
            // forming_y_box
            // 
            this.forming_y_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.forming_y_box.Location = new System.Drawing.Point(1112, 247);
            this.forming_y_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.forming_y_box.Name = "forming_y_box";
            this.forming_y_box.Size = new System.Drawing.Size(37, 22);
            this.forming_y_box.TabIndex = 39;
            this.forming_y_box.Text = "0";
            this.forming_y_box.TextChanged += new System.EventHandler(this.forming_y_box_TextChanged);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1061, 227);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 17);
            this.label17.TabIndex = 38;
            this.label17.Text = "X";
            // 
            // forming_x_box
            // 
            this.forming_x_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.forming_x_box.Location = new System.Drawing.Point(1064, 247);
            this.forming_x_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.forming_x_box.Name = "forming_x_box";
            this.forming_x_box.Size = new System.Drawing.Size(37, 22);
            this.forming_x_box.TabIndex = 37;
            this.forming_x_box.Text = "0";
            // 
            // add_point_btn
            // 
            this.add_point_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_point_btn.Location = new System.Drawing.Point(1064, 293);
            this.add_point_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_point_btn.Name = "add_point_btn";
            this.add_point_btn.Size = new System.Drawing.Size(138, 25);
            this.add_point_btn.TabIndex = 43;
            this.add_point_btn.Text = "Add point";
            this.add_point_btn.UseVisualStyleBackColor = true;
            this.add_point_btn.Click += new System.EventHandler(this.add_point_btn_Click);
            // 
            // axis_box
            // 
            this.axis_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.axis_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.axis_box.FormattingEnabled = true;
            this.axis_box.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
            this.axis_box.Location = new System.Drawing.Point(1064, 344);
            this.axis_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axis_box.Name = "axis_box";
            this.axis_box.Size = new System.Drawing.Size(138, 24);
            this.axis_box.TabIndex = 44;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1061, 385);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 17);
            this.label18.TabIndex = 46;
            this.label18.Text = "Number of partitions";
            // 
            // num_parts_box
            // 
            this.num_parts_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_parts_box.Enabled = false;
            this.num_parts_box.Location = new System.Drawing.Point(1112, 409);
            this.num_parts_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num_parts_box.Name = "num_parts_box";
            this.num_parts_box.Size = new System.Drawing.Size(64, 22);
            this.num_parts_box.TabIndex = 45;
            this.num_parts_box.Text = "0";
            this.num_parts_box.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // create_fig_btn
            // 
            this.create_fig_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.create_fig_btn.Enabled = false;
            this.create_fig_btn.Location = new System.Drawing.Point(1064, 449);
            this.create_fig_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.create_fig_btn.Name = "create_fig_btn";
            this.create_fig_btn.Size = new System.Drawing.Size(138, 25);
            this.create_fig_btn.TabIndex = 47;
            this.create_fig_btn.Text = "Create";
            this.create_fig_btn.UseVisualStyleBackColor = true;
            this.create_fig_btn.Click += new System.EventHandler(this.create_fig_btn_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Figure";
            // 
            // Saver
            // 
            this.Saver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Saver.Location = new System.Drawing.Point(1065, 500);
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
            this.Opener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Opener.Location = new System.Drawing.Point(1065, 536);
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 17);
            this.label19.TabIndex = 48;
            this.label19.Text = "График";
            // 
            // funComboBox
            // 
            this.funComboBox.FormattingEnabled = true;
            this.funComboBox.Items.AddRange(new object[] {
            "x + y",
            "x - y",
            "10*(x/100)*(y/100)",
            "100*Sin(x/100)*Cos(y/100)",
            "100*Sin(x/100)",
            "y = x + z (3D)",
            "y = 100*Sin(x/100)*Cos(z/100)(3D)",
            "y = 10*(x/100)*(z/100)(3D)"});
            this.funComboBox.Location = new System.Drawing.Point(8, 57);
            this.funComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.funComboBox.Name = "funComboBox";
            this.funComboBox.Size = new System.Drawing.Size(163, 24);
            this.funComboBox.TabIndex = 49;
            this.funComboBox.SelectedIndexChanged += new System.EventHandler(this.funComboBox_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(131, 81);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 17);
            this.label20.TabIndex = 57;
            this.label20.Text = "Y1";
            // 
            // y1FunTextBox
            // 
            this.y1FunTextBox.Location = new System.Drawing.Point(134, 97);
            this.y1FunTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.y1FunTextBox.Name = "y1FunTextBox";
            this.y1FunTextBox.Size = new System.Drawing.Size(37, 22);
            this.y1FunTextBox.TabIndex = 56;
            this.y1FunTextBox.Text = "300";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(89, 81);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 17);
            this.label21.TabIndex = 55;
            this.label21.Text = "X1";
            // 
            // x1FunTextBox
            // 
            this.x1FunTextBox.Location = new System.Drawing.Point(92, 97);
            this.x1FunTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.x1FunTextBox.Name = "x1FunTextBox";
            this.x1FunTextBox.Size = new System.Drawing.Size(37, 22);
            this.x1FunTextBox.TabIndex = 54;
            this.x1FunTextBox.Text = "300";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(47, 81);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 17);
            this.label22.TabIndex = 53;
            this.label22.Text = "Y0";
            // 
            // y0FunTextBox
            // 
            this.y0FunTextBox.Location = new System.Drawing.Point(51, 97);
            this.y0FunTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.y0FunTextBox.Name = "y0FunTextBox";
            this.y0FunTextBox.Size = new System.Drawing.Size(37, 22);
            this.y0FunTextBox.TabIndex = 52;
            this.y0FunTextBox.Text = "-200";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(5, 81);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(25, 17);
            this.label23.TabIndex = 51;
            this.label23.Text = "X0";
            // 
            // x0FunTextBox
            // 
            this.x0FunTextBox.Location = new System.Drawing.Point(9, 97);
            this.x0FunTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.x0FunTextBox.Name = "x0FunTextBox";
            this.x0FunTextBox.Size = new System.Drawing.Size(37, 22);
            this.x0FunTextBox.TabIndex = 50;
            this.x0FunTextBox.Text = "-200";
            // 
            // stepCountTextBox
            // 
            this.stepCountTextBox.Location = new System.Drawing.Point(92, 133);
            this.stepCountTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stepCountTextBox.Name = "stepCountTextBox";
            this.stepCountTextBox.Size = new System.Drawing.Size(37, 22);
            this.stepCountTextBox.TabIndex = 58;
            this.stepCountTextBox.Text = "20";
            this.stepCountTextBox.TextChanged += new System.EventHandler(this.stepCountTextBox_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 133);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 17);
            this.label24.TabIndex = 59;
            this.label24.Text = "Step count";
            // 
            // zBuf_check_btn
            // 
            this.zBuf_check_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zBuf_check_btn.AutoSize = true;
            this.zBuf_check_btn.Location = new System.Drawing.Point(1065, 169);
            this.zBuf_check_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zBuf_check_btn.Name = "zBuf_check_btn";
            this.zBuf_check_btn.Size = new System.Drawing.Size(115, 21);
            this.zBuf_check_btn.TabIndex = 60;
            this.zBuf_check_btn.Text = "using ZBuffer";
            this.zBuf_check_btn.UseVisualStyleBackColor = true;
            this.zBuf_check_btn.CheckedChanged += new System.EventHandler(this.zBuf_check_btn_CheckedChanged);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(982, 66);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 17);
            this.label25.TabIndex = 65;
            this.label25.Text = "Z";
            // 
            // vectorZtextBox
            // 
            this.vectorZtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorZtextBox.Location = new System.Drawing.Point(987, 86);
            this.vectorZtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vectorZtextBox.Name = "vectorZtextBox";
            this.vectorZtextBox.Size = new System.Drawing.Size(41, 22);
            this.vectorZtextBox.TabIndex = 64;
            this.vectorZtextBox.Text = "0";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(936, 66);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 17);
            this.label26.TabIndex = 63;
            this.label26.Text = "Y";
            // 
            // vectorYtextBox
            // 
            this.vectorYtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorYtextBox.Location = new System.Drawing.Point(938, 86);
            this.vectorYtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vectorYtextBox.Name = "vectorYtextBox";
            this.vectorYtextBox.Size = new System.Drawing.Size(41, 22);
            this.vectorYtextBox.TabIndex = 62;
            this.vectorYtextBox.Text = "0";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(889, 66);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 17);
            this.label27.TabIndex = 61;
            this.label27.Text = "X";
            // 
            // vectorXtextBox
            // 
            this.vectorXtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorXtextBox.Location = new System.Drawing.Point(889, 86);
            this.vectorXtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vectorXtextBox.Name = "vectorXtextBox";
            this.vectorXtextBox.Size = new System.Drawing.Size(41, 22);
            this.vectorXtextBox.TabIndex = 60;
            this.vectorXtextBox.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(876, -6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(0, 17);
            this.label28.TabIndex = 66;
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(891, 14);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(166, 52);
            this.textBox6.TabIndex = 67;
            this.textBox6.Text = "Вектор направления камеры";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(891, 133);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(166, 52);
            this.textBox7.TabIndex = 74;
            this.textBox7.Text = "Положение камеры";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(982, 185);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 17);
            this.label29.TabIndex = 73;
            this.label29.Text = "Z";
            // 
            // cameraZTextBox
            // 
            this.cameraZTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraZTextBox.Location = new System.Drawing.Point(987, 205);
            this.cameraZTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraZTextBox.Name = "cameraZTextBox";
            this.cameraZTextBox.Size = new System.Drawing.Size(41, 22);
            this.cameraZTextBox.TabIndex = 72;
            this.cameraZTextBox.Text = "300";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(936, 185);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 17);
            this.label30.TabIndex = 71;
            this.label30.Text = "Y";
            // 
            // cameraYTextBox
            // 
            this.cameraYTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraYTextBox.Location = new System.Drawing.Point(938, 205);
            this.cameraYTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraYTextBox.Name = "cameraYTextBox";
            this.cameraYTextBox.Size = new System.Drawing.Size(41, 22);
            this.cameraYTextBox.TabIndex = 70;
            this.cameraYTextBox.Text = "20";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(889, 185);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 17);
            this.label31.TabIndex = 69;
            this.label31.Text = "X";
            // 
            // cameraXTextBox
            // 
            this.cameraXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraXTextBox.Location = new System.Drawing.Point(889, 205);
            this.cameraXTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraXTextBox.Name = "cameraXTextBox";
            this.cameraXTextBox.Size = new System.Drawing.Size(41, 22);
            this.cameraXTextBox.TabIndex = 68;
            this.cameraXTextBox.Text = "20";
            // 
            // zFarTextBox
            // 
            this.zFarTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zFarTextBox.Location = new System.Drawing.Point(889, 270);
            this.zFarTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zFarTextBox.Name = "zFarTextBox";
            this.zFarTextBox.Size = new System.Drawing.Size(41, 22);
            this.zFarTextBox.TabIndex = 75;
            this.zFarTextBox.Text = "600";
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(889, 250);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(38, 17);
            this.label33.TabIndex = 76;
            this.label33.Text = "Z far";
            // 
            // zNearTextBox
            // 
            this.zNearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zNearTextBox.Location = new System.Drawing.Point(938, 270);
            this.zNearTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zNearTextBox.Name = "zNearTextBox";
            this.zNearTextBox.Size = new System.Drawing.Size(41, 22);
            this.zNearTextBox.TabIndex = 77;
            this.zNearTextBox.Text = "300";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(936, 250);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(50, 17);
            this.label32.TabIndex = 78;
            this.label32.Text = "Z near";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(940, 314);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(40, 17);
            this.label34.TabIndex = 82;
            this.label34.Text = "fov Y";
            // 
            // fovYtextBox
            // 
            this.fovYtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fovYtextBox.Location = new System.Drawing.Point(942, 334);
            this.fovYtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fovYtextBox.Name = "fovYtextBox";
            this.fovYtextBox.Size = new System.Drawing.Size(41, 22);
            this.fovYtextBox.TabIndex = 81;
            this.fovYtextBox.Text = "90";
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(893, 314);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(40, 17);
            this.label35.TabIndex = 80;
            this.label35.Text = "fov X";
            // 
            // fovXtextBox
            // 
            this.fovXtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fovXtextBox.Location = new System.Drawing.Point(893, 334);
            this.fovXtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fovXtextBox.Name = "fovXtextBox";
            this.fovXtextBox.Size = new System.Drawing.Size(41, 22);
            this.fovXtextBox.TabIndex = 79;
            this.fovXtextBox.Text = "90";
            // 
            // rotateCameraButton
            // 
            this.rotateCameraButton.Location = new System.Drawing.Point(909, 383);
            this.rotateCameraButton.Name = "rotateCameraButton";
            this.rotateCameraButton.Size = new System.Drawing.Size(98, 34);
            this.rotateCameraButton.TabIndex = 83;
            this.rotateCameraButton.Text = "Вращать";
            this.rotateCameraButton.UseVisualStyleBackColor = true;
            this.rotateCameraButton.Click += new System.EventHandler(this.rotateCameraButton_Click);
            // 
            // RemoveEdges
            // 
            this.RemoveEdges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveEdges.AutoSize = true;
            this.RemoveEdges.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveEdges.Location = new System.Drawing.Point(1065, 194);
            this.RemoveEdges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveEdges.Name = "RemoveEdges";
            this.RemoveEdges.Size = new System.Drawing.Size(128, 21);
            this.RemoveEdges.TabIndex = 85;
            this.RemoveEdges.Text = "remove unseen";
            this.RemoveEdges.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(1108, 227);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(17, 17);
            this.label36.TabIndex = 86;
            this.label36.Text = "Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1624, 1050);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.RemoveEdges);
            this.Controls.Add(this.zBuf_check_btn);
            this.Controls.Add(this.rotateCameraButton);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.fovYtextBox);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.fovXtextBox);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.zNearTextBox);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.zFarTextBox);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.cameraZTextBox);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cameraYTextBox);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.cameraXTextBox);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.vectorZtextBox);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.vectorYtextBox);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.vectorXtextBox);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.stepCountTextBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.y1FunTextBox);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.x1FunTextBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.y0FunTextBox);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.x0FunTextBox);
            this.Controls.Add(this.funComboBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.create_fig_btn);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.num_parts_box);
            this.Controls.Add(this.axis_box);
            this.Controls.Add(this.add_point_btn);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.forming_z_box);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.forming_y_box);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.forming_x_box);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox forming_z_box;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox forming_y_box;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox forming_x_box;
        private System.Windows.Forms.Button add_point_btn;
        private System.Windows.Forms.ComboBox axis_box;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox num_parts_box;
        private System.Windows.Forms.Button create_fig_btn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Saver;
        private System.Windows.Forms.Button Opener;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox funComboBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox y1FunTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox x1FunTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox y0FunTextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox x0FunTextBox;
        private System.Windows.Forms.TextBox stepCountTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox zBuf_check_btn;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox vectorZtextBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox vectorYtextBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox vectorXtextBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox cameraZTextBox;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox cameraYTextBox;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox cameraXTextBox;
        private System.Windows.Forms.TextBox zFarTextBox;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox zNearTextBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox fovYtextBox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox fovXtextBox;
        private System.Windows.Forms.Button rotateCameraButton;
        private System.Windows.Forms.CheckBox RemoveEdges;
        private System.Windows.Forms.Label label36;
    }
}

