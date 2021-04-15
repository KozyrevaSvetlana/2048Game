using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class MainForm : Form
    {
        public string results = "results.txt";
        public string BestScorePath = "bestscore.txt";
        private int bestScore;
        public static int mapSize = 4;
        private Label[,] labelsMap;
        private static Random random = new Random();
        User user = new User("Неизвестно", 4);
        private bool victory = false;
        public bool isExit;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var userInfoForm = new UserInfoForm(user);
            var resultUserNameForm = userInfoForm.ShowDialog(this);
            resultUserNameForm = ToExit(userInfoForm, resultUserNameForm, isExit);
            var sizeForm = new SizeForm();
            var resultSizeForm = sizeForm.ShowDialog();
            resultUserNameForm = ToExit(sizeForm, resultSizeForm, isExit);
            user.MapSize = mapSize;
            ClientSize = new Size(76 * mapSize + 12, 76 * mapSize + 76);
            bestScore = GetBestScore();
            ShowScore();
            InitMap();
            GenerateNumber();

        }
        private DialogResult ToExit(Form form, DialogResult result, bool isExit)
        {
            isExit = result == DialogResult.OK ? false : true;
            if (result != DialogResult.OK)
            {
                while (isExit)
                {
                    DialogResult dialog = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        isExit = false;
                        Application.Exit();
                    }
                    else
                    {
                        result = form.ShowDialog(this);
                    }
                }
            }
            return result;
        }
        private void ShowScore()
        {
            scoreLabel.Text = user.Score.ToString();
            if (user.Score > bestScore)
            {
                bestScore = user.Score;
            }
            bestScoreNumberLabel.Text = bestScore.ToString();
        }
        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
        }
        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(70, 70);
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + indexColumn * 76;
            int y = 70 + indexRow * 76;
            label.Location = new Point(x, y);
            label.TextChanged += Label_TextChanged;
            return label;
        }
        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = (Label)sender;
            UpdateLabelBackColor(label);
            if (label.Text == "2048")
            {
                victory = true;
            }

        }
        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexColumn = randomNumberLabel % mapSize;
                var randomNumber = random.Next(1, 5);
                randomNumber = randomNumber < 4 ? 2 : 4;
                if (labelsMap[indexRow, indexColumn].Text == string.Empty)
                {
                    labelsMap[indexRow, indexColumn].Text = randomNumber.ToString();
                    UpdateLabelBackColor(labelsMap[indexRow, indexColumn]);
                    break;
                }
            }

        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                return;
            }

            bool isMerged = false;
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        user.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[i, k].Text = string.Empty;
                                        isMerged = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[i, k].Text;
                                    labelsMap[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        user.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[i, k].Text = string.Empty;
                                        isMerged = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[i, k].Text;
                                    labelsMap[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        user.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[k, j].Text = string.Empty;
                                        isMerged = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[k, j].Text;
                                    labelsMap[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        user.Score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[k, j].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[k, j].Text;
                                    labelsMap[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            ShowScore();
            if (IsFullMap() && !isMerged)
            {
                MessageBox.Show($"Игра окончена. Ваш счет: {user.Score}");
            }
            if (victory)
            {
                MessageBox.Show($"Поздравляем! Вы набрали 2048 очков. Ваш счет: {user.Score}");
            }
            GenerateNumber();

        }
        private void UpdateLabelBackColor(Label label)
        {
            int indicatorTwo = 0;
            if (label.Text == string.Empty)
            {
                indicatorTwo = 0;

            }
            else
            {
                var number = Int32.Parse(label.Text);
                indicatorTwo = (int)Math.Log(number, 2);
            }

            Color[] colors = new Color[12];
            colors[0] = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            colors[1] = Color.LemonChiffon;
            colors[2] = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            colors[3] = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            colors[4] = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            colors[5] = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            colors[6] = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            colors[7] = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            colors[8] = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            colors[9] = Color.Thistle;
            colors[10] = Color.Violet;
            colors[11] = Color.Red;
            label.BackColor = colors[indicatorTwo];
        }
        private bool IsFullMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserResults(results, user);
            SaveBestScore();
        }

        private void SaveBestScore()
        {
            if (bestScore>0)
            {
                var writer = new StreamWriter(BestScorePath, false);
                writer.WriteLine(bestScore);
                writer.Close();
            }
        }

        private void выходИзИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из игры?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите начать игру заново?", "Рестарт", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Restart();
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rulesForm = new RulesForm();
            rulesForm.ShowDialog();
        }
        private static void SaveUserResults(User user, string userResultsPath)
        {
            var formattedData = user.Name+"$"+user.Score;
            StreamWriter writer = new StreamWriter(userResultsPath, true, Encoding.UTF8);
            writer.WriteLine(formattedData);
            writer.Close();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultList = new List<User>();
            resultList = ViewStatistics();
            var resultForm = new Statistics(resultList);
            resultForm.Show();
        }
        private int GetBestScore()
        {
            if (File.Exists(BestScorePath))
            {
                var reader = new StreamReader(BestScorePath);
                var bestScore = Convert.ToInt32(reader.ReadLine());
                reader.Close();
                return bestScore;
            }
            else
            {
                return 0;
            }
        }
        public List<User> ViewStatistics()
        {
            var list = new List<User>();
            StreamReader reader = new StreamReader(results, Encoding.UTF8);
            var data = reader.ReadToEnd();
            reader.Close();
            var lines = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var result = line.Split('$');
                var score = Int32.Parse(result[1]);
                var mapSize = Int32.Parse(result[2]);
                var user = new User(result[0], score, mapSize);
                list.Add(user);
            }
            return list;
        }

        public void SaveUserResults(string path,User user)
        {
            if (user.Score>0)
            {
                var data = user.Name + "$" + user.Score + "$" + user.MapSize;
                StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8);
                writer.WriteLine(data);
                writer.Close();
            }
        }

    }
}
