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
        public event EventHandler<EventArgs> RegexCheckFailed;
        public event EventHandler<EventArgs> RegexChecked;
        public Regex Pattern { get; set; } 
        public TextBoxRegex()
        {
            InitializeComponent();
            Pattern = new Regex(".*");
        }

        public TextBoxRegex(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected void OnRegexCheckFailed()
        {
            if (RegexCheckFailed != null)
                RegexCheckFailed(this, new EventArgs());
        }

        protected void OnRegexChecked()
        {
            if (RegexCheckFailed != null)
                RegexChecked(this, new EventArgs());
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (Pattern.IsMatch(this.Text))
                OnRegexChecked();
            else OnRegexCheckFailed();
        }
    }
}
