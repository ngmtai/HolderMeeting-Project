﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using BLL;
using BLL.Common;
using BLL.Model;
using UI.Common;

namespace UI
{
    public partial class frmHolder_Vote : Form
    {
        public frmHolder_Vote()
        {
            InitializeComponent();
            panelControl1.AutoScroll = true;
        }

        private Socket _socket;
        private IPEndPoint _iep;
        private byte[] _data;

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

        void ReloadForm(string name, string code, string cmnd)
        {
            try
            {
                var connection = new SqlConnection(BoConstant.Config.ConnectionString);
                var cmd = new SqlCommand
                {
                    CommandText =
                        string.Format(@"SELECT Id, Code, Name, TotalShare, AuthorizerName, IsActive, IsConfirm, CompanyId, CreateDate, CreateUser, UpdateDate, UpdateUser, CMND
                                    FROM Holder
                                    WHERE (IsActive = 1) AND (IsConfirm = 1) 
                                            AND ('{0}' = '' OR Code LIKE '%{0}%') 
                                            AND ('{1}' = '' OR Name LIKE '%{1}%') 
                                            AND ('{2}' = '' OR CMND LIKE '%{2}%')", code, name, cmnd),
                    CommandType = CommandType.Text,
                    Connection = connection
                };

                var da = new SqlDataAdapter(cmd);
                holderMeetingDataSet.Holder.Clear();
                da.Fill(holderMeetingDataSet.Holder);

                //holderTableAdapter.Connection.ConnectionString = BoConstant.Config.ConnectionString;
                holder_VoteTableAdapter.Connection.ConnectionString = BoConstant.Config.ConnectionString;

                //holderTableAdapter.FillBy(holderMeetingDataSet.Holder, code, name, cmnd);
                ////holderTableAdapter.Fill(holderMeetingDataSet.Holder);

                holder_VoteTableAdapter.Fill(holderMeetingDataSet.Holder_Vote);
                gridHolderVote.RefreshDataSource();
            }
            catch { }
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

            ReloadForm(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCmnd.Text.Trim());

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

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _iep = new IPEndPoint(IPAddress.Broadcast, 9050);
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            _data = Encoding.ASCII.GetBytes(MyConstant.Config.KeyWordVote);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoConstant.Config.ConnectionString))
            {
                MessageBox.Show("Chưa kết nối máy chủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            ReloadForm(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCmnd.Text.Trim());
        }

        private void btnRowVote_Click(object sender, EventArgs e)
        {
            try
            {
                var dataRowView = (DataRowView)gvHolderVote.GetRow(gvHolderVote.FocusedRowHandle);

                if (dataRowView.Row.ItemArray.Any())
                {
                    var id = int.Parse(dataRowView.Row.ItemArray[0].ToString());
                    //var name = dataRowView.Row.ItemArray[2].ToString();

                    //var vb = new VoteBusiness();
                    //var hvb = new HolderVoteBusiness();

                    if (id > 0)
                    //if (hvb.CountVoteByHolder(id) < vb.CountVoteIsActive())
                    {
                        var frmDialog = new HolderVoteDialog { HolderId = id };
                        var result = frmDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            ReloadForm(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCmnd.Text.Trim());

                            #region send message

                            try
                            {
                                _socket.SendTo(_data, _iep);
                            }
                            catch { }

                            #endregion
                        }
                    }
                    //else
                    //    MessageBox.Show("Cổ đông \"" + name + "\" đã biểu quyết hoàn tất.", "Thông báo",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Information);
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