using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TestGI
{
    public class User
    {
        public string Name;
        public string Diagnosis;
        public int Points;
        public User(string name, string diagnosis, int points)
        {
            Name = name;
            Diagnosis = diagnosis;
            Points = points;
        }
        public User()
        {

        }

        public List<User> LoadUsersFromFile(string path)
        {
            if (!File.Exists(path))
            {
                return new List<User>(); // Возвращаем пустой список, если файла нет
            }

            string json = File.ReadAllText(path);


            if (string.IsNullOrEmpty(json))
            {
                return new List<User>();
            }

            return JsonConvert.DeserializeObject<List<User>>(json);
        }


    }
}