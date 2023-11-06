using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYSTEM_KusinerosBristo.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                errorProviderCustom.SetError(txtUsername, "Empty Field!");
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProviderCustom.SetError(txtPassword, "Empty Field!");
                return;
            }

            var userLogged = userRepo.GetUserByUsername(txtUsername.Text);

            if (userLogged != null)
            {
                if (userLogged.userPassword.Equals(txtPassword.Text))
                {

                    UserLogged.GetInstance().UserAccount = userLogged;

                    switch ((Role)userLogged.roleId)
                    {
                        case Role.Student:
                            // Load student Dashboard
                            new Frm_Student_Dashboard().Show();
                            this.Hide();
                            break;
                        case Role.Teacher:
                            // Load Teacher Dashboard
                            new Frm_Teacher_DashBoard().Show();
                            this.Hide();
                            break;
                        case Role.Admin:
                            // Load Admin Dashboard
                            new Frm_Admin_Dashboard().Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("User has no role!");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            else
            {
                MessageBox.Show("Username not found");
            }

        }

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
