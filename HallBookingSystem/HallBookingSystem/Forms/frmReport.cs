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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            lblBooked.Visible = lblNotBooked.Visible = pbGreen.Visible = pbRed.Visible = true;
            cmbPlot.DataSource = Operation.GetDataTable("select distinct Plot from Inquiry");
            cmbPlot.DisplayMember = "Plot";
            cmbPlot.SelectedIndex = 0;
            rbAllEntry.Checked = true;
        }

        private void rbAllEntry_CheckedChanged(object sender, EventArgs e)
        {
            lblBooked.Visible = lblNotBooked.Visible = pbGreen.Visible = pbRed.Visible = true;
            RenderRecords();
        }

        private void RenderRecords()
        {
            var dtFilter = Operation.GetDataTable("select Booking.[Number] as [Booking No],Booking.[Date] as [Booking Date]," +
                       "[InqNo] as [Inquiry No],Booking.[Party],[Deposite],[Plot] from Booking" +
                       " left join Inquiry on Inquiry.[Number]=Booking.[InqNo] where Month(Booking.[Date]) = " +
                       dteDate.Value.ToString("MM") + " and Year(Booking.[Date]) = " + dteDate.Value.ToString("yyyy") + " and Inquiry.[Plot]='" + cmbPlot.Text + "'");
            if (rbAllEntry.Checked || rbPendingEntry.Checked)
            {

                if (dtFilter != null && dtFilter.Rows.Count > 0)
                {
                    var totDays = DateTime.DaysInMonth(dteDate.Value.Year, dteDate.Value.Month);
                    for (var i = 0; i < totDays; i++)
                    {
                        var isFound = false;
                        foreach (DataRow record in dtFilter.Rows)
                        {
                            if (Convert.ToDateTime(record["Booking Date"].ToString()).Month == dteDate.Value.Month && Convert.ToDateTime(record["Booking Date"].ToString()).Day == (i + 1) && Convert.ToDateTime(record["Booking Date"].ToString()).Year == dteDate.Value.Year)
                            {
                                isFound = true;
                                break;
                            }
                        }
                        if (!isFound)
                        {
                            dtFilter.Rows.Add();
                            dtFilter.Rows[dtFilter.Rows.Count - 1]["Booking Date"] = Convert.ToDateTime((i + 1) + "/" + dteDate.Value.Month + "/" + dteDate.Value.Year).Date;
                        }
                    }
                    dtFilter.DefaultView.Sort = "[Booking Date]";
                    dgvReport.DataSource = dtFilter.DefaultView.ToTable();
                    dgvReport.Columns[3].Width = 530;
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvReport.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow dgvRow in dgvReport.Rows)
                    {
                        dgvRow.DefaultCellStyle.ForeColor = Color.White;
                        if (string.IsNullOrEmpty(Convert.ToString(dgvRow.Cells[0].Value)))
                        {
                            dgvRow.DefaultCellStyle.BackColor = Color.Maroon;
                        }
                        else
                        {
                            dgvRow.DefaultCellStyle.BackColor = Color.Green;
                            if (rbPendingEntry.Checked)
                            {
                                dgvRow.Visible = false;
                            }
                        }
                    }
                }

            }
            else if (rbBookingEntry.Checked)
            {
                dgvReport.DataSource = dtFilter;
            }
        }

        private void rbBookingEntry_CheckedChanged(object sender, EventArgs e)
        {
            lblBooked.Visible = lblNotBooked.Visible = pbGreen.Visible = pbRed.Visible = false;
            RenderRecords();
            //if (rbBookingEntry.Checked)
            //{
            //    var dtFilter = Operation.GetDataTable("select [Number] as [Booking No],[Date] as [Booking Date],[InqNo] as [Inquiry No],[Party],[Deposite] from Booking where Month([Date]) = " + dteDate.Value.ToString("MM") + " and Year([Date]) = " + dteDate.Value.ToString("yyyy"));
            //    dgvReport.DataSource = dtFilter;
            //}
        }

        private void rbPendingEntry_CheckedChanged(object sender, EventArgs e)
        {
            lblBooked.Visible = lblNotBooked.Visible = pbGreen.Visible = pbRed.Visible = false;
            RenderRecords();
        }

        private void frmReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dteDate_ValueChanged(object sender, EventArgs e)
        {
            RenderRecords();
        }

        private void cmbPlot_Validated(object sender, EventArgs e)
        {
            RenderRecords();
        }
    }
}
