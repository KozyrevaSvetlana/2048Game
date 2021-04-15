using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game
{
    class UserResults
    {
        public static string Path = "userResults.txt";
        public static void Append(User user)
        {
            var usersResults = GetAll();
            usersResults.Add(user);
            Save(usersResults);
        }

        public static List<User> GetAll()
        {
            if (!FileProvider.Exists(Path))
            {
                return new List<User>();
            }
            var fileData = FileProvider.Get(Path);
            var userResults = JsonConvert.DeserializeObject<List<User>>(fileData);
            return userResults;
        }

        static void Save(List<User> usersResults)
        {
            var jsonData = JsonConvert.SerializeObject(usersResults, Formatting.Indented);
            FileProvider.Replace(Path, jsonData);
        }
        public string GetStatistics()
        {
            StreamReader reader = new StreamReader(Path, Encoding.UTF8);
            var data = reader.ReadToEnd();
            reader.Close();
            return data;
        }
    }
}
