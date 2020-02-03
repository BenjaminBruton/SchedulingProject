namespace C969___BOP1___BBruton___Scheduling_Project
{
    partial class Dashboard
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
            this.groupBoxAppCal = new System.Windows.Forms.GroupBox();
            this.btnDeleteApp = new System.Windows.Forms.Button();
            this.btnUpdateApp = new System.Windows.Forms.Button();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.dgvAppCal = new System.Windows.Forms.DataGridView();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonWeek = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteCust = new System.Windows.Forms.Button();
            this.btnUpdateCust = new System.Windows.Forms.Button();
            this.btnAddCust = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCustReport = new System.Windows.Forms.Button();
            this.btnSchedReport = new System.Windows.Forms.Button();
            this.btnAppReport = new System.Windows.Forms.Button();
            this.groupBoxAppCal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppCal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAppCal
            // 
            this.groupBoxAppCal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBoxAppCal.Controls.Add(this.btnDeleteApp);
            this.groupBoxAppCal.Controls.Add(this.btnUpdateApp);
            this.groupBoxAppCal.Controls.Add(this.btnAddApp);
            this.groupBoxAppCal.Controls.Add(this.dgvAppCal);
            this.groupBoxAppCal.Controls.Add(this.radioButtonMonth);
            this.groupBoxAppCal.Controls.Add(this.radioButtonWeek);
            this.groupBoxAppCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAppCal.Location = new System.Drawing.Point(560, 12);
            this.groupBoxAppCal.Name = "groupBoxAppCal";
            this.groupBoxAppCal.Size = new System.Drawing.Size(702, 755);
            this.groupBoxAppCal.TabIndex = 0;
            this.groupBoxAppCal.TabStop = false;
            this.groupBoxAppCal.Text = "Appointment Calendar";
            // 
            // btnDeleteApp
            // 
            this.btnDeleteApp.Location = new System.Drawing.Point(533, 661);
            this.btnDeleteApp.Name = "btnDeleteApp";
            this.btnDeleteApp.Size = new System.Drawing.Size(164, 61);
            this.btnDeleteApp.TabIndex = 5;
            this.btnDeleteApp.Text = "Delete";
            this.btnDeleteApp.UseVisualStyleBackColor = true;
            this.btnDeleteApp.Click += new System.EventHandler(this.btnDeleteApp_Click);
            // 
            // btnUpdateApp
            // 
            this.btnUpdateApp.Location = new System.Drawing.Point(273, 661);
            this.btnUpdateApp.Name = "btnUpdateApp";
            this.btnUpdateApp.Size = new System.Drawing.Size(164, 61);
            this.btnUpdateApp.TabIndex = 4;
            this.btnUpdateApp.Text = "Update";
            this.btnUpdateApp.UseVisualStyleBackColor = true;
            this.btnUpdateApp.Click += new System.EventHandler(this.btnUpdateApp_Click);
            // 
            // btnAddApp
            // 
            this.btnAddApp.Location = new System.Drawing.Point(7, 661);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(164, 61);
            this.btnAddApp.TabIndex = 3;
            this.btnAddApp.Text = "Add";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // dgvAppCal
            // 
            this.dgvAppCal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvAppCal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppCal.Location = new System.Drawing.Point(6, 160);
            this.dgvAppCal.Name = "dgvAppCal";
            this.dgvAppCal.RowHeadersWidth = 82;
            this.dgvAppCal.RowTemplate.Height = 33;
            this.dgvAppCal.Size = new System.Drawing.Size(690, 464);
            this.dgvAppCal.TabIndex = 2;
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Location = new System.Drawing.Point(380, 104);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(215, 41);
            this.radioButtonMonth.TabIndex = 1;
            this.radioButtonMonth.TabStop = true;
            this.radioButtonMonth.Text = "Month View";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            // 
            // radioButtonWeek
            // 
            this.radioButtonWeek.AutoSize = true;
            this.radioButtonWeek.Location = new System.Drawing.Point(121, 104);
            this.radioButtonWeek.Name = "radioButtonWeek";
            this.radioButtonWeek.Size = new System.Drawing.Size(207, 41);
            this.radioButtonWeek.TabIndex = 0;
            this.radioButtonWeek.TabStop = true;
            this.radioButtonWeek.Text = "Week View";
            this.radioButtonWeek.UseVisualStyleBackColor = true;
            this.radioButtonWeek.CheckedChanged += new System.EventHandler(this.radioButtonWeek_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(60, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 85);
            this.label1.TabIndex = 1;
            this.label1.Text = "APPointed";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnDeleteCust);
            this.groupBox1.Controls.Add(this.btnUpdateCust);
            this.groupBox1.Controls.Add(this.btnAddCust);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer(s)";
            // 
            // btnDeleteCust
            // 
            this.btnDeleteCust.Location = new System.Drawing.Point(350, 56);
            this.btnDeleteCust.Name = "btnDeleteCust";
            this.btnDeleteCust.Size = new System.Drawing.Size(164, 61);
            this.btnDeleteCust.TabIndex = 8;
            this.btnDeleteCust.Text = "Delete";
            this.btnDeleteCust.UseVisualStyleBackColor = true;
            this.btnDeleteCust.Click += new System.EventHandler(this.btnDeleteCust_Click);
            // 
            // btnUpdateCust
            // 
            this.btnUpdateCust.Location = new System.Drawing.Point(180, 56);
            this.btnUpdateCust.Name = "btnUpdateCust";
            this.btnUpdateCust.Size = new System.Drawing.Size(164, 61);
            this.btnUpdateCust.TabIndex = 7;
            this.btnUpdateCust.Text = "Update";
            this.btnUpdateCust.UseVisualStyleBackColor = true;
            this.btnUpdateCust.Click += new System.EventHandler(this.btnUpdateCust_Click);
            // 
            // btnAddCust
            // 
            this.btnAddCust.Location = new System.Drawing.Point(6, 56);
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.Size = new System.Drawing.Size(164, 61);
            this.btnAddCust.TabIndex = 6;
            this.btnAddCust.Text = "Add";
            this.btnAddCust.UseVisualStyleBackColor = true;
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.btnCustReport);
            this.groupBox2.Controls.Add(this.btnSchedReport);
            this.groupBox2.Controls.Add(this.btnAppReport);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 472);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reports";
            // 
            // btnCustReport
            // 
            this.btnCustReport.Location = new System.Drawing.Point(62, 317);
            this.btnCustReport.Name = "btnCustReport";
            this.btnCustReport.Size = new System.Drawing.Size(394, 62);
            this.btnCustReport.TabIndex = 2;
            this.btnCustReport.Text = "Customer Report";
            this.btnCustReport.UseVisualStyleBackColor = true;
            this.btnCustReport.Click += new System.EventHandler(this.btnCustReport_Click);
            // 
            // btnSchedReport
            // 
            this.btnSchedReport.Location = new System.Drawing.Point(62, 218);
            this.btnSchedReport.Name = "btnSchedReport";
            this.btnSchedReport.Size = new System.Drawing.Size(394, 62);
            this.btnSchedReport.TabIndex = 1;
            this.btnSchedReport.Text = "Consultant Schedules";
            this.btnSchedReport.UseVisualStyleBackColor = true;
            this.btnSchedReport.Click += new System.EventHandler(this.btnSchedReport_Click);
            // 
            // btnAppReport
            // 
            this.btnAppReport.Location = new System.Drawing.Point(62, 111);
            this.btnAppReport.Name = "btnAppReport";
            this.btnAppReport.Size = new System.Drawing.Size(394, 62);
            this.btnAppReport.TabIndex = 0;
            this.btnAppReport.Text = "Number of Appointments";
            this.btnAppReport.UseVisualStyleBackColor = true;
            this.btnAppReport.Click += new System.EventHandler(this.btnAppReport_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 779);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxAppCal);
            this.MinimumSize = new System.Drawing.Size(1300, 850);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.groupBoxAppCal.ResumeLayout(false);
            this.groupBoxAppCal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppCal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAppCal;
        private System.Windows.Forms.Button btnDeleteApp;
        private System.Windows.Forms.Button btnUpdateApp;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.DataGridView dgvAppCal;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.RadioButton radioButtonWeek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteCust;
        private System.Windows.Forms.Button btnUpdateCust;
        private System.Windows.Forms.Button btnAddCust;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCustReport;
        private System.Windows.Forms.Button btnSchedReport;
        private System.Windows.Forms.Button btnAppReport;
    }
}

