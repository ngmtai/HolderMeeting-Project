using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using UI.Common;

namespace UI
{
    public partial class ReportVote : Form
    {
        private Thread _thread;
        private Socket _socket;

        public ReportVote()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        #region function

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
                    if (strData.Trim().Equals(MyConstant.Config.KeyWordVote))
                        LoadData();
                }
            }
            catch { }
        }

        void LoadData()
        {
            var hb = new HolderBusiness();
            var hv = new HolderVoteBusiness();

            var totalShare = hb.TotalShareIsConfirm(true);

            lblTotal.Text = string.Format("{0:#,###}", totalShare);

            if (totalShare > 0)
            {
                var vb = new VoteBusiness();
                var votes = vb.GetAlls(true);
                if (votes.Any())
                    for (var i = 0; i < votes.Count; i++)
                    {
                        var totalYes = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Yes, votes[i].Id);
                        var totalNo = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.No, votes[i].Id);
                        var totalOther = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Other, votes[i].Id);

                        lblYes.Text = string.Format("{0:#,###}", totalYes);
                        lblNo.Text = string.Format("{0:#,###}", totalNo);
                        lblOther.Text = string.Format("{0:#,###}", totalOther);

                        lblYesPercent.Text = Math.Round((totalYes / totalShare) * 100, 2) + "%";
                        lblNoPercent.Text = Math.Round((totalNo / totalShare) * 100, 2) + "%";
                        lblOtherPercent.Text = Math.Round((totalOther / totalShare) * 100, 2) + "%";

                        LoadOtherText(int.Parse(cbo.Text), votes[i].Id);
                    }
            }
            else
            {
                lblYesPercent.Text = "0 %";
                lblNoPercent.Text = "0 %";
                lblOtherPercent.Text = "0 %";
            }
        }

        void LoadOtherText(int item, int voteId)
        {
            var hv = new HolderVoteBusiness();
            var aBc = hv.GetTopAnswerName(item, (int)MyConstant.AnswerType.Other, voteId);
            lblOtherText.Text = aBc.Any() ? string.Join("\n", aBc) : "Không có ý kiến khác";
        }

        #endregion

        #region event

        private void ReportVote_Load(object sender, EventArgs e)
        {
            LoadData();

            _thread = new Thread(new ThreadStart(ReceiveMsg));
            _thread.Start();
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadOtherText(int.Parse(cbo.Text));
        }

        private void ReportVote_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _socket.Dispose();
                if (_thread.ThreadState == ThreadState.Running)
                    _thread.Abort();
            }
            catch { }
        }

        #endregion

    }
}
