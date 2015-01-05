namespace UI
{
    partial class ImportHolder
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.btnFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn file Excel:";
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(93, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(325, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(92, 49);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 32);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "Chọn File";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(187, 49);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 32);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(279, 49);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 32);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(12, 97);
            this.pb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(406, 28);
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb.TabIndex = 8;
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // ImportHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 137);
            this.ControlBox = false;
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.labelControl1);
            this.Name = "ImportHolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Holder";
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraEditors.SimpleButton btnFile;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.ProgressBar pb;
        private System.ComponentModel.BackgroundWorker bgw;
    }
}