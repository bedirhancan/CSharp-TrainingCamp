using CSharpEgitimKampi601.MongoDB.Entities;
using CSharpEgitimKampi601.MongoDB.Services;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        CustomerOperations customerOperations = new CustomerOperations();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var customers = customerOperations.GetAllCustomers();
            dataGridView1.DataSource = customers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Entities.Customer
            {
                CustomerName = txtName.Text,
                CustomerSurname = txtSurname.Text,
                CustomerCity = comboCity.SelectedItem.ToString(),
                CustomerBalance = Convert.ToInt32(nmrcAccount.Value),
                CustomerShoppingCount = Convert.ToInt32(nmrcTotal.Value)
            };

            customerOperations.AddCustomer(customer);
            MessageBox.Show("Customer added successfully.");
            ClearCustomerFields();
            RefreshCustomerList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Customer deleted successfully.");
            ClearCustomerFields();
            RefreshCustomerList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            var customer = new Customer()
            {
                CustomerName = txtName.Text,
                CustomerSurname = txtSurname.Text,
                CustomerCity = comboCity.SelectedItem.ToString(),
                CustomerBalance = Convert.ToInt32(nmrcAccount.Value),
                CustomerShoppingCount = Convert.ToInt32(nmrcTotal.Value),
                CustomerID = id
            };
            customerOperations.UpdateCustomer(customer);
            MessageBox.Show("Customer updated successfully.");
            ClearCustomerFields();
            RefreshCustomerList();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            var id = txtId.Text;
            Customer customerById = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customerById };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCustomerFields();
        }

        private void ClearCustomerFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtSurname.Clear();
            comboCity.SelectedIndex = -1;
            nmrcAccount.Value = 0;
            nmrcTotal.Value = 0;
        }

        private void RefreshCustomerList()
        {
            var customers = customerOperations.GetAllCustomers();
            dataGridView1.DataSource = customers;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["CustomerID"].Value.ToString();
                txtName.Text = row.Cells["CustomerName"].Value.ToString();
                txtSurname.Text = row.Cells["CustomerSurname"].Value.ToString();
                comboCity.SelectedItem = row.Cells["CustomerCity"].Value.ToString();
                nmrcAccount.Value = Convert.ToInt32(row.Cells["CustomerBalance"].Value);
                nmrcTotal.Value = Convert.ToInt32(row.Cells["CustomerShoppingCount"].Value);
            }
        }
    }
}
