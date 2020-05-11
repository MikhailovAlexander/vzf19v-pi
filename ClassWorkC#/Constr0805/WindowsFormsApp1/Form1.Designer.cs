namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.circleControl1 = new Constr0805.CircleControl(this.components);
            this.filePathControl2 = new Constr0805.FilePathControl();
            this.filePathControl1 = new Constr0805.FilePathControl();
            this.numberTextBox3 = new Constr0805.NumberTextBox(this.components);
            this.numberTextBox2 = new Constr0805.NumberTextBox(this.components);
            this.numberTextBox1 = new Constr0805.NumberTextBox(this.components);
            this.circleControl2 = new Constr0805.CircleControl(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // circleControl1
            // 
            this.circleControl1.Color = System.Drawing.Color.Black;
            this.circleControl1.Location = new System.Drawing.Point(233, 259);
            this.circleControl1.Name = "circleControl1";
            this.circleControl1.Size = new System.Drawing.Size(75, 59);
            this.circleControl1.TabIndex = 6;
            this.circleControl1.Text = "circleControl1";
            // 
            // filePathControl2
            // 
            this.filePathControl2.FileName = "C\\:";
            this.filePathControl2.Location = new System.Drawing.Point(444, 123);
            this.filePathControl2.Name = "filePathControl2";
            this.filePathControl2.Size = new System.Drawing.Size(242, 22);
            this.filePathControl2.TabIndex = 4;
            // 
            // filePathControl1
            // 
            this.filePathControl1.FileName = "";
            this.filePathControl1.Location = new System.Drawing.Point(444, 69);
            this.filePathControl1.Name = "filePathControl1";
            this.filePathControl1.Size = new System.Drawing.Size(242, 23);
            this.filePathControl1.TabIndex = 3;
            this.filePathControl1.FilePathChanged += new System.EventHandler<System.EventArgs>(this.filePathControl1_FilePathChanged);
            // 
            // numberTextBox3
            // 
            this.numberTextBox3.ForeColor = System.Drawing.Color.Red;
            this.numberTextBox3.Location = new System.Drawing.Point(315, 169);
            this.numberTextBox3.Name = "numberTextBox3";
            this.numberTextBox3.Size = new System.Drawing.Size(100, 22);
            this.numberTextBox3.TabIndex = 2;
            // 
            // numberTextBox2
            // 
            this.numberTextBox2.ForeColor = System.Drawing.Color.Red;
            this.numberTextBox2.Location = new System.Drawing.Point(315, 116);
            this.numberTextBox2.Name = "numberTextBox2";
            this.numberTextBox2.Size = new System.Drawing.Size(100, 22);
            this.numberTextBox2.TabIndex = 1;
            // 
            // numberTextBox1
            // 
            this.numberTextBox1.ForeColor = System.Drawing.Color.Red;
            this.numberTextBox1.Location = new System.Drawing.Point(315, 62);
            this.numberTextBox1.Name = "numberTextBox1";
            this.numberTextBox1.Size = new System.Drawing.Size(100, 22);
            this.numberTextBox1.TabIndex = 0;
            // 
            // circleControl2
            // 
            this.circleControl2.Color = System.Drawing.Color.Red;
            this.circleControl2.Location = new System.Drawing.Point(381, 259);
            this.circleControl2.Name = "circleControl2";
            this.circleControl2.Size = new System.Drawing.Size(75, 59);
            this.circleControl2.TabIndex = 7;
            this.circleControl2.Text = "circleControl2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.circleControl2);
            this.Controls.Add(this.circleControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filePathControl2);
            this.Controls.Add(this.filePathControl1);
            this.Controls.Add(this.numberTextBox3);
            this.Controls.Add(this.numberTextBox2);
            this.Controls.Add(this.numberTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Constr0805.NumberTextBox numberTextBox1;
        private Constr0805.NumberTextBox numberTextBox2;
        private Constr0805.NumberTextBox numberTextBox3;
        private Constr0805.FilePathControl filePathControl1;
        private Constr0805.FilePathControl filePathControl2;
        private System.Windows.Forms.Button button1;
        private Constr0805.CircleControl circleControl1;
        private Constr0805.CircleControl circleControl2;
    }
}

