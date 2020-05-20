using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constr0805
{
    public partial class CodeColorTextBox : TextBox
    {
        public enum CodeType
        {
            Decimal,
            Hexadecimal
        }
        public event EventHandler<EventArgs> CodeColorChanged;
        private Char[] hexLetter = {'a','A','b','B','c','C','d','D','e','E','f','F'};
        private int colorCode = 0;
        private CodeType codeType = CodeType.Decimal;

        public int ColorCode
        {
            get => colorCode;
            set
            {
                if (value > 255) colorCode = 255;
                else if (value < 0) colorCode = 0;
                else colorCode = value;
                this.Text = IsDec ? colorCode.ToString() : Convert.ToString(colorCode, 16);
                OnCodeColorChanged(new EventArgs());
            }
        }

        public bool IsDec => codeType == CodeType.Decimal;
        public bool IsHex => codeType == CodeType.Hexadecimal;

        public CodeColorTextBox()
        {
            InitializeComponent();
        }

        public CodeColorTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SetDec()
        {
            codeType = CodeType.Decimal;
            this.Text = colorCode.ToString();
        }

        public void SetHex()
        {
            codeType = CodeType.Hexadecimal;
            this.Text = Convert.ToString(colorCode, 16);
        }

        protected void OnCodeColorChanged(EventArgs e)
        {
            if (CodeColorChanged != null)
                CodeColorChanged(this, e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            Char keyChar = e.KeyChar;
            if(((IsDec && (!Char.IsDigit(keyChar) || this.Text.Length == 3))
                ||(IsHex && (!(Char.IsDigit(keyChar) || hexLetter.Contains(keyChar)) || this.Text.Length == 2)))
                && keyChar != 8)
                e.Handled = true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (String.IsNullOrEmpty(this.Text)) return;
            if (IsDec) ColorCode = int.Parse(this.Text);
            else if(IsHex) ColorCode = int.Parse(this.Text, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
