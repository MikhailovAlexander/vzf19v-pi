namespace WhoWantsToBeAMillionaire
{
    partial class FormCallFriend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCallFriend));
            this.lblAnswer = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnCall = new System.Windows.Forms.Button();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFriendName = new System.Windows.Forms.Label();
            this.lblFriendPhone = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblCheckPhoneFalse = new System.Windows.Forms.Label();
            this.lblCheckNameFalse = new System.Windows.Forms.Label();
            this.checkMarkName = new System.Windows.Forms.PictureBox();
            this.checkMarkPhone = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkMarkName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMarkPhone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAnswer.Location = new System.Drawing.Point(8, 14);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 20);
            this.lblAnswer.TabIndex = 0;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(232, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(172, 22);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(266, 130);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(94, 31);
            this.btnCall.TabIndex = 2;
            this.btnCall.Text = "Позвонить";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(232, 81);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(172, 22);
            this.tbPhone.TabIndex = 3;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFriendName
            // 
            this.lblFriendName.AutoSize = true;
            this.lblFriendName.Location = new System.Drawing.Point(7, 44);
            this.lblFriendName.Name = "lblFriendName";
            this.lblFriendName.Size = new System.Drawing.Size(209, 17);
            this.lblFriendName.TabIndex = 4;
            this.lblFriendName.Text = "Введите имя друга для звонка";
            // 
            // lblFriendPhone
            // 
            this.lblFriendPhone.AutoSize = true;
            this.lblFriendPhone.Location = new System.Drawing.Point(8, 81);
            this.lblFriendPhone.Name = "lblFriendPhone";
            this.lblFriendPhone.Size = new System.Drawing.Size(218, 17);
            this.lblFriendPhone.TabIndex = 5;
            this.lblFriendPhone.Text = "Введите номер телефона друга";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.lblTimer.Location = new System.Drawing.Point(401, 128);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(60, 42);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "30";
            // 
            // lblCheckPhoneFalse
            // 
            this.lblCheckPhoneFalse.AutoSize = true;
            this.lblCheckPhoneFalse.ForeColor = System.Drawing.Color.Red;
            this.lblCheckPhoneFalse.Location = new System.Drawing.Point(164, 106);
            this.lblCheckPhoneFalse.Name = "lblCheckPhoneFalse";
            this.lblCheckPhoneFalse.Size = new System.Drawing.Size(240, 17);
            this.lblCheckPhoneFalse.TabIndex = 39;
            this.lblCheckPhoneFalse.Text = "Не похоже на телефон из 10 цифр!";
            this.lblCheckPhoneFalse.Visible = false;
            // 
            // lblCheckNameFalse
            // 
            this.lblCheckNameFalse.AutoSize = true;
            this.lblCheckNameFalse.ForeColor = System.Drawing.Color.Red;
            this.lblCheckNameFalse.Location = new System.Drawing.Point(235, 61);
            this.lblCheckNameFalse.Name = "lblCheckNameFalse";
            this.lblCheckNameFalse.Size = new System.Drawing.Size(169, 17);
            this.lblCheckNameFalse.TabIndex = 38;
            this.lblCheckNameFalse.Text = "Не похоже на имя друга!";
            this.lblCheckNameFalse.Visible = false;
            // 
            // checkMarkName
            // 
            this.checkMarkName.Image = ((System.Drawing.Image)(resources.GetObject("checkMarkName.Image")));
            this.checkMarkName.Location = new System.Drawing.Point(410, 39);
            this.checkMarkName.Name = "checkMarkName";
            this.checkMarkName.Size = new System.Drawing.Size(33, 22);
            this.checkMarkName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.checkMarkName.TabIndex = 40;
            this.checkMarkName.TabStop = false;
            this.checkMarkName.Visible = false;
            // 
            // checkMarkPhone
            // 
            this.checkMarkPhone.Image = ((System.Drawing.Image)(resources.GetObject("checkMarkPhone.Image")));
            this.checkMarkPhone.Location = new System.Drawing.Point(410, 81);
            this.checkMarkPhone.Name = "checkMarkPhone";
            this.checkMarkPhone.Size = new System.Drawing.Size(33, 22);
            this.checkMarkPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.checkMarkPhone.TabIndex = 41;
            this.checkMarkPhone.TabStop = false;
            this.checkMarkPhone.Visible = false;
            // 
            // FormCallFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 174);
            this.Controls.Add(this.checkMarkPhone);
            this.Controls.Add(this.checkMarkName);
            this.Controls.Add(this.lblCheckPhoneFalse);
            this.Controls.Add(this.lblCheckNameFalse);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblFriendPhone);
            this.Controls.Add(this.lblFriendName);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblAnswer);
            this.Name = "FormCallFriend";
            this.Text = "Звонок другу";
            ((System.ComponentModel.ISupportInitialize)(this.checkMarkName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMarkPhone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFriendName;
        private System.Windows.Forms.Label lblFriendPhone;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblCheckPhoneFalse;
        private System.Windows.Forms.Label lblCheckNameFalse;
        private System.Windows.Forms.PictureBox checkMarkName;
        private System.Windows.Forms.PictureBox checkMarkPhone;
    }
}