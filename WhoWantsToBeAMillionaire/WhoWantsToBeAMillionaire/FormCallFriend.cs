using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WhoWantsToBeAMillionaire
{
    public partial class FormCallFriend : Form
    {
        Dictionary<string, string> friends;
        string answer;
        string namePattern = @"^[А-яA-z]+$";
        string phonePattern = @"^\d{10}$";
        int seconds = 30;

        public FormCallFriend(Dictionary<string, string> friends, string answer)
        {
            InitializeComponent();
            this.friends = friends;
            this.answer = "Я уверен, что правильный ответ: " + answer;
            timer1.Start();
        }

        private bool CheckNameAndPhone()
        {
            return Regex.IsMatch(tbName.Text, namePattern)&&Regex.IsMatch(tbPhone.Text, phonePattern);
        }

        private bool NameAndPhoneIsEmpty()
        {
            return string.IsNullOrWhiteSpace(tbName.Text) && string.IsNullOrWhiteSpace(tbPhone.Text);
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            if (NameAndPhoneIsEmpty())
            {
                lblAnswer.Text = "Введите имя и телефон друга";
                return;
            }
            if (!CheckNameAndPhone())
            {
                lblAnswer.Text = "Введите корректные имя и телефон друга";
                return;
            }
            if (friends.Keys.Contains(tbName.Text))
                if (friends[tbName.Text] == tbPhone.Text) lblAnswer.Text = answer;
                else lblAnswer.Text = "Номер телефона введен не верно";
            else lblAnswer.Text = "Имя друга введено не верно"; ;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
            {
                lblTimer.Text = (--seconds).ToString();
                if (seconds < 6) lblTimer.ForeColor = Color.Red;
            }
            else this.Close();

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(tbName.Text, namePattern))
            {
                checkMarkName.Visible = true;
                lblCheckNameFalse.Visible = false;
            }
            else
            {
                checkMarkName.Visible = false;
                lblCheckNameFalse.Visible = true;
            }
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(tbPhone.Text, phonePattern))
            {
                checkMarkPhone.Visible = true;
                lblCheckPhoneFalse.Visible = false;
            }
            else
            {
                checkMarkPhone.Visible = false;
                lblCheckPhoneFalse.Visible = true;
            }
        }
    }
}
