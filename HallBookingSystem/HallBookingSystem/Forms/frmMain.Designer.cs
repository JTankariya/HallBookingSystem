namespace HallBookingSystem
{
    partial class frmMain
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
            this.btnReport = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnInquery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Calibri", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::HallBookingSystem.Properties.Resources.report;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReport.Location = new System.Drawing.Point(394, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(155, 96);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooking.Font = new System.Drawing.Font("Calibri", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooking.Image = global::HallBookingSystem.Properties.Resources.booking;
            this.btnBooking.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBooking.Location = new System.Drawing.Point(200, 12);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(155, 96);
            this.btnBooking.TabIndex = 7;
            this.btnBooking.Text = "Booking";
            this.btnBooking.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnInquery
            // 
            this.btnInquery.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInquery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInquery.Font = new System.Drawing.Font("Calibri", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInquery.Image = global::HallBookingSystem.Properties.Resources.inquiry;
            this.btnInquery.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInquery.Location = new System.Drawing.Point(12, 12);
            this.btnInquery.Name = "btnInquery";
            this.btnInquery.Size = new System.Drawing.Size(155, 96);
            this.btnInquery.TabIndex = 6;
            this.btnInquery.Text = "Inquiry";
            this.btnInquery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInquery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInquery.UseVisualStyleBackColor = true;
            this.btnInquery.Click += new System.EventHandler(this.btnInquery_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 119);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.btnInquery);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hall Booking System By Shah Infotech";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInquery;
        private System.Windows.Forms.Button btnBooking;
        private System.Windows.Forms.Button btnReport;
    }
}