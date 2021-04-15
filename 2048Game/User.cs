

namespace _2048Game
{
    public class User
    {
        public string Name;
        public int Score;
        public int MapSize;
        public User(string name, int mapSize)
        {
            Name = name;
            Score = 0;
            MapSize = mapSize;
        }
        public User(string name, int score, int mapSize)
        {
            Name = name;
            Score = score;
            MapSize = mapSize;
        }
    }
}
