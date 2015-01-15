namespace UI
{
    partial class BroadcastReceiver
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
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(12, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(63, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "labelControl1";
            // 
            // BroadcastReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 228);
            this.Controls.Add(this.lbl);
            this.Name = "BroadcastReceiver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receiver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BroadcastReceiver_FormClosing);
            this.Load += new System.EventHandler(this.BroadcastReceiver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl;
    }
}