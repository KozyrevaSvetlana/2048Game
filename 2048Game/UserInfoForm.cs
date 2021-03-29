using System;
using System.Windows.Forms;
using static _2048Game.MainForm;

namespace _2048Game
{
    public partial class UserInfoForm : Form
    {
        private User user;

        public UserInfoForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void OkUserNameButton_Click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Введите Ваше имя");
                return;
            }
            user.Name = userNameTextBox.Text;
            Close();

        }
    }
}
