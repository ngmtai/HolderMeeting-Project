using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAL;

namespace UI
{
    public partial class EditHolderDialog : Form
    {
        public int _holderId;

        public EditHolderDialog()
        {
            InitializeComponent();
        }

        #region function

        void LoadDetail(int holderId)
        {
            var hb = new HolderBusiness();
            var detail = hb.Detail(holderId);
            if (detail != null)
            {
                txtCode.Text = detail.Code;
                txtName.Text = detail.Name;
                txtCmnd.Text = detail.CMND;
                if (detail.TotalShare != null) numTotalShare.Text = detail.TotalShare.Value.ToString();
                if (detail.IsConfirm != null) chkIsConfirm.Checked = detail.IsConfirm.Value;
                txtWorkUnit.Text = detail.WorkUnit;
                txtAddress.Text = detail.Address;
                txtPhone.Text = detail.Phone;
            }
        }

        void ClearForm()
        {
            txtWorkUnit.Text = txtAddress.Text = txtPhone.Text = numTotalShare.Text = txtCmnd.Text = txtCode.Text = txtName.Text = string.Empty;
            chkIsConfirm.Checked = false;
        }

        #endregion

        #region event

        private void EditHolderDialog_Load(object sender, EventArgs e)
        {
            if (_holderId > 0)
                LoadDetail(_holderId);
            else ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region valid

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã cổ đông không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên cổ đông không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(numTotalShare.Text))
            {
                MessageBox.Show("Số lượng cổ phiếu không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalShare;
            decimal.TryParse(numTotalShare.Text, out totalShare);
            if (totalShare <= 0)
            {
                MessageBox.Show("Số lượng cổ phiếu phải > 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            var hb = new HolderBusiness();
            if (_holderId <= 0)//Thêm mới
            {
                if (!hb.CheckExist(txtCode.Text.Trim(), txtName.Text.Trim(), string.Empty, totalShare, txtCmnd.Text.Trim()))
                {
                    var lstHolder = new List<Holder>
                    {
                        new Holder
                        {
                            Code = txtCode.Text.Trim(),
                            Name = txtName.Text.Trim(),
                            CMND = txtCmnd.Text.Trim(),
                            AuthorizerName = string.Empty,
                            TotalShare = totalShare,
                            IsActive = true,
                            IsConfirm = chkIsConfirm.Checked,
                            CreateDate = DateTime.Now,
                            WorkUnit = txtWorkUnit.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            Phone = txtPhone.Text.Trim()
                        }
                    };
                    var result = hb.Saves(lstHolder);
                    if (result)
                    {
                        MessageBox.Show("Thêm cổ đông thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                    MessageBox.Show("Cổ đông này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else//Edit
            {
                if (hb.Edit(new Holder
                {
                    Id = _holderId,
                    Code = txtCode.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    CMND = txtCmnd.Text.Trim(),
                    AuthorizerName = string.Empty,
                    TotalShare = totalShare,
                    IsActive = true,
                    IsConfirm = chkIsConfirm.Checked,
                    UpdateDate = DateTime.Now,
                    WorkUnit = txtWorkUnit.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                }))
                {
                    MessageBox.Show("Sửa thông tin cổ đông thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Lỗi, hãy thử lại sau", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

    }
}
