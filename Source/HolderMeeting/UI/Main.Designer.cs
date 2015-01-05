namespace UI
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mniConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mniImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mniList = new System.Windows.Forms.ToolStripMenuItem();
            this.mniVote = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHolderVote = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPercentHolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPercentVote = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mdiParentManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.mnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdiParentManager)).BeginInit();
            this.SuspendLayout();
            // 
            // mnMain
            // 
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniConnect,
            this.mniHolder,
            this.mniVote,
            this.mniHolderVote,
            this.mniReport,
            this.mniAbout});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnMain.Size = new System.Drawing.Size(798, 24);
            this.mnMain.TabIndex = 1;
            // 
            // mniConnect
            // 
            this.mniConnect.Name = "mniConnect";
            this.mniConnect.Size = new System.Drawing.Size(56, 20);
            this.mniConnect.Text = "Kết nối";
            this.mniConnect.Click += new System.EventHandler(this.mniConnect_Click);
            // 
            // mniHolder
            // 
            this.mniHolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniImport,
            this.mniList});
            this.mniHolder.Name = "mniHolder";
            this.mniHolder.Size = new System.Drawing.Size(65, 20);
            this.mniHolder.Text = "Cổ đông";
            this.mniHolder.Visible = false;
            // 
            // mniImport
            // 
            this.mniImport.Name = "mniImport";
            this.mniImport.Size = new System.Drawing.Size(176, 22);
            this.mniImport.Text = "Import cổ đông";
            this.mniImport.Click += new System.EventHandler(this.mniImport_Click);
            // 
            // mniList
            // 
            this.mniList.Name = "mniList";
            this.mniList.Size = new System.Drawing.Size(176, 22);
            this.mniList.Text = "Danh sách cổ đông";
            this.mniList.Click += new System.EventHandler(this.mniList_Click);
            // 
            // mniVote
            // 
            this.mniVote.Name = "mniVote";
            this.mniVote.Size = new System.Drawing.Size(75, 20);
            this.mniVote.Text = "Biều quyết";
            this.mniVote.Visible = false;
            this.mniVote.Click += new System.EventHandler(this.mniVote_Click);
            // 
            // mniHolderVote
            // 
            this.mniHolderVote.Name = "mniHolderVote";
            this.mniHolderVote.Size = new System.Drawing.Size(124, 20);
            this.mniHolderVote.Text = "Cổ đông biểu quyết";
            this.mniHolderVote.Visible = false;
            this.mniHolderVote.Click += new System.EventHandler(this.mniHolderVote_Click);
            // 
            // mniReport
            // 
            this.mniReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniPercentHolder,
            this.mniPercentVote});
            this.mniReport.Name = "mniReport";
            this.mniReport.Size = new System.Drawing.Size(69, 20);
            this.mniReport.Text = "Thống kê";
            this.mniReport.Visible = false;
            // 
            // mniPercentHolder
            // 
            this.mniPercentHolder.Name = "mniPercentHolder";
            this.mniPercentHolder.Size = new System.Drawing.Size(155, 22);
            this.mniPercentHolder.Text = "Tỉ lệ tham gia";
            this.mniPercentHolder.Click += new System.EventHandler(this.mniPercentHolder_Click);
            // 
            // mniPercentVote
            // 
            this.mniPercentVote.Name = "mniPercentVote";
            this.mniPercentVote.Size = new System.Drawing.Size(155, 22);
            this.mniPercentVote.Text = "Tỉ lệ biểu quyết";
            this.mniPercentVote.Click += new System.EventHandler(this.mniPercentVote_Click);
            // 
            // mniAbout
            // 
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(52, 20);
            this.mniAbout.Text = "About";
            this.mniAbout.Visible = false;
            this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
            // 
            // mdiParentManager
            // 
            this.mdiParentManager.MdiParent = this;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 361);
            this.Controls.Add(this.mnMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnMain;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đại Hội Cổ Đông";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdiParentManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem mniConnect;
        private System.Windows.Forms.ToolStripMenuItem mniHolder;
        private System.Windows.Forms.ToolStripMenuItem mniReport;
        private System.Windows.Forms.ToolStripMenuItem mniPercentHolder;
        private System.Windows.Forms.ToolStripMenuItem mniPercentVote;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiParentManager;
        private System.Windows.Forms.ToolStripMenuItem mniImport;
        private System.Windows.Forms.ToolStripMenuItem mniList;
        private System.Windows.Forms.ToolStripMenuItem mniVote;
        private System.Windows.Forms.ToolStripMenuItem mniHolderVote;

    }
}