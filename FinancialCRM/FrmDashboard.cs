using FinancialCRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCRM.Models;

namespace FinancialCRM
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        FinancialCRMEntities db = new FinancialCRMEntities();
        int count = 0;
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard_Load(null, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var values = db.Tbl_Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = values.ToString() + " ₺";

            var maxSpending = db.Tbl_Spending.Max(Tbl_Spending => Tbl_Spending.SpendingAmount);
            lblMaxSpend.Text = maxSpending.ToString() + " ₺";

            var maxSpendingEntry = db.Tbl_Spending
                .Where(x => x.SpendingAmount == maxSpending)
                .OrderByDescending(x => x.SpendingDate)
                .FirstOrDefault();

            lblSpendTitle.Text = maxSpendingEntry?.SpendingTitle;

            // Chart
            var banks = db.Tbl_Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Bank Balances");
            foreach (var item in banks)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);  
            }

            //Chart 2
            var bill = db.Tbl_Bill.Select(Select => new
            {
                Select.BillTitle,
                Select.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Bills");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in bill)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void btnBankalar_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 4 == 1)
            {
                var telefonFaturasi = db.Tbl_Bill.Where(x => x.BillTitle == "Telefon").Select(x => x.BillAmount).FirstOrDefault();
                lblFaturaBaslik.Text = "Telefon Faturası";
                lblFatura.Text = $"{telefonFaturasi} ₺";
            }
            if (count % 4 == 2)
            {
                var SpotifyFaturasi = db.Tbl_Bill.Where(x => x.BillTitle == "Spotify").Select(x => x.BillAmount).FirstOrDefault();
                lblFaturaBaslik.Text = "Spotify Faturası";
                lblFatura.Text = $"{SpotifyFaturasi} ₺";
            }
            if (count % 4 == 3)
            {
                var NetflixFaturasi = db.Tbl_Bill.Where(x => x.BillTitle == "Netflix").Select(x => x.BillAmount).FirstOrDefault();
                lblFatura.Text = $"{NetflixFaturasi} ₺";
                lblFaturaBaslik.Text = "Netflix Faturası";
            }
            if (count % 4 == 0)
            {
                var HepsiburadaFaturasi = db.Tbl_Bill.Where(x => x.BillTitle == "Hepsiburada").Select(x => x.BillAmount).FirstOrDefault();
                lblFaturaBaslik.Text = "Hepsiburada Faturası";
                lblFatura.Text = $"{HepsiburadaFaturasi} ₺";
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Close();
        }
    }
}
