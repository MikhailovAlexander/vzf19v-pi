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
            this.lblRed = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.pnlColorCode = new System.Windows.Forms.Panel();
            this.tbrRed = new Constr0805.TextBoxRegex(this.components);
            this.tbrGreen = new Constr0805.TextBoxRegex(this.components);
            this.tbrBlue = new Constr0805.TextBoxRegex(this.components);
            this.errorProviderRed = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderGreen = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderBlue = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.pnlHexOrDec.SuspendLayout();
            this.pnlColorCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // pbColor
            // 
            this.pbColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbColor.Location = new System.Drawing.Point(0, 0);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(300, 170);
            this.pbColor.TabIndex = 0;
            this.pbColor.TabStop = false;
            // 
            // pnlHexOrDec
            // 
            this.pnlHexOrDec.Controls.Add(this.rbDec);
            this.pnlHexOrDec.Controls.Add(this.rbHex);
            this.pnlHexOrDec.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHexOrDec.Location = new System.Drawing.Point(0, 125);
            this.pnlHexOrDec.Name = "pnlHexOrDec";
            this.pnlHexOrDec.Size = new System.Drawing.Size(147, 45);
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
            this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
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
            this.pnlColorCode.Size = new System.Drawing.Size(147, 170);
            this.pnlColorCode.TabIndex = 8;
            // 
            // tbrRed
            // 
            this.tbrRed.Location = new System.Drawing.Point(58, 12);
            this.tbrRed.Name = "tbrRed";
            this.tbrRed.Pattern = ((System.Text.RegularExpressions.Regex)(resources.GetObject("tbrRed.Pattern")));
            this.tbrRed.Size = new System.Drawing.Size(57, 22);
            this.tbrRed.TabIndex = 2;
            this.tbrRed.Text = "0";
            this.tbrRed.RegexCheckFailed += new System.EventHandler<System.EventArgs>(this.tbrRed_RegexCheckFailed);
            this.tbrRed.RegexChecked += new System.EventHandler<System.EventArgs>(this.tbrRed_RegexChecked);
            // 
            // tbrGreen
            // 
            this.tbrGreen.Location = new System.Drawing.Point(58, 50);
            this.tbrGreen.Name = "tbrGreen";
            this.tbrGreen.Pattern = ((System.Text.RegularExpressions.Regex)(resources.GetObject("tbrGreen.Pattern")));
            this.tbrGreen.Size = new System.Drawing.Size(57, 22);
            this.tbrGreen.TabIndex = 3;
            this.tbrGreen.Text = "0";
            this.tbrGreen.RegexCheckFailed += new System.EventHandler<System.EventArgs>(this.tbrGreen_RegexCheckFailed);
            this.tbrGreen.RegexChecked += new System.EventHandler<System.EventArgs>(this.tbrGreen_RegexChecked);
            // 
            // tbrBlue
            // 
            this.tbrBlue.Location = new System.Drawing.Point(58, 89);
            this.tbrBlue.Name = "tbrBlue";
            this.tbrBlue.Pattern = ((System.Text.RegularExpressions.Regex)(resources.GetObject("tbrBlue.Pattern")));
            this.tbrBlue.Size = new System.Drawing.Size(57, 22);
            this.tbrBlue.TabIndex = 4;
            this.tbrBlue.Text = "0";
            this.tbrBlue.RegexCheckFailed += new System.EventHandler<System.EventArgs>(this.tbrBlue_RegexCheckFailed);
            this.tbrBlue.RegexChecked += new System.EventHandler<System.EventArgs>(this.tbrBlue_RegexChecked);
            // 
            // errorProviderRed
            // 
            this.errorProviderRed.ContainerControl = this;
            // 
            // errorProviderGreen
            // 
            this.errorProviderGreen.ContainerControl = this;
            // 
            // errorProviderBlue
            // 
            this.errorProviderBlue.ContainerControl = this;
            // 
            // ColorCodeControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlColorCode);
            this.Controls.Add(this.pbColor);
            this.MinimumSize = new System.Drawing.Size(250, 170);
            this.Name = "ColorCodeControl";
            this.Size = new System.Drawing.Size(300, 170);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.pnlHexOrDec.ResumeLayout(false);
            this.pnlHexOrDec.PerformLayout();
            this.pnlColorCode.ResumeLayout(false);
            this.pnlColorCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBlue)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProviderRed;
        private System.Windows.Forms.ErrorProvider errorProviderGreen;
        private System.Windows.Forms.ErrorProvider errorProviderBlue;
    }
}
