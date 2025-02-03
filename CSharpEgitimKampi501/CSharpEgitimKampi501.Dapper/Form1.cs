using CSharpEgitimKampi501.Dapper.Dtos;
using Dapper;
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

namespace CSharpEgitimKampi501.Dapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly string connectionString = "Data Source=DESKTOP-IVK249I\\SQLEXPRESS;Initial Catalog=CSharpEgitimKampi501.DapperDB;Integrated Security=True";

        private async void btnList_Click(object sender, EventArgs e)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductTable";
                var values = await sqlConnection.QueryAsync<ResultProductDto>(query);
                dataGridView1.DataSource = values.ToList();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductTable (ProductName, ProductStock, ProductPrice, ProductCategory) values " +
                               "(@productName, @productStock, @productPrice, @productCategory)";
                var parameters = new DynamicParameters();
                parameters.Add("@productName", txtName.Text);
                parameters.Add("@productStock", txtStock.Text);
                parameters.Add("@productPrice", txtPrice.Text);
                parameters.Add("@productCategory", txtCategory.Text);
                int v = await sqlConnection.ExecuteAsync(query, parameters);
                MessageBox.Show("Ürün Eklendi");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductTable WHERE ProductId = @productId";
                var parameters = new DynamicParameters();
                parameters.Add("@productId", txtId.Text);
                int v = await sqlConnection.ExecuteAsync(query, parameters);
                MessageBox.Show("Ürün Silindi");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductTable SET ProductName = @productName, ProductStock = @productStock, ProductPrice = @productPrice, ProductCategory = @productCategory WHERE ProductId = @productId";
                var parameters = new DynamicParameters();
                parameters.Add("@productId", txtId.Text);
                parameters.Add("@productName", txtName.Text);
                parameters.Add("@productStock", txtStock.Text);
                parameters.Add("@productPrice", txtPrice.Text);
                parameters.Add("@productCategory", txtCategory.Text);
                int v = await sqlConnection.ExecuteAsync(query, parameters);
                MessageBox.Show("Ürün Güncellendi");
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string query1 = "Select Count(*) from ProductTable";
                var count = await sqlConnection.ExecuteScalarAsync<int>(query1);
                lblBookCount.Text = count.ToString();

                string query2 = "Select ProductName From ProductTable Where ProductPrice = (Select Max(ProductPrice) From ProductTable)";
                var maxPrice = await sqlConnection.ExecuteScalarAsync<string>(query2);
                lblPriceMax.Text = maxPrice;

                string query3 = "Select Count(distinct ProductCategory) from ProductTable";
                var categoryCount = await sqlConnection.ExecuteScalarAsync<int>(query3);
                lblCategoryCount.Text = categoryCount.ToString();
            }
        }
    }
}
