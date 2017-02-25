using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HallBookingSystem
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            var dt = Operation.GetDataTable("select * from settings");
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCompanyName.Text = dt.Rows[0]["CName"].ToString();
                txtCompanyAddress.Text = dt.Rows[0]["CAddress"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            List<string> strQueries = new List<string>();
            strQueries.Add("Delete from settings");
            strQueries.Add("Insert into settings(CName,CAddress) values('" + txtCompanyName.Text + "','" + txtCompanyAddress.Text + "')");
            if (Operation.ExecuteTransaction(strQueries))
            {
                MessageBox.Show("Settings saved successfully.");
            }
            else
            {
                MessageBox.Show("Error while saving, Please try after sometime.");
            }
        }

        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
