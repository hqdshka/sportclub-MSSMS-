using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace sportclub
{
    public partial class Form2 : Form
    {
        private SqlConnection Connection = new SqlConnection();
        public Form2()
        {
            InitializeComponent();
            Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=sportclub;Trusted_Connection=True;";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "select * from Client";
                command.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                DataTable dt = new DataTable();
                ada.SelectCommand = command;
                ada.Fill(dt);
                dataGridView1.DataSource = dt;

                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "insert into [Client](Client_ID, Surname, Name, Patronymic, Birthdate, Phone_number, Mail) values (" + client_id.Text + ",'" + surname.Text + "','" + name.Text + "','" + patronymic.Text + "','" + birthdate.Text + "','" + phone_number.Text + "', '" + mail.Text + "')";
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Сохранено!");
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "delete from Client where Client_id=" + client_id.Text + "";
                command.CommandText = query;

                DialogResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Удалено!");
                    Connection.Close();
                }

                if (res == DialogResult.Cancel)
                {
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "update Client set Surname='" + surname.Text + "', Name='" + name.Text + "', Patronymic='" + patronymic.Text + "', Birthdate='" + birthdate.Text + "', Phone_number='" + phone_number.Text + "', Mail = '" + mail.Text + "' where Client_ID=" + client_id.Text + "";
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Изменено!");
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                client_id.Text = row.Cells[0].Value.ToString();
                surname.Text = row.Cells[1].Value.ToString();
                name.Text = row.Cells[2].Value.ToString();
                patronymic.Text = row.Cells[3].Value.ToString();
                birthdate.Text = row.Cells[4].Value.ToString();
                phone_number.Text = row.Cells[5].Value.ToString();
                mail.Text = row.Cells[6].Value.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "select * from Service";
                command.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                DataTable dt = new DataTable();
                ada.SelectCommand = command;
                ada.Fill(dt);
                dataGridView2.DataSource = dt;

                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "insert into [Service](Service_ID, Action_time , Cost, Serv_Name, Visit_time) values (" + service_id.Text + ",'" + action_time.Text + "','" + cost.Text + "','" + serv_name.Text + "','" + visit_time.Text + "')";
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Сохранено!");
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "update Service set Action_time='" + action_time.Text + "', Cost='" + cost.Text + "', Serv_name='" + serv_name.Text + "', Visit_time='" + visit_time.Text + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Изменено!");
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "delete from Service where Service_id=" + service_id.Text + "";
                command.CommandText = query;

                DialogResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Удалено!");
                    Connection.Close();
                }

                if (res == DialogResult.Cancel)
                {
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView2.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                service_id.Text = row.Cells[0].Value.ToString();
                action_time.Text = row.Cells[1].Value.ToString();
                cost.Text = row.Cells[2].Value.ToString();
                serv_name.Text = row.Cells[3].Value.ToString();
                visit_time.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Connection.Close();
            Connection.Dispose();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "select * from requests where request_name='" + comboBox1.Text + "'";
                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    string query2 = reader["request_body"].ToString();
                    Connection.Close();
                    Connection.Open();
                    SqlCommand command2 = new SqlCommand();
                    command2.Connection = Connection;
                    command.CommandText = query2;

                    SqlDataAdapter ada = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    ada.SelectCommand = command;
                    ada.Fill(dt);
                    dataGridView3.DataSource = dt;
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "select * from requests";
                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["request_name"].ToString());
                }
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "select Position, avg(Salary) as avg_salary from Employee group by Position";
                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chart1.Series["Employees"].Points.AddXY(reader["Position"].ToString(), reader["avg_salary"].ToString());
                }
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                Connection.Close();
            }
        }
    }
}
        /*private void button4_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
            {
                this.Close();
                System.Windows.Forms.Application.Exit();
            }
        }*/

        
    

