namespace AdminDB
{
    partial class MainForm
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
            this.lblTableHeader = new System.Windows.Forms.Label();
            this.dateDrivers = new System.Windows.Forms.DateTimePicker();
            this.tableEmployees = new System.Windows.Forms.DataGridView();
            this.lblEms = new System.Windows.Forms.Label();
            this.dateEms = new System.Windows.Forms.DateTimePicker();
            this.lblDrivers = new System.Windows.Forms.Label();
            this.lblCevo = new System.Windows.Forms.Label();
            this.lblDot = new System.Windows.Forms.Label();
            this.dateDot = new System.Windows.Forms.DateTimePicker();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.lblNewName = new System.Windows.Forms.Label();
            this.txtNewEmail = new System.Windows.Forms.TextBox();
            this.lblMvr = new System.Windows.Forms.Label();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.lblBls = new System.Windows.Forms.Label();
            this.dateMvr = new System.Windows.Forms.DateTimePicker();
            this.dateBls = new System.Windows.Forms.DateTimePicker();
            this.lblMainFormHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLicensure = new System.Windows.Forms.TextBox();
            this.dateCevo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTableHeader
            // 
            this.lblTableHeader.AutoSize = true;
            this.lblTableHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableHeader.Location = new System.Drawing.Point(1678, 85);
            this.lblTableHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTableHeader.Name = "lblTableHeader";
            this.lblTableHeader.Size = new System.Drawing.Size(180, 29);
            this.lblTableHeader.TabIndex = 24;
            this.lblTableHeader.Text = "All Employees";
            // 
            // dateDrivers
            // 
            this.dateDrivers.Location = new System.Drawing.Point(431, 353);
            this.dateDrivers.Margin = new System.Windows.Forms.Padding(4);
            this.dateDrivers.Name = "dateDrivers";
            this.dateDrivers.Size = new System.Drawing.Size(318, 29);
            this.dateDrivers.TabIndex = 35;
            // 
            // tableEmployees
            // 
            this.tableEmployees.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tableEmployees.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEmployees.Location = new System.Drawing.Point(778, 118);
            this.tableEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.tableEmployees.Name = "tableEmployees";
            this.tableEmployees.ReadOnly = true;
            this.tableEmployees.RowHeadersWidth = 72;
            this.tableEmployees.RowTemplate.Height = 31;
            this.tableEmployees.Size = new System.Drawing.Size(1771, 1110);
            this.tableEmployees.TabIndex = 23;
            // 
            // lblEms
            // 
            this.lblEms.AutoSize = true;
            this.lblEms.BackColor = System.Drawing.SystemColors.Control;
            this.lblEms.Location = new System.Drawing.Point(81, 321);
            this.lblEms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEms.Name = "lblEms";
            this.lblEms.Size = new System.Drawing.Size(147, 25);
            this.lblEms.TabIndex = 34;
            this.lblEms.Text = "EMS Expiration";
            // 
            // dateEms
            // 
            this.dateEms.Location = new System.Drawing.Point(75, 351);
            this.dateEms.Margin = new System.Windows.Forms.Padding(4);
            this.dateEms.Name = "dateEms";
            this.dateEms.Size = new System.Drawing.Size(318, 29);
            this.dateEms.TabIndex = 33;
            // 
            // lblDrivers
            // 
            this.lblDrivers.AutoSize = true;
            this.lblDrivers.BackColor = System.Drawing.SystemColors.Control;
            this.lblDrivers.Location = new System.Drawing.Point(434, 325);
            this.lblDrivers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDrivers.Name = "lblDrivers";
            this.lblDrivers.Size = new System.Drawing.Size(150, 25);
            this.lblDrivers.TabIndex = 36;
            this.lblDrivers.Text = "Driver\'s License";
            // 
            // lblCevo
            // 
            this.lblCevo.AutoSize = true;
            this.lblCevo.BackColor = System.Drawing.SystemColors.Control;
            this.lblCevo.Location = new System.Drawing.Point(73, 238);
            this.lblCevo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCevo.Name = "lblCevo";
            this.lblCevo.Size = new System.Drawing.Size(111, 25);
            this.lblCevo.TabIndex = 30;
            this.lblCevo.Text = "Cevo Issue";
            // 
            // lblDot
            // 
            this.lblDot.AutoSize = true;
            this.lblDot.BackColor = System.Drawing.SystemColors.Control;
            this.lblDot.Location = new System.Drawing.Point(434, 238);
            this.lblDot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDot.Name = "lblDot";
            this.lblDot.Size = new System.Drawing.Size(146, 25);
            this.lblDot.TabIndex = 32;
            this.lblDot.Text = "DOT Expiration";
            // 
            // dateDot
            // 
            this.dateDot.Location = new System.Drawing.Point(431, 268);
            this.dateDot.Margin = new System.Windows.Forms.Padding(4);
            this.dateDot.Name = "dateDot";
            this.dateDot.Size = new System.Drawing.Size(318, 29);
            this.dateDot.TabIndex = 31;
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(431, 198);
            this.txtNewName.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(318, 29);
            this.txtNewName.TabIndex = 27;
            // 
            // lblNewName
            // 
            this.lblNewName.AutoSize = true;
            this.lblNewName.BackColor = System.Drawing.SystemColors.Control;
            this.lblNewName.Location = new System.Drawing.Point(434, 170);
            this.lblNewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewName.Name = "lblNewName";
            this.lblNewName.Size = new System.Drawing.Size(64, 25);
            this.lblNewName.TabIndex = 28;
            this.lblNewName.Text = "Name";
            // 
            // txtNewEmail
            // 
            this.txtNewEmail.Location = new System.Drawing.Point(75, 196);
            this.txtNewEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.Size = new System.Drawing.Size(318, 29);
            this.txtNewEmail.TabIndex = 25;
            // 
            // lblMvr
            // 
            this.lblMvr.AutoSize = true;
            this.lblMvr.BackColor = System.Drawing.SystemColors.Control;
            this.lblMvr.Location = new System.Drawing.Point(438, 402);
            this.lblMvr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMvr.Name = "lblMvr";
            this.lblMvr.Size = new System.Drawing.Size(147, 25);
            this.lblMvr.TabIndex = 42;
            this.lblMvr.Text = "MVR Expiration";
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Location = new System.Drawing.Point(328, 594);
            this.btnAddEmp.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(191, 55);
            this.btnAddEmp.TabIndex = 43;
            this.btnAddEmp.Text = "Add Employee";
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // lblBls
            // 
            this.lblBls.AutoSize = true;
            this.lblBls.BackColor = System.Drawing.SystemColors.Control;
            this.lblBls.Location = new System.Drawing.Point(73, 402);
            this.lblBls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBls.Name = "lblBls";
            this.lblBls.Size = new System.Drawing.Size(141, 25);
            this.lblBls.TabIndex = 38;
            this.lblBls.Text = "BLS Expiration";
            // 
            // dateMvr
            // 
            this.dateMvr.Location = new System.Drawing.Point(431, 430);
            this.dateMvr.Margin = new System.Windows.Forms.Padding(4);
            this.dateMvr.Name = "dateMvr";
            this.dateMvr.Size = new System.Drawing.Size(318, 29);
            this.dateMvr.TabIndex = 41;
            // 
            // dateBls
            // 
            this.dateBls.Location = new System.Drawing.Point(73, 430);
            this.dateBls.Margin = new System.Windows.Forms.Padding(4);
            this.dateBls.Name = "dateBls";
            this.dateBls.Size = new System.Drawing.Size(318, 29);
            this.dateBls.TabIndex = 37;
            // 
            // lblMainFormHeader
            // 
            this.lblMainFormHeader.AutoSize = true;
            this.lblMainFormHeader.BackColor = System.Drawing.SystemColors.Control;
            this.lblMainFormHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainFormHeader.Location = new System.Drawing.Point(323, 85);
            this.lblMainFormHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainFormHeader.Name = "lblMainFormHeader";
            this.lblMainFormHeader.Size = new System.Drawing.Size(243, 29);
            this.lblMainFormHeader.TabIndex = 44;
            this.lblMainFormHeader.Text = "Add New Employee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(73, 478);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "Licensure Level";
            // 
            // txtLicensure
            // 
            this.txtLicensure.Location = new System.Drawing.Point(73, 506);
            this.txtLicensure.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicensure.Name = "txtLicensure";
            this.txtLicensure.Size = new System.Drawing.Size(318, 29);
            this.txtLicensure.TabIndex = 39;
            // 
            // dateCevo
            // 
            this.dateCevo.Location = new System.Drawing.Point(75, 266);
            this.dateCevo.Margin = new System.Windows.Forms.Padding(4);
            this.dateCevo.Name = "dateCevo";
            this.dateCevo.Size = new System.Drawing.Size(318, 29);
            this.dateCevo.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(75, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Email";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1029, 66);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(242, 42);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(778, 66);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(242, 42);
            this.btnEdit.TabIndex = 46;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2596, 1377);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblTableHeader);
            this.Controls.Add(this.dateDrivers);
            this.Controls.Add(this.tableEmployees);
            this.Controls.Add(this.lblEms);
            this.Controls.Add(this.dateEms);
            this.Controls.Add(this.lblDrivers);
            this.Controls.Add(this.lblCevo);
            this.Controls.Add(this.lblDot);
            this.Controls.Add(this.dateDot);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.lblNewName);
            this.Controls.Add(this.txtNewEmail);
            this.Controls.Add(this.lblMvr);
            this.Controls.Add(this.btnAddEmp);
            this.Controls.Add(this.lblBls);
            this.Controls.Add(this.dateMvr);
            this.Controls.Add(this.dateBls);
            this.Controls.Add(this.lblMainFormHeader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLicensure);
            this.Controls.Add(this.dateCevo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Employees Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTableHeader;
        private System.Windows.Forms.DateTimePicker dateDrivers;
        private System.Windows.Forms.DataGridView tableEmployees;
        private System.Windows.Forms.Label lblEms;
        private System.Windows.Forms.DateTimePicker dateEms;
        private System.Windows.Forms.Label lblDrivers;
        private System.Windows.Forms.Label lblCevo;
        private System.Windows.Forms.Label lblDot;
        private System.Windows.Forms.DateTimePicker dateDot;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label lblNewName;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Label lblMvr;
        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.Label lblBls;
        private System.Windows.Forms.DateTimePicker dateMvr;
        private System.Windows.Forms.DateTimePicker dateBls;
        private System.Windows.Forms.Label lblMainFormHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLicensure;
        private System.Windows.Forms.DateTimePicker dateCevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}