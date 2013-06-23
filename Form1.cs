using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lazyforlife.BinaryWriter
{
    public partial class BinaryWriterForm : Form
    {
        public BinaryWriterForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dr = saveFileDialog1.ShowDialog(this);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                destTextbox.Text = saveFileDialog1.FileName;
            }
        }

        private void write_Click(object sender, EventArgs e)
        {
            BinaryWriterLibrary bw = new BinaryWriterLibrary(destTextbox.Text);
            bw.IsOverWrite = overWriteCheckBox.Checked;

            bw.Write();

            MessageBox.Show("Writing done");

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new AddItemForm();
            if (t.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            listView1.Items.Add(new CustomLVItem(t.Source,t.Offset));
            
        }

        class CustomLVItem : ListViewItem
        {
            internal CustomLVItem(string s, long o)
            {
                this.Text = s;
                this.SubItems.Add("0x" +o.ToString("X"));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
