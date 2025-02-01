using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
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
        public ProductForm()
        {
            _productService = new ProductManager(new EfProductDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.GetProductsWithCategory();
            dataGridView1.DataSource = values;
        }
    }
}
