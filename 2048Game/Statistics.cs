using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class Statistics : Form
    {
        private List<User> users = new List<User>();
        public Statistics(List<User> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            foreach (var user in users)
            {
                StatisticDataGridView.Rows.Add(user.Name, user.Score, user.MapSize);
            }
        }
    }
}
