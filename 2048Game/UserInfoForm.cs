using System;
using System.Text.RegularExpressions;
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
                MessageBox.Show("Введите имя");
                userNameTextBox.Focus();
                return;
            }
            user.Name = userNameTextBox.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(userNameTextBox.Text, "[^0-9a-zA-Zа-яА-Я]"))
            {
                MessageBox.Show("Недопустимое имя. Оно должно содержать только буквы и/или цифры");
                userNameTextBox.Text = userNameTextBox.Text.Remove(userNameTextBox.Text.Length - 1);
                userNameTextBox.SelectionStart = userNameTextBox.Text.Length;
            }
        }

        private void UserInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                OkUserNameButton.PerformClick();
            }
        }

        private void UserInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (userNameTextBox.Text == string.Empty)
            //{
            //    DialogResult dialog = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            //    if (dialog == DialogResult.Yes)
            //    {
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}

        }
    }
}
