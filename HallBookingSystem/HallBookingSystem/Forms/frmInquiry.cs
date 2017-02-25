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
    public partial class frmInquiry : Form
    {
        public frmInquiry()
        {
            InitializeComponent();
            btnAdd_Click(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInquiry())
            {
                var result = 0;
                if (lblId.Text == "0")
                {
                    result = Operation.ExecuteNonQuery("Insert into Inquiry([Number],[Party],[Date],[Address],[MobNo],[Plot],[BkDate]," +
                        "[FuncType],[TimeType],[TotPerson]) values('" + lblInquiryNo.Text + "','" + txtParty.Text + "','" +
                        dteInquiryDate.Value.ToString("dd/MM/yyyy") + "','" +
                        txtAddress.Text + "','" + txtMobile.Text + "','" + cmbPlot.Text + "','" +
                        dteBookingDate.Value.ToString("dd/MM/yyyy") + "','" + cmbFunctionType.Text + "','" +
                        cmbTimingSlot.Text + "','" + txtGathering.Text + "')");
                }
                else
                {
                    result = Operation.ExecuteNonQuery("Update Inquiry set [Party]='" + txtParty.Text +
                        "',[Date]='" + dteInquiryDate.Value.ToString("dd/MM/yyyy") + "',[Address]='" +
                        txtAddress.Text + "',[MobNo]='" + txtMobile.Text + "',[Plot]='" + cmbPlot.Text +
                        "',[BkDate]='" + dteBookingDate.Value.ToString("dd/MM/yyyy") + "',[FuncType]='" +
                        cmbFunctionType.Text + "',[TimeType]='" + cmbTimingSlot.Text +
                        "',[TotPerson]='" + txtGathering.Text + "' where [Number]='" + lblInquiryNo.Text + "'");
                }
                if (result > 0)
                {
                    MessageBox.Show("Inquiry Saved Successfully.");
                    btnAdd_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Error while saving inquiry, Please try after somtime.");
                }
            }
        }

        private bool ValidateInquiry()
        {
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblId.Text == "0")
            {
                MessageBox.Show("Please select inquiry first.");
            }
            else
            {
                var dtBookings = Operation.GetDataTable("select * from Booking where InqNo='" + lblInquiryNo.Text + "'");
                if (dtBookings != null && dtBookings.Rows.Count > 0)
                {
                    MessageBox.Show("Can not delete this inquiry as it's booking is done.", Operation.MsgTitle);
                    return;
                }
                if (MessageBox.Show("Are you sure want to delete this inquiry?", Operation.MsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var result = Operation.ExecuteNonQuery("Delete from Inquiry where Number='" + lblInquiryNo.Text + "'");
                    if (result > 0)
                    {
                        MessageBox.Show("Inquiry Deleted Successfully.");
                        btnAdd_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting, Please try after sometime.");
                    }
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dt = Operation.GetDataTable("select Number from Inquiry order by Date desc");
            var inqNumber = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                inqNumber = Convert.ToInt32(dt.Rows[0][0]) + 1;
            }
            else
            {
                inqNumber = 1;
            }
            lblInquiryNo.Text = inqNumber.ToString();
            lblId.Text = "0";
            txtParty.Text = "";
            txtGathering.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            cmbPlot.DataSource = Operation.GetDataTable("select distinct Plot from Inquiry");
            cmbPlot.DisplayMember = "Plot";
            if (cmbPlot.Items.Count > 0)
                cmbPlot.SelectedIndex = 0;
            cmbFunctionType.DataSource = Operation.GetDataTable("select distinct FuncType from Inquiry");
            cmbFunctionType.DisplayMember = "FuncType";
            if (cmbFunctionType.Items.Count > 0)
                cmbFunctionType.SelectedIndex = 0;
            cmbTimingSlot.DataSource = Operation.GetDataTable("select distinct TimeType from Inquiry");
            cmbTimingSlot.DisplayMember = "TimeType";
            if (cmbTimingSlot.Items.Count > 0)
                cmbTimingSlot.SelectedIndex = 0;
            dteBookingDate.Value = DateTime.Now;
            dteInquiryDate.Value = DateTime.Now;

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmSearch view = new frmSearch();
            Operation.gViewQuery = "select Number as [Inquiry No],Date as [Inquiry Date],Party,MobNo as [Mobile],BkDate as [Function Date],FuncType as [Function Type] from Inquiry";
            Operation.Bindgrid(Operation.gViewQuery, view.dgvSearch);
            view.OrderByColoumn = "Inquiry No";
            view.ShowDialog();
            view.dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            if (Operation.ViewID != null && Operation.ViewID != string.Empty)
            {
                var dt = Operation.GetDataTable("Select * from Inquiry where Number='" + Operation.ViewID.ToString() + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblInquiryNo.Text = dt.Rows[0]["Number"].ToString();
                    lblId.Text = dt.Rows[0]["Number"].ToString();
                    txtParty.Text = dt.Rows[0]["Party"].ToString();
                    txtGathering.Text = dt.Rows[0]["TotPerson"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtMobile.Text = dt.Rows[0]["MobNo"].ToString();
                    cmbPlot.Text = dt.Rows[0]["Plot"].ToString();
                    cmbTimingSlot.Text = dt.Rows[0]["TimeType"].ToString();
                    cmbFunctionType.Text = dt.Rows[0]["FuncType"].ToString();
                    dteBookingDate.Value = Convert.ToDateTime(dt.Rows[0]["BkDate"].ToString());
                    dteInquiryDate.Value = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());
                }
                Operation.ViewID = "";
            }
        }

        private void cmbPlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void cmbFunctionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void cmbTimingSlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void frmInquiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
