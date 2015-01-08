namespace UI
{
    partial class frmHolder_Vote
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridHolderVote = new DevExpress.XtraGrid.GridControl();
            this.holderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holderMeetingDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holderMeetingDataSet = new UI.HolderMeetingDataSet();
            this.gvHolderVote = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRowVote = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.holderTableAdapter = new UI.HolderMeetingDataSetTableAdapters.HolderTableAdapter();
            this.holderVoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holder_VoteTableAdapter = new UI.HolderMeetingDataSetTableAdapters.Holder_VoteTableAdapter();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.stTotal = new System.Windows.Forms.StatusStrip();
            this.tstt = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtCmnd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHolderVote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderMeetingDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderMeetingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHolderVote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowVote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderVoteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.stTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCmnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDetail
            // 
            this.gridDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gridDetail.GridControl = this.gridHolderVote;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.OptionsBehavior.Editable = false;
            this.gridDetail.OptionsView.ShowGroupPanel = false;
            this.gridDetail.ViewCaption = "Chi tiết biểu quyết";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Biểu quyết";
            this.gridColumn11.FieldName = "VoteName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Trả lời";
            this.gridColumn12.FieldName = "AnswerName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Số lượng cổ phiếu";
            this.gridColumn13.FieldName = "TotalShare";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Ngày tạo";
            this.gridColumn14.FieldName = "CreateDate";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            // 
            // gridHolderVote
            // 
            this.gridHolderVote.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridHolderVote.DataSource = this.holderBindingSource;
            this.gridHolderVote.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridDetail;
            gridLevelNode1.RelationName = "FK_Holder_Vote_Holder";
            this.gridHolderVote.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridHolderVote.Location = new System.Drawing.Point(2, 2);
            this.gridHolderVote.MainView = this.gvHolderVote;
            this.gridHolderVote.Name = "gridHolderVote";
            this.gridHolderVote.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnRowVote});
            this.gridHolderVote.Size = new System.Drawing.Size(943, 319);
            this.gridHolderVote.TabIndex = 2;
            this.gridHolderVote.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHolderVote,
            this.gridDetail});
            // 
            // holderBindingSource
            // 
            this.holderBindingSource.DataMember = "Holder";
            this.holderBindingSource.DataSource = this.holderMeetingDataSetBindingSource;
            // 
            // holderMeetingDataSetBindingSource
            // 
            this.holderMeetingDataSetBindingSource.DataSource = this.holderMeetingDataSet;
            this.holderMeetingDataSetBindingSource.Position = 0;
            // 
            // holderMeetingDataSet
            // 
            this.holderMeetingDataSet.DataSetName = "HolderMeetingDataSet";
            this.holderMeetingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvHolderVote
            // 
            this.gvHolderVote.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvHolderVote.GridControl = this.gridHolderVote;
            this.gvHolderVote.Name = "gvHolderVote";
            this.gvHolderVote.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvHolderVote.OptionsCustomization.AllowGroup = false;
            this.gvHolderVote.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Id";
            this.gridColumn7.FieldName = "Id";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã cổ đông";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số lượng cổ phiếu";
            this.gridColumn3.FieldName = "TotalShare";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Người ủy quyền";
            this.gridColumn4.FieldName = "AuthorizerName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tham dự?";
            this.gridColumn5.FieldName = "IsConfirm";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ngày cập nhật";
            this.gridColumn6.FieldName = "UpdateDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "CreateDate";
            this.gridColumn8.FieldName = "CreateDate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Biểu quyết?";
            this.gridColumn9.FieldName = "IsVote";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Biểu quyết";
            this.gridColumn10.ColumnEdit = this.btnRowVote;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            // 
            // btnRowVote
            // 
            this.btnRowVote.AutoHeight = false;
            this.btnRowVote.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Biểu quyết", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::UI.Properties.Resources.edittask_32x32, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnRowVote.Name = "btnRowVote";
            this.btnRowVote.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnRowVote.Click += new System.EventHandler(this.btnRowVote_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(947, 108);
            this.panelControl2.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtCmnd);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtSName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtSCode);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(943, 104);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(826, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 38);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(316, 43);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(194, 20);
            this.txtSName.TabIndex = 2;
            this.txtSName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSCode_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(238, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên cổ đông:";
            // 
            // txtSCode
            // 
            this.txtSCode.Location = new System.Drawing.Point(99, 43);
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(109, 20);
            this.txtSCode.TabIndex = 1;
            this.txtSCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSCode_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã cổ đông:";
            // 
            // holderTableAdapter
            // 
            this.holderTableAdapter.ClearBeforeFill = true;
            // 
            // holderVoteBindingSource
            // 
            this.holderVoteBindingSource.DataMember = "Holder_Vote";
            this.holderVoteBindingSource.DataSource = this.holderMeetingDataSetBindingSource;
            // 
            // holder_VoteTableAdapter
            // 
            this.holder_VoteTableAdapter.ClearBeforeFill = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.stTotal);
            this.panelControl1.Controls.Add(this.gridHolderVote);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 108);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(947, 323);
            this.panelControl1.TabIndex = 3;
            // 
            // stTotal
            // 
            this.stTotal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstt});
            this.stTotal.Location = new System.Drawing.Point(2, 299);
            this.stTotal.Name = "stTotal";
            this.stTotal.Size = new System.Drawing.Size(943, 22);
            this.stTotal.TabIndex = 3;
            this.stTotal.Text = "aBc";
            // 
            // tstt
            // 
            this.tstt.Name = "tstt";
            this.tstt.Size = new System.Drawing.Size(26, 17);
            this.tstt.Text = "aBc";
            // 
            // txtCmnd
            // 
            this.txtCmnd.Location = new System.Drawing.Point(603, 43);
            this.txtCmnd.Name = "txtCmnd";
            this.txtCmnd.Size = new System.Drawing.Size(194, 20);
            this.txtCmnd.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(536, 46);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "CMND:";
            // 
            // frmHolder_Vote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(947, 431);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmHolder_Vote";
            this.Text = "Danh sách cổ đông biểu quyết";
            this.Load += new System.EventHandler(this.frmHolder_Vote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHolderVote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderMeetingDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderMeetingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHolderVote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowVote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holderVoteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.stTotal.ResumeLayout(false);
            this.stTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCmnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtSName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource holderMeetingDataSetBindingSource;
        private HolderMeetingDataSet holderMeetingDataSet;
        private System.Windows.Forms.BindingSource holderBindingSource;
        private HolderMeetingDataSetTableAdapters.HolderTableAdapter holderTableAdapter;
        private System.Windows.Forms.BindingSource holderVoteBindingSource;
        private HolderMeetingDataSetTableAdapters.Holder_VoteTableAdapter holder_VoteTableAdapter;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.StatusStrip stTotal;
        private System.Windows.Forms.ToolStripStatusLabel tstt;
        private DevExpress.XtraGrid.GridControl gridHolderVote;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHolderVote;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRowVote;
        private DevExpress.XtraEditors.TextEdit txtCmnd;
        private DevExpress.XtraEditors.LabelControl labelControl3;

    }
}