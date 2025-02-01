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
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        public CategoryForm()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Formun boyutunu sabitle
            this.MaximizeBox = false; // Maksimize etme butonunu devre dışı bırak
            this.Text = "Category Management"; // Formun başlığını ayarla
            dataGridView1.CellClick += dataGridView1_CellClick; // Hücre tıklama olayını bağla
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading categories.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while listing categories.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _categoryService.TGetAll();
                dataGridView1.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading categories in LoadCategories method.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtCatName.Clear();
            radioActive.Checked = false;
            radioPassive.Checked = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = txtCatName.Text,
                    CategoryStatus = radioActive.Checked ? true : false
                };
                _categoryService.TInsert(category);
                MessageBox.Show("Category inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting the category.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int deletedCategoryId))
            {
                try
                {
                    var value = _categoryService.TGetById(deletedCategoryId);
                    if (value != null)
                    {
                        _categoryService.TDelete(value);
                        MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the category.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                try
                {
                    var category = _categoryService.TGetById(id);
                    if (category != null)
                    {
                        txtCatName.Text = category.CategoryName;
                        if (category.CategoryStatus)
                        {
                            radioActive.Checked = true;
                        }
                        else
                        {
                            radioPassive.Checked = true;
                        }
                        dataGridView1.DataSource = new List<Category> { category }; // Tek bir nesneyi listeye sar
                    }
                    else
                    {
                        MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while getting the category.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int updatedCategoryId))
            {
                try
                {
                    var category = _categoryService.TGetById(updatedCategoryId);
                    if (category != null)
                    {
                        category.CategoryName = txtCatName.Text;
                        category.CategoryStatus = radioActive.Checked ? true : false;
                        _categoryService.TUpdate(category);
                        MessageBox.Show("Category updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the category.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"].Value.ToString();
                txtCatName.Text = row.Cells["CategoryName"].Value.ToString();
                bool status = Convert.ToBoolean(row.Cells["CategoryStatus"].Value);
                if (status)
                {
                    radioActive.Checked = true;
                }
                else
                {
                    radioPassive.Checked = true;
                }
            }
        }
    }
}
