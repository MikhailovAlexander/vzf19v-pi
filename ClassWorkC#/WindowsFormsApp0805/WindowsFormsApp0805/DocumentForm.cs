using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp0805
{
    public partial class DocumentForm : Form
    {
        int x, y;

        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }

        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var g = CreateGraphics();
                g.DrawLine(new Pen(Form1.PenColor,Form1.PenWidth), x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
            }
        }

        public DocumentForm()
        {
            InitializeComponent();
        }
    }
}
