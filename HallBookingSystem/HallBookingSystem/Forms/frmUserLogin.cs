using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Net;
using System.Data.SqlClient;
using System.Diagnostics;

namespace HallBookingSystem
{

    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void lnklblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword child = new frmChangePassword(0, "");
            this.SendToBack();
            child.ShowDialog();
            this.BringToFront();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string strAppPath = null;
                strAppPath = Application.StartupPath;
                string str = "select * from [Users] where UserName = '" + txtUserName.Text.Trim() + "' and Password = '" + Operation.Encryptdata(txtpassword.Text.Trim()) + "'";
                DataTable dt = Operation.GetDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    Operation.currUser = new User(dt.Rows[0]);
                    this.Hide();
                    frmMain objMain = new frmMain();
                    objMain.ShowDialog();
                    if (Operation.isCloseApp)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password, Please try again.");
                }
            }
            catch (Exception ez)
            {
                MessageBox.Show("Error in user login" + Environment.NewLine + ez.Message, Operation.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void frmUserLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    btnOk_Click(sender, e);
            //}

        }

        private void frmUserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}
