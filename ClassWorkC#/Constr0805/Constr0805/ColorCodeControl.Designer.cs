namespace Constr0805
{
    partial class ColorCodeControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorCodeControl));
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.pnlHexOrDec = new System.Windows.Forms.Panel();
            this.rbDec = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.tbrRed = new Constr0805.TextBoxRegex(this.components);
            this.tbrGreen = new Constr0805.TextBoxRegex(this.components);
            this.tbrBlue = new Constr0805.TextBoxRegex(this.components);
            this.lblRed = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.pnlColorCode = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.pnlHexOrDec.SuspendLayout();
            this.pnlColorCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbColor
            // 
            this.pbColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbColor.Location = new System.Drawing.Point(0, 0);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(333, 171);
            this.pbColor.TabIndex = 0;
            this.pbColor.TabStop = false;
            // 
            // pnlHexOrDec
            // 
            this.pnlHexOrDec.Controls.Add(this.rbDec);
            this.pnlHexOrDec.Controls.Add(this.rbHex);
            this.pnlHexOrDec.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHexOrDec.Location = new System.Drawing.Point(0, 126);
            this.pnlHexOrDec.Name = "pnlHexOrDec";
            this.pnlHexOrDec.Size = new System.Drawing.Size(187, 45);
            this.pnlHexOrDec.TabIndex = 1;
            // 
            // rbDec
            // 
            this.rbDec.AutoSize = true;
            this.rbDec.Checked = true;
            this.rbDec.Location = new System.Drawing.Point(76, 12);
            this.rbDec.Name = "rbDec";
            this.rbDec.Size = new System.Drawing.Size(54, 21);
            this.rbDec.TabIndex = 1;
            this.rbDec.TabStop = true;
            this.rbDec.Text = "Dec";
            this.rbDec.UseVisualStyleBackColor = true;
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(3, 12);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(53, 21);
            this.rbHex.TabIndex = 0;
            this.rbHex.Text = "Hex";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // tbrRed
            // 
            this.tbrRed.Location = new System.Drawing.Point(65, 12);
            this.tbrRed.Name = "tbrRed";
            this.tbrRed.Pattern = ((System.Text.RegularExpressions.Regex)(resources.GetObject("tbrRed.Pattern")));
            this.tbrRed.Size = new System.Drawing.Size(114, 22);
            this.tbrRed.TabIndex = 2;
            this.tbrRed.Text = "0";
            // 
            // tbrGreen
            // 
            this.tbrGreen.Location = new System.Drawing.Point(65, 50);
            this.tbrGreen.Name = "tbrGreen";
            this.tbrGreen.Pattern = ((System.Text.RegularExpressions.Regex)(resources.GetObject("tbrGreen.Pattern")));
            this.tbrGreen.Size = new System.Drawing.Size(114, 22);
            this.tbrGreen.TabIndex = 3;
            this.tbrGreen.Text = "0";
            // 
            // tbrBlue
            // 
            this.tbrBlue.Location = new System.Drawing.Point(65, 89);
            this.tbrBlue.Name = "tbrBlue";
            this.tbrBlue.Pattern = ((System.Text.RegularExpressions.Regex)(resources.GetObject("tbrBlue.Pattern")));
            this.tbrBlue.Size = new System.Drawing.Size(114, 22);
            this.tbrBlue.TabIndex = 4;
            this.tbrBlue.Text = "0";
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(3, 12);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(34, 17);
            this.lblRed.TabIndex = 5;
            this.lblRed.Text = "Red";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(3, 50);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(48, 17);
            this.lblGreen.TabIndex = 6;
            this.lblGreen.Text = "Green";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(3, 89);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(36, 17);
            this.lblBlue.TabIndex = 7;
            this.lblBlue.Text = "Blue";
            // 
            // pnlColorCode
            // 
            this.pnlColorCode.Controls.Add(this.tbrRed);
            this.pnlColorCode.Controls.Add(this.pnlHexOrDec);
            this.pnlColorCode.Controls.Add(this.lblBlue);
            this.pnlColorCode.Controls.Add(this.tbrGreen);
            this.pnlColorCode.Controls.Add(this.lblGreen);
            this.pnlColorCode.Controls.Add(this.tbrBlue);
            this.pnlColorCode.Controls.Add(this.lblRed);
            this.pnlColorCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlColorCode.Location = new System.Drawing.Point(0, 0);
            this.pnlColorCode.Name = "pnlColorCode";
            this.pnlColorCode.Size = new System.Drawing.Size(187, 171);
            this.pnlColorCode.TabIndex = 8;
            // 
            // ColorCodeControl
            // 
            this.Controls.Add(this.pnlColorCode);
            this.Controls.Add(this.pbColor);
            this.Name = "ColorCodeControl";
            this.Size = new System.Drawing.Size(333, 171);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.pnlHexOrDec.ResumeLayout(false);
            this.pnlHexOrDec.PerformLayout();
            this.pnlColorCode.ResumeLayout(false);
            this.pnlColorCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.Panel pnlHexOrDec;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.RadioButton rbDec;
        private TextBoxRegex tbrRed;
        private TextBoxRegex tbrGreen;
        private TextBoxRegex tbrBlue;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Panel pnlColorCode;
    }
}
