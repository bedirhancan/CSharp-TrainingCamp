using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class LocationForm : Form
    {
        public LocationForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick; // CellClick olayını bağlama
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Formun boyutunu sabitle
            this.MaximizeBox = false; // Maksimize etme butonunu devre dışı bırak
            this.Size = new Size(645, 501); // Formun boyutunu belirle
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void LocationForm_Load(object sender, EventArgs e)
        {
            LoadGuides();
            LoadLocations();
        }

        private void LoadGuides()
        {
            var guides = db.TblGuide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            boxGuide.DisplayMember = "FullName";
            boxGuide.ValueMember = "GuideId";
            boxGuide.DataSource = guides;
        }

        private void LoadLocations()
        {
            var locations = db.TblLocation.ToList();
            dataGridView1.DataSource = locations;
        }

        private void ClearFields()
        {
            txtCity.Clear();
            txtCountry.Clear();
            nmrcCapacity.Value = 0;
            txtPrice.Clear();
            txtDayNight.Clear();
            boxGuide.SelectedIndex = -1;
            txtId.Clear();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var location = new TblLocation
                {
                    LocationCity = txtCity.Text,
                    LocationCountry = txtCountry.Text,
                    LocationCapacity = Convert.ToByte(nmrcCapacity.Value),
                    LocationPrice = Convert.ToDecimal(txtPrice.Text),
                    DayNight = txtDayNight.Text,
                    GuideId = (int)boxGuide.SelectedValue
                };
                db.TblLocation.Add(location);
                db.SaveChanges();
                MessageBox.Show("Location added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLocations();
                ClearFields();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("An error occurred while adding the location. Please check the details and try again.\n" + ex.InnerException?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int locationId = int.Parse(txtId.Text);
                var location = db.TblLocation.Find(locationId);
                if (location != null)
                {
                    db.TblLocation.Remove(location);
                    db.SaveChanges();
                    MessageBox.Show("Location deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLocations();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Location not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the location.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int locationId = int.Parse(txtId.Text);
                var location = db.TblLocation.Find(locationId);
                if (location != null)
                {
                    location.LocationCity = txtCity.Text;
                    location.LocationCountry = txtCountry.Text;
                    location.LocationCapacity = Convert.ToByte(nmrcCapacity.Value);
                    location.LocationPrice = Convert.ToDecimal(txtPrice.Text);
                    location.DayNight = txtDayNight.Text;
                    location.GuideId = (int)boxGuide.SelectedValue;
                    db.SaveChanges();
                    MessageBox.Show("Location updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLocations();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Location not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("An error occurred while updating the location. Please check the details and try again.\n" + ex.InnerException?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["LocationId"].Value.ToString();
                txtCity.Text = row.Cells["LocationCity"].Value.ToString();
                txtCountry.Text = row.Cells["LocationCountry"].Value.ToString();
                nmrcCapacity.Value = Convert.ToDecimal(row.Cells["LocationCapacity"].Value);
                txtPrice.Text = row.Cells["LocationPrice"].Value.ToString();
                txtDayNight.Text = row.Cells["DayNight"].Value.ToString();
                boxGuide.SelectedValue = row.Cells["GuideId"].Value;
            }
        }
    }
}
