using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BLL.Common;
using BLL.Model;

namespace UI
{
    public partial class frmHolder_Vote : Form
    {
        public frmHolder_Vote()
        {
            InitializeComponent();
        }

        #region function

        void LoadStatusStrip()
        {
            var hb = new HolderBusiness();
            var hvb = new HolderVoteBusiness();
            var totalIsConfirm = hb.TotalConfirm(true);
            var totalShareIsConfirm = hb.TotalShareIsConfirm(true);
            var totalHolderVote = hvb.TotalHolderVote();
            var totalHolderShare = hvb.TotalShareIsVote();

            var str = totalHolderVote > 0 ?
                                        "Số cổ đông biểu quyết: " + string.Format("{0:#,###}", totalHolderVote) + "/" + string.Format("{0:#,###}", totalIsConfirm) + " =  " + Math.Round((decimal)totalHolderVote * 100 / totalIsConfirm, 2) + "%"
                                        : "Chưa có cổ đông biểu quyết";
            str += " | ";
            str += totalHolderShare > 0 ?
                                    "Số cổ phiếu biểu quyết: " + string.Format("{0:#,###}", totalHolderShare) + "/" + string.Format("{0:#,###}", totalShareIsConfirm) + " =  " + Math.Round((decimal)totalHolderShare * 100 / totalShareIsConfirm, 2) + "%"
                                    : "Chưa có cổ phiếu tham gia biểu quyết";
            tstt.Text = str;
        }

        void LoadData(string name, string code, string cmnd)
        {
            var holderBusiness = new HolderBusiness();
            var data = holderBusiness.GetAlls(name, code, cmnd, true);
            var lstHolder = new List<HolderDto>();
            var vb = new VoteBusiness();
            var hvb = new HolderVoteBusiness();

            var countVote = vb.CountVoteIsActive();
            foreach (var holder in data)
            {
                var holderVote = hvb.CountVoteByHolder(holder.Id);
                lstHolder.Add(new HolderDto
                {
                    Id = holder.Id,
                    Code = holder.Code,
                    AuthorizerName = holder.AuthorizerName,
                    Name = holder.Name,
                    TotalShare = holder.TotalShare.HasValue ? string.Format("{0:#,###}", holder.TotalShare.Value) : "0",
                    UpdateDate = holder.UpdateDate.HasValue ? holder.UpdateDate.Value.ToShortDateString() : string.Empty,
                    CreateDate = holder.CreateDate.HasValue ? holder.CreateDate.Value.ToShortDateString() : string.Empty,
                    IsVote = holderVote >= countVote
                });
            }


            gridHolderVote.DataSource = lstHolder.OrderBy(t => t.IsVote);

        }

        void ReloadForm()
        {
            holderTableAdapter.Connection.ConnectionString = BoConstant.Config.ConnectionString;
            holder_VoteTableAdapter.Connection.ConnectionString = BoConstant.Config.ConnectionString;

            holderTableAdapter.Fill(holderMeetingDataSet.Holder);
            holder_VoteTableAdapter.Fill(holderMeetingDataSet.Holder_Vote);

            //gridHolderVote.RefreshDataSource();
        }

        #endregion

        #region protected

        private void frmHolder_Vote_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoConstant.Config.ConnectionString))
            {
                MessageBox.Show("Chưa kết nối máy chủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            ReloadForm();

            //LoadData(string.Empty, string.Empty);

            #region autocomplete

            var txtCode = txtSCode.MaskBox;

            var hb = new HolderBusiness();

            var customSourceCode = new AutoCompleteStringCollection();
            customSourceCode.AddRange(hb.GetAllsCode().ToArray());

            txtCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCode.AutoCompleteCustomSource = customSourceCode;


            var txtName = txtSName.MaskBox;

            var customSourceName = new AutoCompleteStringCollection();
            customSourceName.AddRange(hb.GetAllsName().ToArray());

            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteCustomSource = customSourceName;

            var cmnd = txtCmnd.MaskBox;

            var customSourceCmnd = new AutoCompleteStringCollection();
            customSourceCmnd.AddRange(hb.GetAllsCmnd().ToArray());

            cmnd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmnd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmnd.AutoCompleteCustomSource = customSourceCmnd;

            #endregion

            LoadStatusStrip();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoConstant.Config.ConnectionString))
            {
                MessageBox.Show("Chưa kết nối máy chủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            LoadData(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCmnd.Text.Trim());
        }

        private void btnRowVote_Click(object sender, EventArgs e)
        {
            try
            {
                var dataRowView = (DataRowView)gvHolderVote.GetRow(gvHolderVote.FocusedRowHandle);

                if (dataRowView.Row.ItemArray.Any())
                {
                    var id = int.Parse(dataRowView.Row.ItemArray[0].ToString());
                    var name = dataRowView.Row.ItemArray[2].ToString();

                    var vb = new VoteBusiness();
                    var hvb = new HolderVoteBusiness();

                    if (id > 0)
                        if (hvb.CountVoteByHolder(id) < vb.CountVoteIsActive())
                        {
                            var frmDialog = new HolderVoteDialog { _holderId = id };
                            var result = frmDialog.ShowDialog();
                            if (result == DialogResult.OK)
                                ReloadForm();
                        }
                        else
                            MessageBox.Show("Cổ đông \"" + name + "\" đã biểu quyết hoàn tất.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void txtSCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }

        #endregion

    }
}