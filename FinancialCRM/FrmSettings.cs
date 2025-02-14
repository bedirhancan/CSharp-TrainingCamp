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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        FinancialCRMEntities db = new FinancialCRMEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var user = db.Tbl_Users.FirstOrDefault(x => x.Username == textBoxUsername.Text && x.Password == textBoxPassword.Text);
            if (user != null)
            {
                user.Username = textBoxNewUsername.Text;
                user.Password = textBoxNewPassword.Text;
                db.SaveChanges();
                MessageBox.Show("Username and password updated successfully");
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Current username or password is incorrect");
            }
        }
    }
}
