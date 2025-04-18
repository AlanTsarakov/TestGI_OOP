using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGI
{
    public partial class FormTop : Form
    {
        List<User> users;
        User user = new User();
        public FormTop()
        {
            InitializeComponent();
            users = user.LoadUsersFromFile("data/results.json");


            dataGridViewTop.RowHeadersVisible = false;
            dataGridViewTop.ColumnCount = 3;
            dataGridViewTop.RowCount = users.Count;
            dataGridViewTop.Sort(dataGridViewTop.Columns[2], ListSortDirection.Ascending);

            int i = 0;
            foreach (var item in users)
            {
                dataGridViewTop[0, i].Value = users[i].Name;
                dataGridViewTop[1, i].Value = users[i].Diagnosis;
                dataGridViewTop[2, i].Value = users[i].Points;
                i++;
            }
            
        }

        private void FormTop_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewTop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
