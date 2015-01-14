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
using UI.Common;

namespace UI
{
    public partial class ReportCondition : Form
    {
        public ReportCondition()
        {
            InitializeComponent();
        }

        public void RefreshForm(string shared, string percent)
        {
            lblShared.Text = shared;
            lblPercent.Text = percent;
        }

        void LoadForm()
        {
            var cb = new CompanyBusiness();
            var hb = new HolderBusiness();

            var detail = cb.Detail();
            var totalShareConfirm = hb.TotalShareIsConfirm(true);

            lblShared.Text = "Tổng số cổ phiếu tham gia đại hội: " + string.Format("{0:#,###}", totalShareConfirm);
            if (detail.TotalShare != null)
                lblPercent.Text = "Đạt tỉ lệ: " + Math.Round(totalShareConfirm / detail.TotalShare.Value * 100) + "%";
        }

        private void ReportCondition_Load(object sender, EventArgs e)
        {
            #region init

            var cb = new CompanyBusiness();
            var detail = cb.Detail();

            lblCompany.Text = detail.DisplayName.ToUpper();
            if (detail.TotalShare != null)
                lblTotalShared.Text = "Tổng số cổ phiếu đang lưu hành : " + string.Format("{0:#,###}", detail.TotalShare.Value);

            LoadForm();

            #endregion

        }
    }
}
