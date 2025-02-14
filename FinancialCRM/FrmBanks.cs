using FinancialCRM.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCRM
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCRMEntities db = new FinancialCRMEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            // Banka Bakiyeleri
            var ziraatbalance = db.Tbl_Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(x => x.BankBalance).FirstOrDefault();
            var isbankbalance = db.Tbl_Banks.Where(x => x.BankTitle == "İş Bankası").Select(x => x.BankBalance).FirstOrDefault();
            var paparabalance = db.Tbl_Banks.Where(x => x.BankTitle == "Papara").Select(x => x.BankBalance).FirstOrDefault();

            lblZiraatBalance.Text = ziraatbalance.ToString() + " ₺";
            lblisBalance.Text = isbankbalance.ToString() + " ₺";
            lblPaparaBalance.Text = paparabalance.ToString() + " ₺";

            // Banka Hareketleri
            var process1 = db.Tbl_Process.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            if (process1 != null)
            {
                var bankName = db.Tbl_Banks.Where(x => x.BankId == process1.BankId).Select(x => x.BankTitle).FirstOrDefault();
                lblProcess1.Text = $"{bankName} - {process1.Description} - {process1.Amount} ₺ - {process1.ProcessDate?.ToShortDateString()}";
            }

            var process2 = db.Tbl_Process.OrderByDescending(x => x.BankProcessId).Skip(1).Take(1).FirstOrDefault();
            if (process2 != null)
            {
                var bankName = db.Tbl_Banks.Where(x => x.BankId == process2.BankId).Select(x => x.BankTitle).FirstOrDefault();
                lblProcess2.Text = $"{bankName} - {process2.Description} - {process2.Amount} ₺ - {process2.ProcessDate?.ToShortDateString()}";
            }

            var process3 = db.Tbl_Process.OrderByDescending(x => x.BankProcessId).Skip(2).Take(1).FirstOrDefault();
            if (process3 != null)
            {
                var bankName = db.Tbl_Banks.Where(x => x.BankId == process3.BankId).Select(x => x.BankTitle).FirstOrDefault();
                lblProcess3.Text = $"{bankName} - {process3.Description} - {process3.Amount} ₺ - {process3.ProcessDate?.ToShortDateString()}";
            }

            var process4 = db.Tbl_Process.OrderByDescending(x => x.BankProcessId).Skip(3).Take(1).FirstOrDefault();
            if (process4 != null)
            {
                var bankName = db.Tbl_Banks.Where(x => x.BankId == process4.BankId).Select(x => x.BankTitle).FirstOrDefault();
                lblProcess4.Text = $"{bankName} - {process4.Description} - {process4.Amount} ₺ - {process4.ProcessDate?.ToShortDateString()}";
            }

            var process5 = db.Tbl_Process.OrderByDescending(x => x.BankProcessId).Skip(4).Take(1).FirstOrDefault();
            if (process5 != null)
            {
                var bankName = db.Tbl_Banks.Where(x => x.BankId == process5.BankId).Select(x => x.BankTitle).FirstOrDefault();
                lblProcess5.Text = $"{bankName} - {process5.Description} - {process5.Amount} ₺ - {process5.ProcessDate?.ToShortDateString()}";
            }
            }

        private void btnBankalar_Click(object sender, EventArgs e)
        {
            // Formu yeniden yükle
            FrmBanks_Load(sender, e);
        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Close();
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
