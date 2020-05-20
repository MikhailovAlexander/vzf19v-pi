using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace Constr0805
{
    public partial class ColorCodeControl : UserControl
    {
        public event EventHandler<EventArgs> ColorChanged;
        private Color color;
        private Regex decPattern = new Regex(@"^1?\d{1,2}$|^2[0-5]{2}$");
        private Regex hexPattern = new Regex(@"^[A-F0-9]{1,2}$",RegexOptions.IgnoreCase);
        private const string decError = "Введите десятичное число от 0 до 255";
        private const string hexError = "Введите шестнадцатиричное число от 0 до FF";
        public Color Color => color;

        public ColorCodeControl()
        {
            InitializeComponent();
        }

        public ColorCodeControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            rbDec.Checked = true;
            tbrRed.Pattern = decPattern;
            tbrGreen.Pattern = decPattern;
            tbrBlue.Pattern = decPattern;
            color = Color.White;
            pbColor.BackColor = color;
        }

        protected void OnColorChanged()
        {
            if (ColorChanged != null)
                ColorChanged(this, new EventArgs());
        }

        private void SetColor()
        {
            if (!(tbrRed.Pattern == tbrGreen.Pattern && tbrGreen.Pattern == tbrBlue.Pattern))
                return;
            if (!(tbrRed.Check && tbrGreen.Check && tbrBlue.Check))
                return;
            if (rbDec.Checked) color = Color.FromArgb(
                int.Parse(tbrRed.Text), int.Parse(tbrGreen.Text), int.Parse(tbrBlue.Text));
            else color = Color.FromArgb(
                int.Parse(tbrRed.Text, NumberStyles.HexNumber), 
                int.Parse(tbrGreen.Text, NumberStyles.HexNumber), 
                int.Parse(tbrBlue.Text, NumberStyles.HexNumber));
            OnColorChanged();
            pbColor.BackColor = color;
        }

        private void SetPattern()
        {
            if(rbDec.Checked)
            {
                tbrRed.Pattern = decPattern;
                tbrGreen.Pattern = decPattern;
                tbrBlue.Pattern = decPattern;
            }
            if(rbHex.Checked)
            {
                tbrRed.Pattern = hexPattern;
                tbrGreen.Pattern = hexPattern;
                tbrBlue.Pattern = hexPattern;
            }
        }

        private void rbHex_CheckedChanged(object sender, EventArgs e)
        {
            SetPattern();
            SetColor();
        }

        private void tbrRed_RegexCheckFailed(object sender, EventArgs e)
        {
            errorProviderRed.SetError(tbrRed, rbDec.Checked? decError : hexError);
        }

        private void tbrGreen_RegexCheckFailed(object sender, EventArgs e)
        {
            errorProviderGreen.SetError(tbrGreen, rbDec.Checked ? decError : hexError);
        }

        private void tbrBlue_RegexCheckFailed(object sender, EventArgs e)
        {
            errorProviderBlue.SetError(tbrBlue, rbDec.Checked ? decError : hexError);
        }

        private void tbrRed_RegexChecked(object sender, EventArgs e)
        {
            errorProviderRed.Clear();
            SetColor();
        }

        private void tbrGreen_RegexChecked(object sender, EventArgs e)
        {
            errorProviderGreen.Clear();
            SetColor();
        }

        private void tbrBlue_RegexChecked(object sender, EventArgs e)
        {

            errorProviderBlue.Clear();
            SetColor();
        }
    }
}
