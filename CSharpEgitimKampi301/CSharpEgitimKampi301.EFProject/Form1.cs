using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                var values = db.TblGuide.ToList();
                dataGridView1.DataSource = values;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while listing guides: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearTextBoxes();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Name and Surname cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TblGuide tblGuide = new TblGuide
                {
                    GuideName = txtName.Text,
                    GuideSurname = txtSurname.Text
                };
                db.TblGuide.Add(tblGuide);
                db.SaveChanges();
                MessageBox.Show("Guide Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnList_Click(sender, e); // Refresh the list
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the guide: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearTextBoxes();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Please enter a valid ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var guide = db.TblGuide.Find(id);
                if (guide == null)
                {
                    MessageBox.Show("Guide not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.TblGuide.Remove(guide);
                db.SaveChanges();
                MessageBox.Show("Guide Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnList_Click(sender, e); // Refresh the list
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the guide: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearTextBoxes();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Please enter a valid ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Name and Surname cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var guide = db.TblGuide.Find(id);
                if (guide == null)
                {
                    MessageBox.Show("Guide not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                guide.GuideName = txtName.Text;
                guide.GuideSurname = txtSurname.Text;
                db.SaveChanges();
                MessageBox.Show("Guide Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnList_Click(sender, e); // Refresh the list
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the guide: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearTextBoxes();
            }
        }

        private void btnListWithID_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Please enter a valid ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var values = db.TblGuide.Where(x => x.GuideId == id).ToList();
                dataGridView1.DataSource = values;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while listing guides: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            txtId.Clear();
            txtName.Clear();
            txtSurname.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["GuideId"].Value.ToString();
                txtName.Text = row.Cells["GuideName"].Value.ToString();
                txtSurname.Text = row.Cells["GuideSurname"].Value.ToString();
            }
        }
    }
}
