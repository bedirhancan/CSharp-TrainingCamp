using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKamp301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = textBoxName.Text;
            guide.GuideSurname = textBoxSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Guide Added");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);
            var guide = db.Guide.Find(id);
            db.Guide.Remove(guide);
            db.SaveChanges();
            MessageBox.Show("Guide Deleted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);
            var guide = db.Guide.Find(id);
            guide.GuideName = textBoxName.Text;
            guide.GuideSurname = textBoxSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Guide Updated","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);
            var guide = db.Guide.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = guide;
        }
    }
}
