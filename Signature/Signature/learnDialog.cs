using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signature
{
    public partial class learnDialog : Form
    {
        int value;
        public learnDialog()
        {
            InitializeComponent();
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            this.value = trackBar.Value;
            this.textBox.Text = value.ToString();
        }

        private void learnDialog_Load(object sender, EventArgs e)
        {
            this.value = trackBar.Value;
            this.textBox.Text = value.ToString();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public int Value
        {
            get { return value; }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.value = -1;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
