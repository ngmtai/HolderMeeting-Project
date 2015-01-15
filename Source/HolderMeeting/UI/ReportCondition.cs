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
using System.Threading;
using System.Windows.Forms;
using BLL;
using BLL.Common;
using UI.Common;

namespace UI
{
    public partial class ReportCondition : Form
    {
        private Thread _thread;
        private Socket _socket;

        public ReportCondition()
        {
            InitializeComponent();
        }

        #region function

        public void RefreshForm(string shared, string percent)
        {
            lblShared.Text = shared;
            lblPercent.Text = percent;
        }

        void ReceiveMsg()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                var iep = new IPEndPoint(IPAddress.Any, 9050);
                _socket.Bind(iep);
                var ep = (EndPoint)iep;
                while (true)
                {
                    var data = new byte[1024];
                    var recv = _socket.ReceiveFrom(data, ref ep);
                    var strData = Encoding.ASCII.GetString(data, 0, recv);
                    if (strData.Trim().Equals(MyConstant.Config.KeyWord))
                        LoadForm();
                }
            }
            catch { }
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

        #endregion

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

            _thread = new Thread(new ThreadStart(ReceiveMsg));
            _thread.Start();
        }
    }
}
