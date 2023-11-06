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
    public partial class FrmAdminDashboard : Form
    {
        public FrmAdminDashboard()
        {
            InitializeComponent();
        }
        public void AddControls(Form f)
        {
            MainPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            MainPanel.Controls.Add(f);
            f.Show();

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new FrmHome());
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            AddControls(new FrmPOS());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            AddControls(new FrmMenu());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            AddControls(new FrmSalesReport());
        }
    }
}
