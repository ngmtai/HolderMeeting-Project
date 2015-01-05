namespace UI
{
    partial class ReportCondition
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
            this.lblCompany = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalShared = new DevExpress.XtraEditors.LabelControl();
            this.lblShared = new DevExpress.XtraEditors.LabelControl();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblCompany
            // 
            this.lblCompany.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(116, 12);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(53, 16);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company";
            // 
            // lblTotalShared
            // 
            this.lblTotalShared.Location = new System.Drawing.Point(31, 62);
            this.lblTotalShared.Name = "lblTotalShared";
            this.lblTotalShared.Size = new System.Drawing.Size(58, 13);
            this.lblTotalShared.TabIndex = 1;
            this.lblTotalShared.Text = "TotalShared";
            // 
            // lblShared
            // 
            this.lblShared.Location = new System.Drawing.Point(31, 98);
            this.lblShared.Name = "lblShared";
            this.lblShared.Size = new System.Drawing.Size(34, 13);
            this.lblShared.TabIndex = 2;
            this.lblShared.Text = "Shared";
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(31, 130);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(37, 13);
            this.lblPercent.TabIndex = 3;
            this.lblPercent.Text = "Percent";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(75, 170);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(282, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "* Điều kiện mở đại hội là tỉ lệ cổ phiếu tham gia phải > 70%";
            // 
            // ReportCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 205);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblShared);
            this.Controls.Add(this.lblTotalShared);
            this.Controls.Add(this.lblCompany);
            this.Name = "ReportCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều kiện mở đại hội";
            this.Load += new System.EventHandler(this.ReportCondition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCompany;
        private DevExpress.XtraEditors.LabelControl lblTotalShared;
        private DevExpress.XtraEditors.LabelControl lblShared;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}