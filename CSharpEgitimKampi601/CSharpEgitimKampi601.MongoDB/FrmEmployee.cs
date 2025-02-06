using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601.MongoDB
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;port=5432;Database=customerdb;user Id=postgres;password=123";

        void EmployeeList()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("Select * from employees", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        void DepartmentList()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select * from departments";
                var command = new NpgsqlCommand(query, connection);
                var dataAdapter = new NpgsqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                comboBox.DisplayMember = "departmentname";
                comboBox.ValueMember = "departmentid";
                comboBox.DataSource = dataTable;
                connection.Close();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            EmployeeList();
            DepartmentList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "Insert into employees (employeename,employeesurname,employeesalary,departmentid) values (@p1,@p2,@p3,@p4)";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@p1", txtName.Text);
                command.Parameters.AddWithValue("@p2", txtSurname.Text);
                command.Parameters.AddWithValue("@p3", int.Parse(txtSalary.Text));
                command.Parameters.AddWithValue("@p4", comboBox.SelectedValue);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Employee added");
                EmployeeList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                int id = int.Parse(txtId.Text);
                string query = "Delete from employees where employeeid=@p1";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@p1", id);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Employee deleted");
                EmployeeList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                int id = int.Parse(txtId.Text);
                string query = "Update employees set employeename=@p1,employeesurname=@p2,employeesalary=@p3,departmentid=@p4 where employeeid=@p5";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@p1", txtName.Text);
                command.Parameters.AddWithValue("@p2", txtSurname.Text);
                command.Parameters.AddWithValue("@p3", int.Parse(txtSalary.Text));
                command.Parameters.AddWithValue("@p4", comboBox.SelectedValue);
                command.Parameters.AddWithValue("@p5", id);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Employee updated");
                EmployeeList();
            }
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                int id = int.Parse(txtId.Text);
                string query = "Select * from employees where employeeid=@p1";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@p1", id);
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }
    }
}
