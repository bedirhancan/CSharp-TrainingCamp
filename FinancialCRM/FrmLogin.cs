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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCRMEntities db = new FinancialCRMEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var user = db.Tbl_Users.FirstOrDefault(x => x.Username == textBoxUsername.Text && x.Password == textBoxPassword.Text);
            if (user != null)
            {
                FrmDashboard frm = new FrmDashboard();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }
        }
    }
}
