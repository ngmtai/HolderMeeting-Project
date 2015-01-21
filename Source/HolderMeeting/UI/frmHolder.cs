using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using BLL;
using BLL.Common;
using BLL.Model;
using DAL;
using UI.Common;

namespace UI
{
    public partial class frmHolder : Form
    {
        private int _id;
        private Socket _socket;
        private IPEndPoint _iep;
        private byte[] _data;

        public frmHolder()
        {
            InitializeComponent();
            panelControl4.AutoScroll = true;
        }

        #region function

        void ClearForm()
        {
            txtAuthorizerName.Text = lblTotalShare.Text = lblCreateDate.Text = lblName.Text = lblCode.Text = string.Empty;
            chkIsConfirm.Checked = false;
            btnChange.Enabled = false;
        }

        void LoadStatusStrip()
        {
            var hb = new HolderBusiness();
            var cb = new CompanyBusiness();
            var totalIsConfirm = hb.TotalConfirm(true);
            var totalConfirm = hb.TotalConfirm(null);
            var totalShareIsConfirm = hb.TotalShareIsConfirm(true);
            var share = cb.Detail().TotalShare;

            if (share != null)
            {
                var totalShare = share.Value;

                var countConfirm = string.Format("{0:#,###}", totalShareIsConfirm);
                var percentTotalShared = Math.Round(totalShareIsConfirm * 100 / totalShare, 2) + "%";

                var str = "Số cổ đông tham gia: " + string.Format("{0:#,###}", totalIsConfirm) + "/" + string.Format("{0:#,###}", totalConfirm) + " =  " + Math.Round((decimal)totalIsConfirm * 100 / totalConfirm, 2) + "% | Tổng số cổ phiếu tham gia: " +
                          countConfirm + "/" + string.Format("{0:#,###}", totalShare) + " =  " + percentTotalShared;
                tstt.Text = str;
            }
        }

        void LoadData(string name, string code, string cmnd)
        {
            var holderBusiness = new HolderBusiness();
            var data = holderBusiness.GetAlls(name, code, cmnd, null);
            var lstHolder = new List<HolderDto>();
            foreach (var holder in data)
            {
                lstHolder.Add(new HolderDto
                {
                    Id = holder.Id,
                    Code = holder.Code,
                    AuthorizerName = holder.AuthorizerName,
                    Name = holder.Name,
                    CMND = holder.CMND,
                    TotalShare = holder.TotalShare.HasValue ? string.Format("{0:#,###}", holder.TotalShare.Value) : "0",
                    UpdateDate = holder.UpdateDate.HasValue ? holder.UpdateDate.Value.ToShortDateString() : string.Empty,
                    CreateDate = holder.CreateDate.HasValue ? holder.CreateDate.Value.ToShortDateString() : string.Empty,
                    IsConfirm = holder.IsConfirm != null && holder.IsConfirm.Value
                });
            }
            gridHolder.DataSource = lstHolder;

            ClearForm();
        }

        void SendMessage()
        {
            try
            {
                _socket.SendTo(_data, _iep);
            }
            catch { }
        }

        #endregion

        #region protected

        private void frmHolder_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoConstant.Config.ConnectionString))
            {
                MessageBox.Show("Chưa kết nối máy chủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            LoadData(string.Empty, string.Empty, string.Empty);

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

            var cmnd = txtCMND.MaskBox;

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
            _data = Encoding.ASCII.GetBytes(MyConstant.Config.KeyWordCondition);
        }

        private void gvHolder_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var holder = (HolderDto)gvHolder.GetRow(e.RowHandle);

                if (holder != null && holder.Id > 0)
                {
                    _id = holder.Id;

                    lblCode.Text = holder.Code;
                    lblName.Text = holder.Name;
                    lblTotalShare.Text = holder.TotalShare;
                    lblCreateDate.Text = holder.CreateDate;
                    chkIsConfirm.Checked = holder.IsConfirm;
                    txtAuthorizerName.Text = holder.AuthorizerName;

                    if (_id > 0)
                        btnChange.Enabled = true;
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (_id > 0)
            {
                if (
                    MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    var model = new Holder
                    {
                        Id = _id,
                        IsConfirm = chkIsConfirm.Checked,
                        AuthorizerName = txtAuthorizerName.Text.Trim()
                    };

                    var hb = new HolderBusiness();
                    var hvb = new HolderVoteBusiness();
                    if (hvb.TotalSharedIsVote(_id) > 0)
                        MessageBox.Show("Cổ đông đã biểu quyết, không thể thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (hb.UpdateHolder(model))
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);

                            LoadData(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCMND.Text.Trim());
                            LoadStatusStrip();
                            SendMessage();
                        }
                        else
                            MessageBox.Show("Lỗi. Thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Chưa chọn item", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCMND.Text.Trim());
        }

        private void txtSCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }

        private void txtAuthorizerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnChange.PerformClick();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new EditHolderDialog();
            var aBc = frm.ShowDialog();
            if (aBc == DialogResult.OK)
            {
                LoadData(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCMND.Text.Trim());
                LoadStatusStrip();
                SendMessage();
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var holder = (HolderDto)gvHolder.GetRow(gvHolder.FocusedRowHandle);

            var frm = new EditHolderDialog { _holderId = holder.Id };
            var aBc = frm.ShowDialog();
            if (aBc == DialogResult.OK)
            {
                LoadData(txtSName.Text.Trim(), txtSCode.Text.Trim(), txtCMND.Text.Trim());
                LoadStatusStrip();
                SendMessage();
            }
        }

        #endregion

    }
}