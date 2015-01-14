using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using BLL.Common;
using UI.Common;

namespace UI
{
    public partial class frmConnect : Form
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIp.Text.Trim()))
            {
                MessageBox.Show("Phải nhập đỉa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIp.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtUser.Text.Trim()) && !string.IsNullOrEmpty(txtPass.Text.Trim()))
                BoConstant.Config.ConnectionTemp = string.Format(BoConstant.Config.ConnectionTemp, txtIp.Text,
                    string.Format(BoConstant.Config.ConnectionAuthorize, txtUser.Text.Trim(), txtPass.Text.Trim()));
            else
                BoConstant.Config.ConnectionTemp = string.Format(BoConstant.Config.ConnectionTemp, txtIp.Text,
                    BoConstant.Config.ConnectionNonAuthor);
            BoConstant.Config.ConnectionString = BoConstant.Config.ConnectionTemp;

            try
            {
                MyConstant.Config.IpAddress = IPAddress.Parse(txtIp.Text.Trim()).ToString();
            }
            catch { }

            if (BoCommon.IsConnect())
            {
                MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Không kết nối được", "Thông báo", MessageBoxButtons.OK);
        }

        private void txtIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConnect.PerformClick();
        }
    }
}
