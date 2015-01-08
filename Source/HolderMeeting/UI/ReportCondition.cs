using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class ReportCondition : Form
    {
        public ReportCondition()
        {
            InitializeComponent();
        }

        public void LoadForm()
        {
            var cb = new CompanyBusiness();
            var hb = new HolderBusiness();

            var detail = cb.Detail();
            var totalShareConfirm = hb.TotalShareIsConfirm(true);

            lblCompany.Text = detail.DisplayName.ToUpper();
            lblTotalShared.Text = "Tổng số cổ phiếu đang lưu hành : " +
                                  string.Format("{0:#,###}", detail.TotalShare.Value);
            lblShared.Text = "Tổng số cổ phiếu tham gia đại hội: " + string.Format("{0:#,###}", totalShareConfirm);
            lblPercent.Text = "Đạt tỉ lệ: " + Math.Round((decimal)(totalShareConfirm / detail.TotalShare.Value) * 100) +
                              "%";
        }

        private void ReportCondition_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
