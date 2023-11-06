using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SYSTEM_KusinerosBristo.Forms
{
    public partial class FrmRegistration : Form
    {
        public string username = String.Empty;
        DBSYSEntities db;
        public FrmRegistration()
        {
            InitializeComponent();
            db = new DBSYSEntities();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //String cbResultSelected = cbBoxRole.SelectedValue.ToString();

            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPassword, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtRepassword.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPassword, "Empty field");
                return;
            }

            if (!txtPassword.Text.Equals(txtRepassword.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtRepassword, "Password not match");
                return;
            }
            // int code = 123;
            // send email verificode (code)
            // send sms otp (code)

            // find the user id
            // code input equal db. useraccoutn code
            UserAccount nUserAccount = new UserAccount();
            nUserAccount.userName = txtUsername.Text;
            nUserAccount.userPassword = txtPassword.Text;
            nUserAccount.roleId = (Int32)cbBoxRole.SelectedValue;
            nUserAccount.userStatus = "Active";

            username = txtUsername.Text;

            db.UserAccount.Add(nUserAccount);
            db.SaveChanges();

            txtPassword.Clear();
            txtRepassword.Clear();
            txtUsername.Clear();
            MessageBox.Show("Registered!");
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            loadCbBoxRole();
        }
        public void loadCbBoxRole()
        {
            // SELECT * FROM ROLE
            var roles = db.Role.ToList();

            cbBoxRole.ValueMember = "roleId";
            cbBoxRole.DisplayMember = "roleName";
            cbBoxRole.DataSource = roles;

        }
    }
}
}
