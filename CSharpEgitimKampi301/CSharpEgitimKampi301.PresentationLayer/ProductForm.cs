using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductForm()
        {
            _productService = new ProductManager(new EfProductDal());
            InitializeComponent();
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.GetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = Convert.ToInt32(comboCategory.SelectedValue.ToString());
            product.ProductName = txtName.Text;
            product.ProductPrice = Convert.ToDecimal(txtPrice.Text);
            product.ProductStock = Convert.ToInt32(txtStock.Text);
            product.ProductDescription = txtDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Product inserted successfully.");
            btnList_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            MessageBox.Show("Product deleted successfully.");
            btnList_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = _productService.TGetById(id);
            value.CategoryId = Convert.ToInt32(comboCategory.SelectedValue.ToString());
            value.ProductName = txtName.Text;
            value.ProductPrice = Convert.ToDecimal(txtPrice.Text);
            value.ProductStock = Convert.ToInt32(txtStock.Text);
            value.ProductDescription = txtDescription.Text;
            _productService.TUpdate(value);
            MessageBox.Show("Product updated successfully.");
            btnList_Click(sender, e);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource = new List<Product> { value };
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            comboCategory.DataSource = values;
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryId";
        }
    }
}
