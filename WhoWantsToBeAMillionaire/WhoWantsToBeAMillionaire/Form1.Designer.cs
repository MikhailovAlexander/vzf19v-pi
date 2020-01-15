using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFiftyFifty = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstLevel = new System.Windows.Forms.ListBox();
            this.btnAnswerA = new System.Windows.Forms.Button();
            this.btnAnswerB = new System.Windows.Forms.Button();
            this.btnAnswerC = new System.Windows.Forms.Button();
            this.btnAnswerD = new System.Windows.Forms.Button();
            this.btnChangeQuestion = new System.Windows.Forms.Button();
            this.btnRightToMistake = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeclareFriends = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPeopleHelp = new System.Windows.Forms.Button();
            this.btnCallFriend = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSetAmount = new System.Windows.Forms.Button();
            this.lblSetAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFiftyFifty
            // 
            this.btnFiftyFifty.Location = new System.Drawing.Point(12, 13);
            this.btnFiftyFifty.Name = "btnFiftyFifty";
            this.btnFiftyFifty.Size = new System.Drawing.Size(136, 32);
            this.btnFiftyFifty.TabIndex = 0;
            this.btnFiftyFifty.Text = "50/50";
            this.btnFiftyFifty.UseVisualStyleBackColor = true;
            this.btnFiftyFifty.Click += new System.EventHandler(this.btnFiftyFifty_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblQuestion.Location = new System.Drawing.Point(3, 7);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(776, 64);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "lblQuestion";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(490, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lstLevel
            // 
            this.lstLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstLevel.FormattingEnabled = true;
            this.lstLevel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lstLevel.ItemHeight = 18;
            this.lstLevel.Items.AddRange(new object[] {
            "3000000",
            "1500000",
            "800000",
            "400000",
            "200000",
            "100000",
            "50000",
            "25000",
            "15000",
            "10000",
            "5000",
            "3000",
            "2000",
            "1000",
            "500"});
            this.lstLevel.Location = new System.Drawing.Point(3, 5);
            this.lstLevel.Name = "lstLevel";
            this.lstLevel.Size = new System.Drawing.Size(105, 292);
            this.lstLevel.TabIndex = 3;
            // 
            // btnAnswerA
            // 
            this.btnAnswerA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnswerA.Location = new System.Drawing.Point(166, 74);
            this.btnAnswerA.Name = "btnAnswerA";
            this.btnAnswerA.Size = new System.Drawing.Size(201, 36);
            this.btnAnswerA.TabIndex = 4;
            this.btnAnswerA.Tag = "1";
            this.btnAnswerA.Text = "btnAnswerA";
            this.btnAnswerA.UseVisualStyleBackColor = true;
            this.btnAnswerA.Click += new System.EventHandler(this.btnAnswerA_Click);
            // 
            // btnAnswerB
            // 
            this.btnAnswerB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnswerB.Location = new System.Drawing.Point(401, 74);
            this.btnAnswerB.Name = "btnAnswerB";
            this.btnAnswerB.Size = new System.Drawing.Size(201, 36);
            this.btnAnswerB.TabIndex = 5;
            this.btnAnswerB.Tag = "2";
            this.btnAnswerB.Text = "btnAnswerB";
            this.btnAnswerB.UseVisualStyleBackColor = true;
            this.btnAnswerB.Click += new System.EventHandler(this.btnAnswerB_Click);
            // 
            // btnAnswerC
            // 
            this.btnAnswerC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnswerC.Location = new System.Drawing.Point(166, 116);
            this.btnAnswerC.Name = "btnAnswerC";
            this.btnAnswerC.Size = new System.Drawing.Size(201, 36);
            this.btnAnswerC.TabIndex = 6;
            this.btnAnswerC.Tag = "3";
            this.btnAnswerC.Text = "btnAnswerC";
            this.btnAnswerC.UseVisualStyleBackColor = true;
            this.btnAnswerC.Click += new System.EventHandler(this.btnAnswerC_Click);
            // 
            // btnAnswerD
            // 
            this.btnAnswerD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnswerD.Location = new System.Drawing.Point(401, 117);
            this.btnAnswerD.Name = "btnAnswerD";
            this.btnAnswerD.Size = new System.Drawing.Size(201, 36);
            this.btnAnswerD.TabIndex = 7;
            this.btnAnswerD.Tag = "4";
            this.btnAnswerD.Text = "btnAnswerD";
            this.btnAnswerD.UseVisualStyleBackColor = true;
            this.btnAnswerD.Click += new System.EventHandler(this.btnAnswerD_Click);
            // 
            // btnChangeQuestion
            // 
            this.btnChangeQuestion.Location = new System.Drawing.Point(12, 54);
            this.btnChangeQuestion.Name = "btnChangeQuestion";
            this.btnChangeQuestion.Size = new System.Drawing.Size(136, 35);
            this.btnChangeQuestion.TabIndex = 8;
            this.btnChangeQuestion.Text = "Замена вопроса";
            this.btnChangeQuestion.UseVisualStyleBackColor = true;
            this.btnChangeQuestion.Click += new System.EventHandler(this.btnChangeQuestion_Click);
            // 
            // btnRightToMistake
            // 
            this.btnRightToMistake.Location = new System.Drawing.Point(12, 97);
            this.btnRightToMistake.Name = "btnRightToMistake";
            this.btnRightToMistake.Size = new System.Drawing.Size(136, 35);
            this.btnRightToMistake.TabIndex = 9;
            this.btnRightToMistake.Text = "Право на ошибку";
            this.btnRightToMistake.UseVisualStyleBackColor = true;
            this.btnRightToMistake.Click += new System.EventHandler(this.btnRightToMistake_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSetAmount);
            this.panel1.Controls.Add(this.btnSetAmount);
            this.panel1.Controls.Add(this.btnDeclareFriends);
            this.panel1.Controls.Add(this.lblQuestion);
            this.panel1.Controls.Add(this.btnAnswerA);
            this.panel1.Controls.Add(this.btnAnswerB);
            this.panel1.Controls.Add(this.btnAnswerD);
            this.panel1.Controls.Add(this.btnAnswerC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 164);
            this.panel1.TabIndex = 10;
            // 
            // btnDeclareFriends
            // 
            this.btnDeclareFriends.Location = new System.Drawing.Point(8, 116);
            this.btnDeclareFriends.Name = "btnDeclareFriends";
            this.btnDeclareFriends.Size = new System.Drawing.Size(136, 35);
            this.btnDeclareFriends.TabIndex = 12;
            this.btnDeclareFriends.Text = "Заявить друзей";
            this.btnDeclareFriends.UseVisualStyleBackColor = true;
            this.btnDeclareFriends.Click += new System.EventHandler(this.btnDeclareFriends_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstLevel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(665, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(122, 295);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPeopleHelp);
            this.panel3.Controls.Add(this.btnCallFriend);
            this.panel3.Controls.Add(this.btnFiftyFifty);
            this.panel3.Controls.Add(this.btnChangeQuestion);
            this.panel3.Controls.Add(this.btnRightToMistake);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(158, 295);
            this.panel3.TabIndex = 12;
            // 
            // btnPeopleHelp
            // 
            this.btnPeopleHelp.Location = new System.Drawing.Point(11, 182);
            this.btnPeopleHelp.Name = "btnPeopleHelp";
            this.btnPeopleHelp.Size = new System.Drawing.Size(136, 35);
            this.btnPeopleHelp.TabIndex = 11;
            this.btnPeopleHelp.Text = "Помощь зала";
            this.btnPeopleHelp.UseVisualStyleBackColor = true;
            this.btnPeopleHelp.Click += new System.EventHandler(this.btnPeopleHelp_Click);
            // 
            // btnCallFriend
            // 
            this.btnCallFriend.Location = new System.Drawing.Point(11, 139);
            this.btnCallFriend.Name = "btnCallFriend";
            this.btnCallFriend.Size = new System.Drawing.Size(136, 35);
            this.btnCallFriend.TabIndex = 10;
            this.btnCallFriend.Text = "Звонок другу";
            this.btnCallFriend.UseVisualStyleBackColor = true;
            this.btnCallFriend.Click += new System.EventHandler(this.btnCallFriend_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(158, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(507, 295);
            this.panel4.TabIndex = 13;
            // 
            // btnSetAmount
            // 
            this.btnSetAmount.Location = new System.Drawing.Point(619, 105);
            this.btnSetAmount.Name = "btnSetAmount";
            this.btnSetAmount.Size = new System.Drawing.Size(160, 47);
            this.btnSetAmount.TabIndex = 13;
            this.btnSetAmount.Text = "Установить несгораемую сумму";
            this.btnSetAmount.UseVisualStyleBackColor = true;
            this.btnSetAmount.Click += new System.EventHandler(this.btnSetAmount_Click);
            // 
            // lblSetAmount
            // 
            this.lblSetAmount.AutoSize = true;
            this.lblSetAmount.ForeColor = System.Drawing.Color.Red;
            this.lblSetAmount.Location = new System.Drawing.Point(605, 80);
            this.lblSetAmount.Name = "lblSetAmount";
            this.lblSetAmount.Size = new System.Drawing.Size(175, 17);
            this.lblSetAmount.TabIndex = 14;
            this.lblSetAmount.Text = "Отметьте сумму в списке";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 459);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Кто хочет стать милионером";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFiftyFifty;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstLevel;
        private System.Windows.Forms.Button btnAnswerA;
        private System.Windows.Forms.Button btnAnswerB;
        private System.Windows.Forms.Button btnAnswerC;
        private System.Windows.Forms.Button btnAnswerD;
        private System.Windows.Forms.Button btnChangeQuestion;
        private System.Windows.Forms.Button btnRightToMistake;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnPeopleHelp;
        private System.Windows.Forms.Button btnCallFriend;
        private Button btnDeclareFriends;
        private Label lblSetAmount;
        private Button btnSetAmount;
    }
}

