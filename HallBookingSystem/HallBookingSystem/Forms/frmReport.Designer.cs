namespace HallBookingSystem
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlot = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPendingEntry = new System.Windows.Forms.RadioButton();
            this.rbBookingEntry = new System.Windows.Forms.RadioButton();
            this.rbAllEntry = new System.Windows.Forms.RadioButton();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.pbRed = new System.Windows.Forms.PictureBox();
            this.pbGreen = new System.Windows.Forms.PictureBox();
            this.lblNotBooked = new System.Windows.Forms.Label();
            this.lblBooked = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).BeginInit();
            this.SuspendLayout();
            // 
            // dteDate
            // 
            this.dteDate.CustomFormat = "MMM-yyyy";
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteDate.Location = new System.Drawing.Point(882, 14);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(97, 23);
            this.dteDate.TabIndex = 133;
            this.dteDate.ValueChanged += new System.EventHandler(this.dteDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(769, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 134;
            this.label4.Text = "Select Month :";
            // 
            // cmbPlot
            // 
            this.cmbPlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlot.FormattingEnabled = true;
            this.cmbPlot.Items.AddRange(new object[] {
            "-- Select --",
            "Loan 1",
            "Loan 2"});
            this.cmbPlot.Location = new System.Drawing.Point(60, 12);
            this.cmbPlot.Name = "cmbPlot";
            this.cmbPlot.Size = new System.Drawing.Size(154, 23);
            this.cmbPlot.TabIndex = 132;
            this.cmbPlot.Validated += new System.EventHandler(this.cmbPlot_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 131;
            this.label5.Text = "Plot :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBooked);
            this.groupBox1.Controls.Add(this.lblNotBooked);
            this.groupBox1.Controls.Add(this.pbGreen);
            this.groupBox1.Controls.Add(this.pbRed);
            this.groupBox1.Controls.Add(this.rbPendingEntry);
            this.groupBox1.Controls.Add(this.rbBookingEntry);
            this.groupBox1.Controls.Add(this.rbAllEntry);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(967, 40);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            // 
            // rbPendingEntry
            // 
            this.rbPendingEntry.AutoSize = true;
            this.rbPendingEntry.Location = new System.Drawing.Point(558, 15);
            this.rbPendingEntry.Name = "rbPendingEntry";
            this.rbPendingEntry.Size = new System.Drawing.Size(100, 19);
            this.rbPendingEntry.TabIndex = 2;
            this.rbPendingEntry.TabStop = true;
            this.rbPendingEntry.Text = "Pending Entry";
            this.rbPendingEntry.UseVisualStyleBackColor = true;
            this.rbPendingEntry.CheckedChanged += new System.EventHandler(this.rbPendingEntry_CheckedChanged);
            // 
            // rbBookingEntry
            // 
            this.rbBookingEntry.AutoSize = true;
            this.rbBookingEntry.Location = new System.Drawing.Point(424, 15);
            this.rbBookingEntry.Name = "rbBookingEntry";
            this.rbBookingEntry.Size = new System.Drawing.Size(100, 19);
            this.rbBookingEntry.TabIndex = 1;
            this.rbBookingEntry.TabStop = true;
            this.rbBookingEntry.Text = "Booking Entry";
            this.rbBookingEntry.UseVisualStyleBackColor = true;
            this.rbBookingEntry.CheckedChanged += new System.EventHandler(this.rbBookingEntry_CheckedChanged);
            // 
            // rbAllEntry
            // 
            this.rbAllEntry.AutoSize = true;
            this.rbAllEntry.Location = new System.Drawing.Point(309, 15);
            this.rbAllEntry.Name = "rbAllEntry";
            this.rbAllEntry.Size = new System.Drawing.Size(71, 19);
            this.rbAllEntry.TabIndex = 0;
            this.rbAllEntry.TabStop = true;
            this.rbAllEntry.Text = "All Entry";
            this.rbAllEntry.UseVisualStyleBackColor = true;
            this.rbAllEntry.CheckedChanged += new System.EventHandler(this.rbAllEntry_CheckedChanged);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(13, 86);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.Size = new System.Drawing.Size(966, 387);
            this.dgvReport.TabIndex = 136;
            // 
            // pbRed
            // 
            this.pbRed.BackColor = System.Drawing.Color.Maroon;
            this.pbRed.Location = new System.Drawing.Point(6, 15);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(17, 17);
            this.pbRed.TabIndex = 3;
            this.pbRed.TabStop = false;
            // 
            // pbGreen
            // 
            this.pbGreen.BackColor = System.Drawing.Color.Green;
            this.pbGreen.Location = new System.Drawing.Point(870, 15);
            this.pbGreen.Name = "pbGreen";
            this.pbGreen.Size = new System.Drawing.Size(17, 17);
            this.pbGreen.TabIndex = 4;
            this.pbGreen.TabStop = false;
            // 
            // lblNotBooked
            // 
            this.lblNotBooked.AutoSize = true;
            this.lblNotBooked.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotBooked.Location = new System.Drawing.Point(29, 16);
            this.lblNotBooked.Name = "lblNotBooked";
            this.lblNotBooked.Size = new System.Drawing.Size(83, 16);
            this.lblNotBooked.TabIndex = 137;
            this.lblNotBooked.Text = "Not Booked";
            // 
            // lblBooked
            // 
            this.lblBooked.AutoSize = true;
            this.lblBooked.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooked.Location = new System.Drawing.Point(893, 15);
            this.lblBooked.Name = "lblBooked";
            this.lblBooked.Size = new System.Drawing.Size(55, 16);
            this.lblBooked.TabIndex = 138;
            this.lblBooked.Text = "Booked";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 485);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dteDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPlot);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteDate;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlot;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPendingEntry;
        private System.Windows.Forms.RadioButton rbBookingEntry;
        private System.Windows.Forms.RadioButton rbAllEntry;
        private System.Windows.Forms.DataGridView dgvReport;
        internal System.Windows.Forms.Label lblBooked;
        internal System.Windows.Forms.Label lblNotBooked;
        private System.Windows.Forms.PictureBox pbGreen;
        private System.Windows.Forms.PictureBox pbRed;
    }
}