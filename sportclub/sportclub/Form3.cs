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

namespace sportclub
{
    public partial class Form3 : Form
    {
        private SqlConnection Connection = new SqlConnection();
        public Form3()
        {
            InitializeComponent();
            Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=sportclub;Trusted_Connection=True;";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                string query = "select * from Service where Action_time LIKE '%"+searchtxt.Text+"%' OR Cost LIKE '%"+searchtxt.Text+ "%' OR Serv_Name LIKE '%"+searchtxt.Text+ "%' OR Visit_time LIKE '%"+searchtxt.Text+"%'";

                command.CommandText = query;

                SqlDataAdapter ada = new SqlDataAdapter();
                DataTable dt = new DataTable();
                ada.SelectCommand = command;
                ada.Fill(dt);
                dataGridView3.DataSource = dt;

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
