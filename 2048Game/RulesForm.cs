using System;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class RulesForm : Form
    {
        public RulesForm()
        {
            InitializeComponent();
        }

        private void OkRulesButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
