using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HallBookingSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnInquery_Click(object sender, EventArgs e)
        {
            frmInquiry inquiry = new frmInquiry();
            inquiry.ShowDialog();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            frmBooking booking = new frmBooking();
            booking.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport();
            report.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to close this?", Operation.MsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
