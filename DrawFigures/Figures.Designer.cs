namespace DrawFigures
{
    partial class Figures
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
            this.DrawButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clearField = new System.Windows.Forms.Button();
            this.lineRadioButton = new System.Windows.Forms.RadioButton();
            this.squareRadioButton = new System.Windows.Forms.RadioButton();
            this.triangleRadioButton = new System.Windows.Forms.RadioButton();
            this.rectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.circleRadioButton = new System.Windows.Forms.RadioButton();
            this.ellipseRadioButton = new System.Windows.Forms.RadioButton();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(665, 412);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(102, 25);
            this.DrawButton.TabIndex = 0;
            this.DrawButton.Text = "Все фигуры";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(875, 394);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // clearField
            // 
            this.clearField.Location = new System.Drawing.Point(773, 412);
            this.clearField.Name = "clearField";
            this.clearField.Size = new System.Drawing.Size(102, 23);
            this.clearField.TabIndex = 8;
            this.clearField.Text = "Очистить";
            this.clearField.UseVisualStyleBackColor = true;
            this.clearField.Click += new System.EventHandler(this.clearField_Click);
            // 
            // lineRadioButton
            // 
            this.lineRadioButton.AutoSize = true;
            this.lineRadioButton.Location = new System.Drawing.Point(18, 418);
            this.lineRadioButton.Name = "lineRadioButton";
            this.lineRadioButton.Size = new System.Drawing.Size(57, 17);
            this.lineRadioButton.TabIndex = 9;
            this.lineRadioButton.TabStop = true;
            this.lineRadioButton.Text = "Линия";
            this.lineRadioButton.UseVisualStyleBackColor = true;
            // 
            // squareRadioButton
            // 
            this.squareRadioButton.AutoSize = true;
            this.squareRadioButton.Location = new System.Drawing.Point(81, 418);
            this.squareRadioButton.Name = "squareRadioButton";
            this.squareRadioButton.Size = new System.Drawing.Size(67, 17);
            this.squareRadioButton.TabIndex = 10;
            this.squareRadioButton.TabStop = true;
            this.squareRadioButton.Text = "Квадрат";
            this.squareRadioButton.UseVisualStyleBackColor = true;
            // 
            // triangleRadioButton
            // 
            this.triangleRadioButton.AutoSize = true;
            this.triangleRadioButton.Location = new System.Drawing.Point(154, 418);
            this.triangleRadioButton.Name = "triangleRadioButton";
            this.triangleRadioButton.Size = new System.Drawing.Size(90, 17);
            this.triangleRadioButton.TabIndex = 11;
            this.triangleRadioButton.TabStop = true;
            this.triangleRadioButton.Text = "Треугольник";
            this.triangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // rectangleRadioButton
            // 
            this.rectangleRadioButton.AutoSize = true;
            this.rectangleRadioButton.Location = new System.Drawing.Point(250, 418);
            this.rectangleRadioButton.Name = "rectangleRadioButton";
            this.rectangleRadioButton.Size = new System.Drawing.Size(105, 17);
            this.rectangleRadioButton.TabIndex = 12;
            this.rectangleRadioButton.TabStop = true;
            this.rectangleRadioButton.Text = "Прямоугольник";
            this.rectangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // circleRadioButton
            // 
            this.circleRadioButton.AutoSize = true;
            this.circleRadioButton.Location = new System.Drawing.Point(361, 418);
            this.circleRadioButton.Name = "circleRadioButton";
            this.circleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.circleRadioButton.TabIndex = 13;
            this.circleRadioButton.TabStop = true;
            this.circleRadioButton.Text = "Круг";
            this.circleRadioButton.UseVisualStyleBackColor = true;
            // 
            // ellipseRadioButton
            // 
            this.ellipseRadioButton.AutoSize = true;
            this.ellipseRadioButton.Location = new System.Drawing.Point(415, 418);
            this.ellipseRadioButton.Name = "ellipseRadioButton";
            this.ellipseRadioButton.Size = new System.Drawing.Size(62, 17);
            this.ellipseRadioButton.TabIndex = 14;
            this.ellipseRadioButton.TabStop = true;
            this.ellipseRadioButton.Text = "Эллипс";
            this.ellipseRadioButton.UseVisualStyleBackColor = true;
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.Gray;
            this.colorBox.Location = new System.Drawing.Point(499, 412);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(127, 24);
            this.colorBox.TabIndex = 15;
            this.colorBox.TabStop = false;
            this.colorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // Figures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 450);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.ellipseRadioButton);
            this.Controls.Add(this.circleRadioButton);
            this.Controls.Add(this.rectangleRadioButton);
            this.Controls.Add(this.triangleRadioButton);
            this.Controls.Add(this.squareRadioButton);
            this.Controls.Add(this.lineRadioButton);
            this.Controls.Add(this.clearField);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DrawButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Figures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shapes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Figures_FormClosing);
            this.Load += new System.EventHandler(this.Figures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button clearField;
        private System.Windows.Forms.RadioButton lineRadioButton;
        private System.Windows.Forms.RadioButton squareRadioButton;
        private System.Windows.Forms.RadioButton triangleRadioButton;
        private System.Windows.Forms.RadioButton rectangleRadioButton;
        private System.Windows.Forms.RadioButton circleRadioButton;
        private System.Windows.Forms.RadioButton ellipseRadioButton;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

