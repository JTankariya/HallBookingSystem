namespace HallBookingSystem
{
    partial class frmInquiry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInquiry));
            this.txtParty = new System.Windows.Forms.TextBox();
            this.Label54 = new System.Windows.Forms.Label();
            this.dteInquiryDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInquiryNo = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPlot = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dteBookingDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFunctionType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTimingSlot = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGathering = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtParty
            // 
            this.txtParty.BackColor = System.Drawing.Color.White;
            this.txtParty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParty.Location = new System.Drawing.Point(112, 48);
            this.txtParty.MaxLength = 50;
            this.txtParty.Name = "txtParty";
            this.txtParty.Size = new System.Drawing.Size(450, 23);
            this.txtParty.TabIndex = 1;
            this.txtParty.Tag = "Enter Mobile No.1";
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label54.Location = new System.Drawing.Point(41, 51);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(54, 16);
            this.Label54.TabIndex = 80;
            this.Label54.Text = "Party :";
            // 
            // dteInquiryDate
            // 
            this.dteInquiryDate.CustomFormat = "dd/MM/yyyy";
            this.dteInquiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteInquiryDate.Location = new System.Drawing.Point(451, 12);
            this.dteInquiryDate.Name = "dteInquiryDate";
            this.dteInquiryDate.Size = new System.Drawing.Size(112, 23);
            this.dteInquiryDate.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 79;
            this.label7.Text = "Inquiry Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Inquiry No :";
            // 
            // lblInquiryNo
            // 
            this.lblInquiryNo.AutoSize = true;
            this.lblInquiryNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryNo.Location = new System.Drawing.Point(109, 15);
            this.lblInquiryNo.Name = "lblInquiryNo";
            this.lblInquiryNo.Size = new System.Drawing.Size(81, 16);
            this.lblInquiryNo.TabIndex = 82;
            this.lblInquiryNo.Text = "Inquiry No:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(112, 77);
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(450, 61);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Tag = "Enter Mobile No.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 84;
            this.label2.Text = "Address :";
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.White;
            this.txtMobile.Location = new System.Drawing.Point(112, 143);
            this.txtMobile.MaxLength = 10;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(166, 23);
            this.txtMobile.TabIndex = 3;
            this.txtMobile.Tag = "Enter Mobile No.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 86;
            this.label3.Text = "Mobile :";
            // 
            // cmbPlot
            // 
            this.cmbPlot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPlot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPlot.FormattingEnabled = true;
            this.cmbPlot.Location = new System.Drawing.Point(409, 143);
            this.cmbPlot.Name = "cmbPlot";
            this.cmbPlot.Size = new System.Drawing.Size(154, 23);
            this.cmbPlot.TabIndex = 6;
            this.cmbPlot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPlot_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(359, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 88;
            this.label5.Text = "Plot :";
            // 
            // dteBookingDate
            // 
            this.dteBookingDate.CustomFormat = "dd/MM/yyyy";
            this.dteBookingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteBookingDate.Location = new System.Drawing.Point(112, 174);
            this.dteBookingDate.Name = "dteBookingDate";
            this.dteBookingDate.Size = new System.Drawing.Size(166, 23);
            this.dteBookingDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 90;
            this.label4.Text = "Func Date :";
            // 
            // cmbFunctionType
            // 
            this.cmbFunctionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFunctionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFunctionType.FormattingEnabled = true;
            this.cmbFunctionType.Location = new System.Drawing.Point(409, 174);
            this.cmbFunctionType.Name = "cmbFunctionType";
            this.cmbFunctionType.Size = new System.Drawing.Size(154, 23);
            this.cmbFunctionType.TabIndex = 7;
            this.cmbFunctionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFunctionType_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(290, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 92;
            this.label6.Text = "Function Type :";
            // 
            // cmbTimingSlot
            // 
            this.cmbTimingSlot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTimingSlot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTimingSlot.FormattingEnabled = true;
            this.cmbTimingSlot.Location = new System.Drawing.Point(409, 205);
            this.cmbTimingSlot.Name = "cmbTimingSlot";
            this.cmbTimingSlot.Size = new System.Drawing.Size(154, 23);
            this.cmbTimingSlot.TabIndex = 8;
            this.cmbTimingSlot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTimingSlot_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(322, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 16);
            this.label8.TabIndex = 94;
            this.label8.Text = "Time Slot :";
            // 
            // txtGathering
            // 
            this.txtGathering.BackColor = System.Drawing.Color.White;
            this.txtGathering.Location = new System.Drawing.Point(112, 205);
            this.txtGathering.MaxLength = 10;
            this.txtGathering.Name = "txtGathering";
            this.txtGathering.Size = new System.Drawing.Size(166, 23);
            this.txtGathering.TabIndex = 5;
            this.txtGathering.Tag = "Enter Mobile No.1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 96;
            this.label9.Text = "Person :";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(9, 262);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(82, 16);
            this.lblId.TabIndex = 101;
            this.lblId.Text = "Gathering :";
            this.lblId.Visible = false;
            // 
            // btnView
            // 
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::HallBookingSystem.Properties.Resources.search2;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnView.Location = new System.Drawing.Point(438, 247);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(50, 50);
            this.btnView.TabIndex = 12;
            this.btnView.Tag = "View";
            this.btnView.Text = "&View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::HallBookingSystem.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(216, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 9;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd.Location = new System.Drawing.Point(110, 247);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Tag = "Add";
            this.btnAdd.Text = "&Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::HallBookingSystem.Properties.Resources.close;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(322, 247);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 50);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(575, 312);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtGathering);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbTimingSlot);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbFunctionType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dteBookingDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPlot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInquiryNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParty);
            this.Controls.Add(this.Label54);
            this.Controls.Add(this.dteInquiryDate);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInquiry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inquiry";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInquiry_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtParty;
        internal System.Windows.Forms.Label Label54;
        private System.Windows.Forms.DateTimePicker dteInquiryDate;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblInquiryNo;
        public System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMobile;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPlot;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteBookingDate;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFunctionType;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTimingSlot;
        internal System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtGathering;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnDelete;
    }
}