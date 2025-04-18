using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TestGI
{
    public partial class FormSaveResult : Form
    {
        int Points = 0;
        List<User> users = new List<User>();
        User user;
        public FormSaveResult(int Points)
        {
            this.Points = Points;
            InitializeComponent();
        }

        private void FormSaveResult_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            user = new User(textBoxName.Text, Points);

            if (!string.IsNullOrEmpty(textBoxName.Text))
            {
                
                try
                {
                    users = LoadUsersFromFile("data/results.json");
                }
                catch (Exception)
                {

                }

                SaveUserFromFile();

                Close();
            }
            else
            {
                MessageBox.Show("Введите имя пользователя!");
            }
        }

        public void SaveUserFromFile()
        {
            users.Add(user);
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText("data/results.json", json);
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
