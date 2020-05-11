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
    public partial class Form1 : Form
    {
        public static int PenWidth = 1;
        public static Color PenColor = Color.Black;
        public Form1()
        {
            InitializeComponent();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentForm doc = new DocumentForm();
            doc.MdiParent = this;
            doc.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AboutBox1();
            f.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PenWidth = int.Parse(toolStripComboBox1.SelectedItem.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PenColor = Color.Red;
        }
    }
}
