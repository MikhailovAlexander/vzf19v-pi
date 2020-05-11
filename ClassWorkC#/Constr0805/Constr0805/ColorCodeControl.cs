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
    public partial class ColorCodeControl : UserControl
    {
        private Regex decPattern = new Regex(@"^1?\d{1,2}$|^2[0-5]{2}$");
        private Regex hexPattern = new Regex(@"^[A-Fa-f0-9]{1,2}$");
        public ColorCodeControl()
        {
            InitializeComponent();
        }

        public ColorCodeControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
