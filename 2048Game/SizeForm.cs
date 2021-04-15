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
            Close();
        }

        private void sizeFiveButton_Click_1(object sender, EventArgs e)
        {
            MainForm.mapSize = 5;
            Close();
        }

        private void sizeSixButton_Click_1(object sender, EventArgs e)
        {
            MainForm.mapSize = 6;
            Close();
        }

        private void SizeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dialog = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            //if (dialog == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
