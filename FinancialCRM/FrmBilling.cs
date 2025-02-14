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

namespace FinancialCRM
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCRMEntities db = new FinancialCRMEntities();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Tbl_Bill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Tbl_Bill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string billName = textBoxTitle.Text;
            decimal amount = Convert.ToDecimal(textBoxAmount.Text);
            string period = textBoxPeriod.Text;

            Tbl_Bill bill = new Tbl_Bill();
            bill.BillTitle = billName;
            bill.BillAmount = amount;
            bill.BillPeriod = period;

            db.Tbl_Bill.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Bill added successfully");
            btnList_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);
            var bill = db.Tbl_Bill.Find(id);
            db.Tbl_Bill.Remove(bill);
            db.SaveChanges();
            MessageBox.Show("Bill deleted successfully");
            btnList_Click(null, null);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);
            var bill = db.Tbl_Bill.Find(id);
            bill.BillTitle = textBoxTitle.Text;
            bill.BillAmount = Convert.ToDecimal(textBoxAmount.Text);
            bill.BillPeriod = textBoxPeriod.Text;
            db.SaveChanges();
            MessageBox.Show("Bill updated successfully");
            btnList_Click(null, null);
        }

        private void btnBankalar_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Close();
        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmBilling_Load(sender,e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.Show();
            this.Close();
        }
    }
}
