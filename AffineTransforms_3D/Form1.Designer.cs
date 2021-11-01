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
            this.figures_box = new System.Windows.Forms.ListBox();
            this.showFigure_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // figures_box
            // 
            this.figures_box.BackColor = System.Drawing.SystemColors.Menu;
            this.figures_box.FormattingEnabled = true;
            this.figures_box.ItemHeight = 16;
            this.figures_box.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
            this.figures_box.Location = new System.Drawing.Point(13, 26);
            this.figures_box.Name = "figures_box";
            this.figures_box.Size = new System.Drawing.Size(111, 52);
            this.figures_box.TabIndex = 0;
            // 
            // showFigure_btn
            // 
            this.showFigure_btn.Location = new System.Drawing.Point(12, 85);
            this.showFigure_btn.Name = "showFigure_btn";
            this.showFigure_btn.Size = new System.Drawing.Size(112, 29);
            this.showFigure_btn.TabIndex = 1;
            this.showFigure_btn.Text = "Отобразить";
            this.showFigure_btn.UseVisualStyleBackColor = true;
            this.showFigure_btn.Click += new System.EventHandler(this.showFigure_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 858);
            this.Controls.Add(this.showFigure_btn);
            this.Controls.Add(this.figures_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox figures_box;
        private System.Windows.Forms.Button showFigure_btn;
    }
}

