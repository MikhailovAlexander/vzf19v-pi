using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constr0805
{
    public partial class FilePathControl : UserControl
    {
        public event EventHandler<EventArgs> FilePathChanged;
        public FilePathControl()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                OnFilePathChanged();
            }
        }

        protected void OnFilePathChanged()
        {
            if (FilePathChanged != null)
                FilePathChanged(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                FileName = dialog.FileName;
            }
        }
    }
}
