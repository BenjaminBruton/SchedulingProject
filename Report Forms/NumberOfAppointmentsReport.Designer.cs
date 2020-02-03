namespace C969___BOP1___BBruton___Scheduling_Project
{
    partial class NumberOfAppointmentsReport
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
            this.dgvAppTypes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppTypes
            // 
            this.dgvAppTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvAppTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppTypes.Location = new System.Drawing.Point(31, 122);
            this.dgvAppTypes.Margin = new System.Windows.Forms.Padding(6);
            this.dgvAppTypes.Name = "dgvAppTypes";
            this.dgvAppTypes.RowHeadersWidth = 82;
            this.dgvAppTypes.Size = new System.Drawing.Size(930, 613);
            this.dgvAppTypes.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Appointment Types by Month";
            // 
            // NumberOfAppointmentsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 764);
            this.Controls.Add(this.dgvAppTypes);
            this.Controls.Add(this.label1);
            this.Name = "NumberOfAppointmentsReport";
            this.Text = "NumberOfAppointmentsReport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppTypes;
        private System.Windows.Forms.Label label1;
    }
}