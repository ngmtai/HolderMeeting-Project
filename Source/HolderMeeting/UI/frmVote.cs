using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using BLL.Common;
using DAL;
using DevExpress.XtraSplashScreen;

namespace UI
{
    public partial class frmVote : Form
    {
        private int _id;

        public frmVote()
        {
            InitializeComponent();
        }

        #region function

        void LoadData()
        {
            memDisplayName.Text = "";
            chkIsActive.Checked = false;
            numOrder.Text = string.Empty;
            _id = 0;

            var vb = new VoteBusiness();
            gridVote.DataSource = vb.GetAlls(null);
        }

        #endregion

        #region protected

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memDisplayName.Text))
            {
                MessageBox.Show("Nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                memDisplayName.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                var vb = new VoteBusiness();

                if (_id <= 0)
                {
                    var model = new Vote
                    {
                        DisplayName = memDisplayName.Text.Trim(),
                        IsActive = chkIsActive.Checked,
                        CreateDate = DateTime.Now,
                        Order = int.Parse(numOrder.Text)
                    };

                    if (vb.Save(model) > 0)
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (vb.Update(_id, memDisplayName.Text.Trim(), chkIsActive.Checked, int.Parse(numOrder.Text)))
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
            }
        }

        private void frmVote_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoConstant.Config.ConnectionString))
            {
                MessageBox.Show("Chưa kết nối máy chủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            LoadData();
        }

        private void gvVote_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var vote = (Vote)gvVote.GetRow(e.RowHandle);

                if (vote != null && vote.Id > 0)
                {
                    _id = vote.Id;
                    memDisplayName.Text = vote.DisplayName;
                    if (vote.IsActive != null) chkIsActive.Checked = vote.IsActive.Value;
                    if (vote.Order != null) numOrder.Text = vote.Order.Value.ToString();
                }
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var vb = new VoteBusiness();
            var vote = (Vote)gvVote.GetRow(gvVote.FocusedRowHandle);

            if (vote != null && vote.Id > 0)
            {
                if (vb.CheckIsVote(vote.Id))
                {
                    MessageBox.Show("Biểu quyết này đã được sử dụng, không thể xóa", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (vb.Delete(vote.Id))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    LoadData();
                }
                else
                    MessageBox.Show("Lỗi. Thử lại sau", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            var vb = new VoteBusiness();
            var vote = (Vote)gvVote.GetRow(gvVote.FocusedRowHandle);

            if (vote != null && vote.Id > 0)
                if (vb.Update(vote.Id, !vote.IsActive.Value))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            memDisplayName.Text = "";
            chkIsActive.Checked = false;
            numOrder.Text = string.Empty;
            _id = 0;
        }

        #endregion
    
    }
}
