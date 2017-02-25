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
            if (MessageBox.Show("Are you sure want to close this?", Operation.MsgTitle, MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                Operation.isCloseApp = true;
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings setting = new frmSettings();
            setting.ShowDialog();
        }

        private void btnBookingRegister_Click(object sender, EventArgs e)
        {
            frmRegisters bkRegister = new frmRegisters("Booking");
            bkRegister.ShowDialog();
        }

        private void btnInqRegister_Click(object sender, EventArgs e)
        {
            frmRegisters bkRegister = new frmRegisters("Inquiry");
            bkRegister.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword password = new frmChangePassword();
            password.ShowDialog();
        }
    }
}
