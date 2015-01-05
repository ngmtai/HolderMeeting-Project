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

namespace UI
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoConstant.Config.ConnectionString))
            {
                MessageBox.Show("Chưa kết nối máy chủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            var cb = new CompanyBusiness();
            var detail = cb.Detail();

            if (detail != null)
                lbl.Text = "Tên công ty: " + detail.DisplayName.ToUpper() + "\nSố cổ phiếu đang lưu hành: " +
                    string.Format("{0:#,###}", detail.TotalShare.HasValue ? detail.TotalShare.Value : 0);
        }
    }
}
