using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lazyforlife.BinaryWriter
{
    public partial class AddItemForm : Form
    {
        public string Source { get; private set; }
        public long Offset { get; private set; }


        public AddItemForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog1.ShowDialog(this);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            if (string.IsNullOrWhiteSpace(t))
                MessageBox.Show("invalid file name");
            else
            {
                if (!File.Exists(t))
                    MessageBox.Show("File does not exist");
                else
                {
                    this.Source = t;
                    this.Offset = (long)numericUpDown1.Value;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void canelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
