using System;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class SizeForm : Form
    {
        public int mapSize;
        public SizeForm()
        {
            InitializeComponent();
        }


        private void sizeFourButton_Click_1(object sender, EventArgs e)
        {
            mapSize = 4;
            Close();
        }

        private void sizeFiveButton_Click_1(object sender, EventArgs e)
        {
            mapSize = 5;
            Close();
        }

        private void sizeSixButton_Click_1(object sender, EventArgs e)
        {
            mapSize = 6;
            Close();
        }
    }
}
