using System;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class SizeForm : Form
    {
        public SizeForm()
        {
            InitializeComponent();
        }


        private void sizeFourButton_Click_1(object sender, EventArgs e)
        {
            MainForm.mapSize = 4;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void sizeFiveButton_Click_1(object sender, EventArgs e)
        {
            MainForm.mapSize = 5;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void sizeSixButton_Click_1(object sender, EventArgs e)
        {
            MainForm.mapSize = 6;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
