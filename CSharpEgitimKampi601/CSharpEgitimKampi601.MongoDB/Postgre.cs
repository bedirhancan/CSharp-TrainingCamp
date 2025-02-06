using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601.MongoDB
{
    public partial class Postgre : Form
    {
        public Postgre()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;Port=5432;Database=customerdb;User Id=postgres;Password=123;";
        
        void getAllCustomers()
        {
            using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(connectionString))
            {
                connection.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("SELECT * FROM customers order by customerid", connection);
                Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            getAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text;
            string customerSurname = txtSurname.Text;
            string customerCity = comboCity.Text;
            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO customers (customername, customersurname, customercity) VALUES (@name, @surname, @city)";
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", customerName);
            command.Parameters.AddWithValue("@surname", customerSurname);
            command.Parameters.AddWithValue("@city", customerCity);
            command.ExecuteNonQuery();
            MessageBox.Show("Customer added successfully!");
            connection.Close();
            getAllCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "DELETE FROM customers WHERE customerid = @id";
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Customer deleted successfully!");
            connection.Close();
            getAllCustomers();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text;
            string customerSurname = txtSurname.Text;
            string customerCity = comboCity.Text;
            int id = Convert.ToInt32(txtId.Text);
            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE customers SET customername = @name, customersurname = @surname, customercity = @city WHERE customerid = @id";
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", customerName);
            command.Parameters.AddWithValue("@surname", customerSurname);
            command.Parameters.AddWithValue("@city", customerCity);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Customer updated successfully!");
            connection.Close();
            getAllCustomers();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(connectionString))
            {
                connection.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("SELECT * FROM customers WHERE customerid = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
