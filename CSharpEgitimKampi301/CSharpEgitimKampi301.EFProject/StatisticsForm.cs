using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblLocationCount.Text = db.TblLocation.Count().ToString();
                lblSumCapacity.Text = db.TblLocation.Sum(x => x.LocationCapacity).ToString();
                lblGuideCount.Text = db.TblGuide.Count().ToString();
                lblAvgCapacity.Text = db.TblLocation.Average(x => x.LocationCapacity).ToString();
                lblAvgLocPrice.Text = db.TblLocation.Average(x => x.LocationPrice).Value.ToString("F2") + " ₺";

                int locationId = db.TblLocation.Max(x => x.LocationId);
                lblLastCity.Text = db.TblLocation.Where(x => x.LocationId == locationId).Select(x => x.LocationCity).FirstOrDefault();

                lblTurkeyCapacity.Text = db.TblLocation.Where(x => x.LocationCountry == "Türkiye").Sum(x => x.LocationCapacity).ToString();

                lblKonyaCapacity.Text = db.TblLocation.Where(x => x.LocationCity == "Konya").Sum(x => x.LocationCapacity).ToString();

                var konyaGuideId = db.TblLocation.Where(x => x.LocationCity == "Konya").Select(x => x.GuideId).FirstOrDefault();
                lblKonyaGuide.Text = db.TblGuide.Where(x => x.GuideId == konyaGuideId).Select(x => x.GuideName + " " + x.GuideSurname).FirstOrDefault();

                lblMaxCity.Text = db.TblLocation.Where(x => x.LocationCapacity == db.TblLocation.Max(y => y.LocationCapacity)).Select(x => x.LocationCity).FirstOrDefault();

                lblMaxPriceCity.Text = db.TblLocation.Where(x => x.LocationPrice == db.TblLocation.Max(y => y.LocationPrice)).Select(x => x.LocationCity).FirstOrDefault();

                lblAvgTurkey.Text = db.TblLocation.Where(x => x.LocationCountry == "Türkiye").Average(x => x.LocationPrice).Value.ToString("F2") + " ₺";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading statistics.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
