using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Constr0805
{
    public partial class NumberTextBox : TextBox
    {
        public NumberTextBox()
        {
            InitializeComponent();
        }

        public NumberTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            int n = 0;
            if (int.TryParse(Text, out n))
                ForeColor = SystemColors.ControlText;
            else ForeColor = Color.Red;
        }
    }
}
