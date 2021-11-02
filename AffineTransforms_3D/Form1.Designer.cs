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
            this.figures_box.FormattingEnabled = true;
            this.figures_box.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 858);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.figures_box);
            this.Controls.Add(this.proj_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showFigure_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button showFigure_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox proj_box;
        private System.Windows.Forms.ComboBox figures_box;
        private System.Windows.Forms.Button clear_btn;
    }
}

