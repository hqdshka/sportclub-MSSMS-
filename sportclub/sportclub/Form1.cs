using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sportclub
{
    public partial class Form1 : Form
    {
       private SqlConnection Connection = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
            Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=sportclub;Trusted_Connection=True;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = Connection;
            command.CommandText = "select * from login where login='" + username.Text + "' and password='" + password.Text + "'";
            SqlDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
                MessageBox.Show("Успешно!");
                Connection.Close();
                Connection.Dispose();
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            if (count > 1)
            {
                MessageBox.Show("Ошибка! Дублирование логина и пароля");
                Connection.Close();
            }
            if (count == 0) { MessageBox.Show("Ошибка! Неверный логин или пароль");Connection.Close(); }
        }
    }
}
