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
    public partial class frmRegisters : Form
    {
        private string _type = "";
        public frmRegisters(string Type)
        {
            InitializeComponent();
            _type = Type;
        }

        private void frmRegisters_Load(object sender, EventArgs e)
        {
            dteFromDate.Value = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            dteToDate.Value = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            if (_type == "Booking")
            {
                cmbSortOn.Items[0] = "Booking Date";
                this.Text = "Booking Register";
            }
            else
            {
                cmbSortOn.Items[0] = "Inquiry Date";
                this.Text = "Inquiry Register";
            }
            cmbSortOn.SelectedIndex = 0;
            var dtArea = Operation.GetDataTable("select distinct Area from Inquiry");
            dtArea.Rows.Add();
            dtArea.Rows[dtArea.Rows.Count - 1][0] = "-- All--";
            cmbArea.DataSource = dtArea;
            cmbArea.DisplayMember = "Area";
            if (cmbArea.Items.Count > 0)
                cmbArea.SelectedIndex = cmbArea.Items.Count - 1;
            RenderReport();
        }

        private void RenderReport()
        {
            if (dteFromDate.Value <= dteToDate.Value)
            {
                if (_type == "Booking")
                {
                    var dtFilter = Operation.GetDataTable("select Booking.[Number] as [Booking No],Booking.[Date] as [Booking Date]," +
                           "Booking.[Party],Inquiry.[MobNo] as [Mobile],Inquiry.[BkDate] as [Function Date],Inquiry.[FuncType] as [Function Type]"+
                           ",Inquiry.[Plot],Inquiry.[TotPerson] as [Pax],Booking.[Deposite],Inquiry.[Area],Inquiry.[Address] from Booking" +
                           " left join Inquiry on Inquiry.[Number]=Booking.[InqNo] where " + 
                           (cmbArea.SelectedIndex != cmbArea.Items.Count - 1 ? "Inquiry.[Area]='" + cmbArea.Text + "' and " : "") + 
                           " Inquiry.[BkDate] between #" + dteFromDate.Value.ToString("dd/MM/yyyy") + "# and #" + dteToDate.Value.ToString("dd/MM/yyyy") + "# order by " + (cmbSortOn.SelectedIndex == 0 ? "Booking.[Date]" : "Inquiry.[BkDate]"));
                    dgvReport.DataSource = dtFilter;
                }
                else
                {
                    var dtFilter = Operation.GetDataTable("select Number as [Inquiry No],Date as [Inquiry Date],Party,MobNo as [Mobile],"+
                        "BkDate as [Function Date],FuncType as [Function Type],Inquiry.[Area],Inquiry.[Address] from Inquiry where " + 
                        (cmbArea.SelectedIndex != cmbArea.Items.Count - 1 ? "Inquiry.[Area]='" + cmbArea.Text + "' and " : "") + " Inquiry.[Date] between #" +
                       dteFromDate.Value.ToString("dd/MM/yyyy") + "# and #" + dteToDate.Value.ToString("dd/MM/yyyy") + "# order by " + 
                       (cmbSortOn.SelectedIndex == 0 ? "Inquiry.[Date]" : "Inquiry.[BkDate]"));
                    dgvReport.DataSource = dtFilter;
                }
            }
            else
            {
                MessageBox.Show("From date should be less then to date");
            }
        }

        private void dteFromDate_ValueChanged(object sender, EventArgs e)
        {
            RenderReport();
        }

        private void dteToDate_ValueChanged(object sender, EventArgs e)
        {
            RenderReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void PrintReport()
        {
            var dtBooking = (DataTable)dgvReport.DataSource;
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
            var document = new iTextSharp.text.Document(PageSize.A4.Rotate(), 20f, 20f, 10f, 0f);
            var pdffilename = DateTime.Now.ToString("h:mm:ss").Replace(":", "");
            var writer = PdfWriter.GetInstance(document, new FileStream(folderPath + "/" + pdffilename + ".PDF", FileMode.Create));
            document.Open();

            var table = new PdfPTable(1);
            table.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
            table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            table.LockedWidth = true;
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            var dtSettings = Operation.GetDataTable("select * from settings");

            table = new PdfPTable(1);
            table.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
            table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            table.LockedWidth = true;
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            var cell = new PdfPCell(new Phrase(dtSettings.Rows[0]["CName"].ToString(), font16));

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
                cell = new PdfPCell(new Phrase(_type + " Register (" + dteFromDate.Value.ToString("dd/MM/yyyy") + " to " + dteToDate.Value.ToString("dd/MM/yyyy") + ")", font10_bold));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);
            }
            else
            {
                table.AddCell(new Phrase(" ", font16));
                table.AddCell(new Phrase(" ", font10_bold));
            }
            document.Add(table);

            table = new PdfPTable(dtBooking.Columns.Count);
            table.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
            table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            table.LockedWidth = true;
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            foreach (DataColumn cName in dtBooking.Columns)
            {
                cell = new PdfPCell(new Phrase(cName.Caption, font10_bold));
                cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_LEFT;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER;
                table.AddCell(cell);
            }

            foreach (DataRow row in dtBooking.Rows)
            {
                for (var i = 0; i < dtBooking.Columns.Count; i++)
                {
                    if (row[i].GetType() == typeof(DateTime))
                    {
                        cell = new PdfPCell(new Phrase(Convert.ToDateTime(row[i].ToString()).ToString("dd/MM/yyyy"), font10));
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase(row[i].ToString(), font10));
                    }
                    cell.HorizontalAlignment = iTextSharp.text.Rectangle.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    table.AddCell(cell);
                }
            }
            document.Add(table);
            document.Close();
            System.Diagnostics.Process.Start(folderPath + "//" + pdffilename + ".PDF");
        }

        private void frmRegisters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderReport();
        }

        private void cmbSortOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderReport();
        }
    }
}
