using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class FormFriends : Form
    {
        public Dictionary<string, string> friends;
        TextBox[] names;
        TextBox[] phones;

        public FormFriends()
        {
            InitializeComponent();
            names = new TextBox[] { tbName1 , tbName2, tbName3, tbName4, tbName5 };
            phones = new TextBox[] { tbPhone1, tbPhone2, tbPhone3, tbPhone4, tbPhone5 };
            friends = new Dictionary<string, string>();
        }
        string namePattern = @"^[А-яA-z]+$";
        string phonePattern = @"^\d{10}$";

        private void CheckTextBox(TextBox tb, string pattern, PictureBox checkMark,
            Label checkFalse)
        {
            if(string.IsNullOrWhiteSpace(tb.Text))
            {
                checkMark.Visible = false;
                checkFalse.Visible = false;
            }
            else if(Regex.IsMatch(tb.Text, pattern))
            {
                checkMark.Visible = true;
                checkFalse.Visible = false;
            }
            else
            {
                checkMark.Visible = false;
                checkFalse.Visible = true;
            }
        }

        private void tbName1_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, namePattern, checkMarkName1, lblCheckNameFalse1);
        }

        private void tbPhone1_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, phonePattern, checkMarkPhone1, lblCheckPhoneFalse1);
        }

        private void tbName2_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, namePattern, checkMarkName2, lblCheckNameFalse2);
        }

        private void tbPhone2_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, phonePattern, checkMarkPhone2, lblCheckPhoneFalse2);
        }

        private void tbName3_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, namePattern, checkMarkName3, lblCheckNameFalse3);
        }

        private void tbPhone3_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, phonePattern, checkMarkPhone3, lblCheckPhoneFalse3);
        }

        private void tbName4_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, namePattern, checkMarkName4, lblCheckNameFalse4);
        }

        private void tbPhone4_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, phonePattern, checkMarkPhone4, lblCheckPhoneFalse4);
        }

        private void tbName5_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, namePattern, checkMarkName5, lblCheckNameFalse5);
        }

        private void tbPhone5_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox((TextBox)sender, phonePattern, checkMarkPhone5, lblCheckPhoneFalse5);
        }

        private bool CheckNameAndPhone(TextBox tbName, TextBox tbPhone)
        {
            return (string.IsNullOrWhiteSpace(tbName.Text) || Regex.IsMatch(tbName.Text, namePattern))
                && (string.IsNullOrWhiteSpace(tbPhone.Text) || Regex.IsMatch(tbPhone.Text, phonePattern));
        }

        private bool NameAndPhoneIsEmpty(TextBox tbName, TextBox tbPhone)
        {
            return string.IsNullOrWhiteSpace(tbName.Text)&&string.IsNullOrWhiteSpace(tbPhone.Text);
        }

        private bool CheckForm()
        {
            bool check = true;
            for(int i = 0; i < 5; i++)
                if (!CheckNameAndPhone(names[i], phones[i])) check = false;
            return check;
        }

        private bool FormIsEmpty()
        {
            bool isEmpty = true;
            for (int i = 0; i < 5; i++)
                if (!NameAndPhoneIsEmpty(names[i], phones[i])) isEmpty = false;
            return isEmpty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckForm())
            {
                MessageBox.Show("Форма заполнена не корректно, заявить друзей не получиться" +
                    "\n Заполните форму или нажмите Отмена");
                return;
            }
            if (FormIsEmpty())
            {
                MessageBox.Show("Форма не заполнена, заявить друзей не получиться" +
                    "\n Заполните форму или нажмите Отмена");
                return;
            }
            try
            {
                for (int i = 0; i < 5; i++)
                    if (!NameAndPhoneIsEmpty(names[i], phones[i]))
                        friends.Add(names[i].Text, phones[i].Text);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Имена друзей не должны повторяться");
                friends.Clear();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
