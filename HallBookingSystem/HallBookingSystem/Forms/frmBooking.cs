using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace HallBookingSystem
{
    public partial class frmBooking : Form
    {
        public frmBooking()
        {
            InitializeComponent();
            btnAdd_Click(null, null);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dt = Operation.GetDataTable("select Number from Booking order by Date desc");
            var bkNumber = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                bkNumber = Convert.ToInt32(dt.Rows[0][0]) + 1;
            }
            else
            {
                bkNumber = 1;
            }
            lblBookingNo.Text = bkNumber.ToString();
            lblId.Text = "0";
            dteBookingDate.Value = dtpChequeDate.Value = DateTime.Now;
            txtChequeNo.Text = txtChequeBank.Text = txtAdvanceAmount.Text = "";
            cmbPaymentBy.SelectedIndex = 0;
            var dtInquiry = Operation.GetDataTable("Select Party + ' ( ' + FORMAT(BkDate,'dd/MM/yyyy') + ' , ' + FuncType + ')' as InquiryTitle,Number from Inquiry");
            dtInquiry.Rows.Add();
            dtInquiry.Rows[dtInquiry.Rows.Count - 1]["InquiryTitle"] = "-- Select --";
            dtInquiry.Rows[dtInquiry.Rows.Count - 1]["Number"] = "0";
            cmbInquiryDetail.DataSource = dtInquiry;
            cmbInquiryDetail.DisplayMember = "InquiryTitle";
            cmbInquiryDetail.ValueMember = "Number";
            cmbInquiryDetail.SelectedValue = "0";
        }



        private void cmbPaymentBy_Leave(object sender, EventArgs e)
        {
            if (cmbPaymentBy.SelectedIndex == 1 || cmbPaymentBy.SelectedIndex == 0)
            {
                txtChequeBank.Enabled = txtChequeNo.Enabled = dtpChequeDate.Enabled = false;
                txtChequeBank.Text = txtChequeNo.Text = "";
            }
            else
            {
                txtChequeBank.Enabled = txtChequeNo.Enabled = dtpChequeDate.Enabled = true;
            }
        }

        private void cmbInquiryDetail_Validated(object sender, EventArgs e)
        {
            if (Convert.ToString(cmbInquiryDetail.SelectedValue) != "0" && Convert.ToString(cmbInquiryDetail.SelectedValue) != "")
            {
                var dtInquiry = Operation.GetDataTable("select * from Inquiry where Number='" + cmbInquiryDetail.SelectedValue + "'");
                if (dtInquiry != null && dtInquiry.Rows.Count > 0)
                {
                    lblInquiryNo.Text = dtInquiry.Rows[0]["Number"].ToString();
                    txtParty.Text = dtInquiry.Rows[0]["Party"].ToString();
                    txtParty.Enabled = false;
                    txtGathering.Text = dtInquiry.Rows[0]["TotPerson"].ToString();
                    txtGathering.Enabled = false;
                    txtAddress.Text = dtInquiry.Rows[0]["Address"].ToString();
                    txtAddress.Enabled = false;
                    txtMobile.Text = dtInquiry.Rows[0]["MobNo"].ToString();
                    txtMobile.Enabled = false;
                    cmbPlot.Text = dtInquiry.Rows[0]["Plot"].ToString();
                    cmbPlot.Enabled = false;
                    cmbTimingSlot.Text = dtInquiry.Rows[0]["TimeType"].ToString();
                    cmbTimingSlot.Enabled = false;
                    cmbFunctionType.Text = dtInquiry.Rows[0]["FuncType"].ToString();
                    cmbFunctionType.Enabled = false;
                    dteBookingDate.Value = Convert.ToDateTime(dtInquiry.Rows[0]["BkDate"].ToString());
                    dteBookingDate.Enabled = false;
                    dteInquiryDate.Value = Convert.ToDateTime(dtInquiry.Rows[0]["Date"].ToString());
                    dteInquiryDate.Enabled = false;
                }
                else
                {
                    lblInquiryNo.Text = txtParty.Text = txtGathering.Text = txtAddress.Text = txtMobile.Text = "";
                    dteInquiryDate.Value = dteBookingDate.Value = DateTime.Now;
                    cmbFunctionType.Text = cmbPlot.Text = cmbTimingSlot.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please select proper Inquiry from given list.");
                cmbInquiryDetail.SelectedValue = "0";
                lblInquiryNo.Text = txtParty.Text = txtGathering.Text = txtAddress.Text = txtMobile.Text = "";
                dteInquiryDate.Value = dteBookingDate.Value = DateTime.Now;
                cmbFunctionType.Text = cmbPlot.Text = cmbTimingSlot.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateBooking())
            {
                var result = 0;
                if (lblId.Text == "0")
                {
                    result = Operation.ExecuteNonQuery("Insert into Booking([Number],[Date],[Party],[InqNo],[Deposite]," +
                        "[PmtMode],[ChequeNo],[ChequeDt],[ChequeBank]) values('" + lblBookingNo.Text + "','" +
                        dtpBookingDate.Value.ToString("dd/MM/yyyy") + "','" + txtParty.Text + "','" +
                        lblInquiryNo.Text + "','" + txtAdvanceAmount.Text + "','" + cmbPaymentBy.Text + "','" +
                        txtChequeNo.Text + "','" + dtpChequeDate.Value.ToString("dd/MM/yyyy") + "','" + txtChequeBank.Text + "')");
                }
                else
                {
                    result = Operation.ExecuteNonQuery("Update Booking set [Date]='" +
                        dtpBookingDate.Value.ToString("dd/MM/yyyy") + "',[Party]='" +
                        txtParty.Text + "',[InqNo]='" + lblInquiryNo.Text + "',[Deposite]='" +
                        txtAdvanceAmount.Text + "',[PmtMode]='" + cmbPaymentBy.Text + "',[ChequeNo]='" +
                        txtChequeNo.Text + "',[ChequeBank]='" + txtChequeBank.Text + "',[ChequeDt]='" +
                        dtpChequeDate.Value.ToString("dd/MM/yyyy") + "' where Number='" + lblId.Text + "'");
                }
                if (result > 0)
                {
                    if (MessageBox.Show("Booking saved Successfully.\r\nWould you like to get pring of this?", Operation.MsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var filename = PrintReceipt(lblBookingNo.Text);
                        System.Diagnostics.Process.Start(filename);
                    }
                    btnAdd_Click(null, null);
                }
            }

        }

        private string PrintReceipt(string BookingNo)
        {
            if (!string.IsNullOrEmpty(BookingNo))
            {
                var dtBooking = Operation.GetDataTable("Select Booking.*,Inquiry.[BkDate],Inquiry.[FuncType],Inquiry.[Plot],Inquiry.[TotPerson] from Booking left join Inquiry on Inquiry.[Number] = Booking.[InqNo] where Booking.[Number]='" + BookingNo + "'");
                iTextSharp.text.Font font10 = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font font10_bold = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font16 = FontFactory.GetFont("Calibri", 16, iTextSharp.text.Font.BOLD);
                var folderPath = Application.StartupPath + "//Receipts";
                bool exists = Directory.Exists(folderPath);
                if (!exists)
                    Directory.CreateDirectory(folderPath);

                DirectoryInfo info = new DirectoryInfo(folderPath);
                FileInfo[] files = info.GetFiles().Where(p => p.CreationTime <= DateTime.Now.AddDays(-1)).ToArray();
                foreach (var file in files)
                {
                    file.Delete();
                }
                var document = new iTextSharp.text.Document(PageSize.A4, 20f, 20f, 10f, 0f);
                var pdffilename = DateTime.Now.ToString("h:mm:ss").Replace(":", "");
                var writer = PdfWriter.GetInstance(document, new FileStream(folderPath + "/" + pdffilename + ".PDF", FileMode.Create));
                document.Open();

                var outerTable = new PdfPTable(1);
                outerTable.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                outerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                outerTable.LockedWidth = true;
                outerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                var table = new PdfPTable(1);
                table.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                table.LockedWidth = true;
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                var dtSettings = Operation.GetDataTable("select * from settings");
                PdfPCell cell = new PdfPCell(new Phrase("Receipt", font10));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table.AddCell(cell);

                document.Add(table);

                table = new PdfPTable(1);
                table.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                table.LockedWidth = true;
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                if (dtSettings != null && dtSettings.Rows.Count > 0)
                {
                    cell = new PdfPCell(new Phrase(dtSettings.Rows[0]["CName"].ToString(), font16));
                    cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(dtSettings.Rows[0]["CAddress"].ToString(), font10_bold));
                    cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    table.AddCell(cell);
                }
                else
                {
                    table.AddCell(new Phrase(" ", font16));
                    table.AddCell(new Phrase(" ", font10_bold));
                }
                //document.Add(table);
                cell = new PdfPCell(table);
                cell.Border = iTextSharp.text.Rectangle.BOX;
                outerTable.AddCell(cell);

                table = new PdfPTable(2);
                table.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                table.LockedWidth = true;
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cell = new PdfPCell(new Phrase("Receipt No. : " + dtBooking.Rows[0]["Number"].ToString(), font10_bold));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_LEFT;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Receipt Dt. : " + Convert.ToDateTime(dtBooking.Rows[0]["Date"].ToString()).ToString("dd/MM/yyyy"), font10_bold));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_RIGHT;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Received with thanks from", font10));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_LEFT;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.PaddingBottom = 8;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("M/S." + dtBooking.Rows[0]["Party"].ToString(), font10_bold));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_LEFT;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.PaddingBottom = 8;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("The sum of Rupees " + NumberToWords(Convert.ToInt32(dtBooking.Rows[0]["Deposite"])), font10));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_LEFT;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.PaddingBottom = 8;
                cell.Colspan = 2;
                table.AddCell(cell);

                if (Convert.ToString(dtBooking.Rows[0]["PmtMode"]).ToUpper() == "CASH")
                {
                    cell = new PdfPCell(new Phrase("By Cash", font10_bold));
                    cell.Colspan = 2;
                    cell.PaddingBottom = 8;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    table.AddCell(cell);
                }
                else
                {
                    table.AddCell(new Phrase("By Cheque / Draft No. :" + Convert.ToString(dtBooking.Rows[0]["ChequeNo"]), font10_bold));
                    table.AddCell(new Phrase("Cheque / Draft Date :" + Convert.ToDateTime(Convert.ToString(dtBooking.Rows[0]["ChequeDt"])).ToString("dd/MM/yyyy"), font10_bold));
                    table.AddCell(new Phrase("Drawn on Bank : " + Convert.ToString(dtBooking.Rows[0]["ChequeBank"]), font10_bold));
                }

                cell = new PdfPCell(new Phrase("In Part / Full Payment for following details, ", font10));
                cell.Colspan = 2;
                cell.PaddingBottom = 8;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Function Date : " + Convert.ToString(dtBooking.Rows[0]["BkDate"]), font10_bold));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Function Type : " + Convert.ToString(dtBooking.Rows[0]["FuncType"]), font10_bold));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Plot : " + Convert.ToString(dtBooking.Rows[0]["Plot"]), font10_bold));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Gathering Person : " + Convert.ToString(dtBooking.Rows[0]["TotPerson"]), font10_bold));
                cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("For, " + Convert.ToString(dtSettings.Rows[0]["CName"]), font10_bold));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.Colspan = 2;
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_RIGHT;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Rs. " + Convert.ToString(dtBooking.Rows[0]["Deposite"]), font10_bold));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.PaddingBottom = 8;
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Subject to Realisation of Cheque / Draft.", font10));
                cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = new PdfPCell(table);
                cell.Border = iTextSharp.text.Rectangle.BOX;
                outerTable.AddCell(cell);

                document.Add(outerTable);
                document.Close();
                return folderPath + "//" + pdffilename + ".PDF";
            }
            else
            {
                return null;
            }
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private bool validateBooking()
        {
            if (cmbInquiryDetail.SelectedValue != null && Convert.ToInt32(cmbInquiryDetail.SelectedValue) <= 0)
            {
                MessageBox.Show("Please select inquiry.");
                cmbInquiryDetail.Focus();
                return false;
            }
            if (cmbPaymentBy.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Payment option.");
                cmbPaymentBy.Focus();
                return false;
            }
            if (txtAdvanceAmount.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter amount.");
                txtAdvanceAmount.Focus();
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmSearch view = new frmSearch();
            Operation.gViewQuery = "select Booking.[Number] as [Booking No],Booking.[Date] as [Booking Date],Inquiry.[BkDate] as [Function Date]," +
                "Inquiry.[FuncType] as [Function Type],Booking.[Party],Booking.[Deposite],Booking.[PmtMode] from Booking" +
                " left join Inquiry on Inquiry.[Number]=Booking.[InqNo]";
            Operation.Bindgrid(Operation.gViewQuery, view.dgvSearch);
            view.OrderByColoumn = "Booking No";
            view.ShowDialog();
            view.dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            if (Operation.ViewID != null && Operation.ViewID != string.Empty)
            {
                var dt = Operation.GetDataTable("Select * from Booking where Number='" + Operation.ViewID.ToString() + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblBookingNo.Text = dt.Rows[0]["Number"].ToString();
                    dteBookingDate.Value = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());
                    lblId.Text = dt.Rows[0]["Number"].ToString();
                    cmbInquiryDetail.SelectedValue = dt.Rows[0]["InqNo"].ToString();
                    cmbInquiryDetail_Validated(null, null);
                    txtAdvanceAmount.Text = dt.Rows[0]["Deposite"].ToString();
                    txtChequeNo.Text = dt.Rows[0]["ChequeNo"].ToString();
                    txtChequeBank.Text = dt.Rows[0]["ChequeBank"].ToString();
                    dtpChequeDate.Value = Convert.ToDateTime(dt.Rows[0]["ChequeDt"].ToString());
                    cmbPaymentBy.Text = dt.Rows[0]["PmtMode"].ToString();
                }
                Operation.ViewID = "";
            }
        }

        private void frmBooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lblBookingNo.Text != "0")
            {
                var filename = PrintReceipt(lblBookingNo.Text);
                System.Diagnostics.Process.Start(filename);
            }
            else
            {
                MessageBox.Show("Please select booking first.", Operation.MsgTitle);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblBookingNo.Text == "0")
            {
                MessageBox.Show("Please select Booking first.");
            }
            else
            {
                if (MessageBox.Show("Are you sure want to delete this Booking?", Operation.MsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var result = Operation.ExecuteNonQuery("Delete from Booking where [Number]='" + lblBookingNo.Text + "'");
                    if (result > 0)
                    {
                        MessageBox.Show("Booking Deleted Successfully.");
                        btnAdd_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting, Please try after sometime.");
                    }
                }

            }
        }
    }
}
