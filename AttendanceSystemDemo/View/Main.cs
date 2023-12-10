using AttendanceSystemDemo.BusinessLayer;
using AttendanceSystemDemo.Presenter;
using AttendanceSystemDemo.View;
using AttendanceSystemDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AttendanceSystemDemo
{
    public class DatabaseHandler
    {
        private readonly string connectionString;

        public DatabaseHandler()
        {
            // Обновите строку подключения вашими данными для MySQL сервера
            connectionString = "Server=localhost;Port=3306;Database=worktime;User=root;Password=root;";
        }

        public void InsertUserData(string employeeId, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO worktime (EmployeeId, Password) VALUES (@EmployeeId, @Password)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@Password", password);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
    public partial class Main : Form, ILoginView
	{
		private LoginPresenter _loginPresenter;

		public string EmployeeId
		{
			get => txtId.Text;
			set => txtId.Text = value;
		}

		public string Password
		{
			get => txtPassword.Text;
			set => txtPassword.Text = value;
		}

		public Main()
		{
			InitializeComponent();

			_loginPresenter = new LoginPresenter(this, new Logger());
		}

		private void Login(object sender, EventArgs e)
		{
			//_loginPresenter.Login();

			var empLoginViewModel = new EmployeeLoginViewModel
			{
				EmployeeId = EmployeeId,
				Password = Password
			};

			_loginPresenter.Login(empLoginViewModel);
		}

		private void Register(object sender, EventArgs e)
		{
			_loginPresenter.Register();
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
