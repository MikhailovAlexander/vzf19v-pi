using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constr0805
{
    public partial class TextBoxRegex : TextBox
    {
        private Regex pattern;
        public event EventHandler<EventArgs> RegexCheckFailed;
        public event EventHandler<EventArgs> RegexChecked;
        public Regex Pattern
        {
            get { return pattern; }
            set
            {
                pattern = value;
                OnTextChanged(new EventArgs());
            }
        }
        public bool Check => Checked();
        public TextBoxRegex()
        {
            InitializeComponent();
            pattern = new Regex(".*");
        }

        public TextBoxRegex(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected void OnRegexCheckFailed(EventArgs e)
        {
            if (RegexCheckFailed != null)
                RegexCheckFailed(this, e);
        }

        protected void OnRegexChecked(EventArgs e)
        {
            if (RegexCheckFailed != null)
                RegexChecked(this, e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (pattern.IsMatch(this.Text))
                OnRegexChecked(e);
            else OnRegexCheckFailed(e);
        }

        private bool Checked()
        {
            if (this.Text != null) return pattern.IsMatch(this.Text);
            return false;
        }
    }
}
