using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constr0805
{
    public partial class CircleControl : Control
    {
        private Color color = Color.Black;
        public CircleControl()
        {
            InitializeComponent();
        }

        public CircleControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillEllipse(new SolidBrush(Color), ClientRectangle);
        }
    }

}
