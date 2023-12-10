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
using MySql.Data.MySqlClient;

namespace AttendanceSystemDemo
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = "Server=localhost;Port=3306;Database=employeedb;User=root;Password=root;"; // Замените на ваше соединение с базой данных

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM employees"; // Замените на имя вашей таблицы
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Отображаем данные
                        DisplayEmployeeData(dataTable);
                    }
                }
            }
        }
        private void DisplayEmployeeData(DataTable dataTable)
        {
            // Очищаем существующие элементы формы
            ClearForm();

            foreach (DataRow row in dataTable.Rows)
            {
                // Получаем данные из строки таблицы
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                string position = row["Position"].ToString();
                string workplace = row["Workplace"].ToString();
                byte[] imageBytes = (byte[])row["ImageData"]; // Предполагается, что изображение хранится в виде байтов в базе данных
                Image image = ByteArrayToImage(imageBytes);

                // Создаем элементы формы для отображения информации
                Label nameLabel = new Label { Text = $"{firstName} {lastName}", AutoSize = true };
                PictureBox pictureBox = new PictureBox { Image = image, SizeMode = PictureBoxSizeMode.StretchImage };
                Label positionLabel = new Label { Text = $"Position: {position}", AutoSize = true };
                Label workplaceLabel = new Label { Text = $"Workplace: {workplace}", AutoSize = true };

                // Добавляем элементы на форму
                flowLayoutPanel1.Controls.Add(nameLabel);
                flowLayoutPanel1.Controls.Add(pictureBox);
                flowLayoutPanel1.Controls.Add(positionLabel);
                flowLayoutPanel1.Controls.Add(workplaceLabel);
            }
        }
        private void ClearForm()
        {
            // Очищаем содержимое панели перед добавлением новых элементов
            flowLayoutPanel1.Controls.Clear();
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
                return null;

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
                
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
