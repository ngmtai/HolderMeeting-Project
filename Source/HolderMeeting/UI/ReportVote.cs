using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using BLL.Model;
using DevExpress.Data.PLinq.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using UI.Common;

namespace UI
{
    public partial class ReportVote : Form
    {
        public ReportVote()
        {
            InitializeComponent();
            panelControl1.AutoScroll = true;
            CheckForIllegalCrossThreadCalls = false;
        }

        #region variables

        private Thread _thread;
        private Socket _socket;
        private int _voteId1 = 0, _voteId2 = 0, _voteId3 = 0, _voteId4 = 0;

        #endregion

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

            lblTitle.Text = "Tổng số lượng cổ phiếu tham gia đại hội: " + string.Format("{0:#,###}", totalShare);

            if (totalShare > 0)
            {
                var vb = new VoteBusiness();
                var votes = vb.GetAlls(true);
                pn1.Visible = pn2.Visible = pn3.Visible = pn4.Visible = false;

                if (votes.Any())
                    for (var i = 0; i < votes.Count; i++)
                    {
                        var totalShareOfVote = hv.TotalShareByVote(votes[i].Id);

                        decimal totalYes;
                        decimal totalNo;
                        decimal totalOther;
                        switch (i)
                        {
                            case 0:

                                _voteId1 = votes[i].Id;

                                #region Biểu quyết 1

                                gb1.Text = string.Format("Biểu quyết {0}: {1} - Tổng số cổ phiếu biểu quyết: {2} - Tỉ lệ: {3}%", (i + 1), votes[i].DisplayName, totalShareOfVote > 0 ? string.Format("{0:#,###}", totalShareOfVote) : "0", Math.Round((totalShareOfVote / totalShare) * 100, 2));
                                pn1.Visible = true;

                                if (totalShareOfVote > 0)
                                {
                                    totalYes = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Yes, votes[i].Id);
                                    totalNo = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.No, votes[i].Id);
                                    totalOther = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Other, votes[i].Id);

                                    lblYes1.Text = string.Format("{0:#,###}", totalYes);
                                    lblNo1.Text = string.Format("{0:#,###}", totalNo);
                                    lblOther1.Text = string.Format("{0:#,###}", totalOther);

                                    lblYesPercent1.Text = Math.Round((totalYes / totalShareOfVote) * 100, 2) + "%";
                                    lblNoPercent1.Text = Math.Round((totalNo / totalShareOfVote) * 100, 2) + "%";
                                    lblOtherPercent1.Text = Math.Round((totalOther / totalShareOfVote) * 100, 2) + "%";

                                    lblOtherText1.Text = LoadOtherText(int.Parse(cbo1.Text), votes[i].Id);
                                }
                                else
                                {
                                    lblYesPercent1.Text = "0%";
                                    lblNoPercent1.Text = "0%";
                                    lblOtherPercent1.Text = "0%";
                                }

                                #endregion

                                break;

                            case 1:

                                _voteId2 = votes[i].Id;

                                #region Biểu quyết 2

                                gb2.Text = string.Format("Biểu quyết {0}: {1} - Tổng số cổ phiếu biểu quyết: {2} - Tỉ lệ: {3}%", (i + 1), votes[i].DisplayName, totalShareOfVote > 0 ? string.Format("{0:#,###}", totalShareOfVote) : "0", Math.Round((totalShareOfVote / totalShare) * 100, 2));
                                pn2.Visible = true;

                                if (totalShareOfVote > 0)
                                {
                                    totalYes = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Yes, votes[i].Id);
                                    totalNo = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.No, votes[i].Id);
                                    totalOther = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Other, votes[i].Id);

                                    lblYes2.Text = string.Format("{0:#,###}", totalYes);
                                    lblNo2.Text = string.Format("{0:#,###}", totalNo);
                                    lblOther2.Text = string.Format("{0:#,###}", totalOther);

                                    lblYesPercent2.Text = Math.Round((totalYes / totalShareOfVote) * 100, 2) + "%";
                                    lblNoPercent2.Text = Math.Round((totalNo / totalShareOfVote) * 100, 2) + "%";
                                    lblOtherPercent2.Text = Math.Round((totalOther / totalShareOfVote) * 100, 2) + "%";

                                    lblOtherText2.Text = LoadOtherText(int.Parse(cbo2.Text), votes[i].Id);
                                }
                                else
                                {
                                    lblYesPercent2.Text = "0%";
                                    lblNoPercent2.Text = "0%";
                                    lblOtherPercent2.Text = "0%";
                                }

                                #endregion

                                break;

                            case 2:

                                _voteId3 = votes[i].Id;

                                #region Biểu quyết 3

                                gb3.Text = string.Format("Biểu quyết {0}: {1} - Tổng số cổ phiếu biểu quyết: {2} - Tỉ lệ: {3}%", (i + 1), votes[i].DisplayName, totalShareOfVote > 0 ? string.Format("{0:#,###}", totalShareOfVote) : "0", Math.Round((totalShareOfVote / totalShare) * 100, 2));
                                pn3.Visible = true;

                                if (totalShareOfVote > 0)
                                {
                                    totalYes = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Yes, votes[i].Id);
                                    totalNo = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.No, votes[i].Id);
                                    totalOther = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Other, votes[i].Id);

                                    lblYes3.Text = string.Format("{0:#,###}", totalYes);
                                    lblNo3.Text = string.Format("{0:#,###}", totalNo);
                                    lblOther3.Text = string.Format("{0:#,###}", totalOther);

                                    lblYesPercent3.Text = Math.Round((totalYes / totalShareOfVote) * 100, 2) + "%";
                                    lblNoPercent3.Text = Math.Round((totalNo / totalShareOfVote) * 100, 2) + "%";
                                    lblOtherPercent3.Text = Math.Round((totalOther / totalShareOfVote) * 100, 2) + "%";

                                    lblOtherText3.Text = LoadOtherText(int.Parse(cbo3.Text), votes[i].Id);
                                }
                                else
                                {
                                    lblYesPercent3.Text = "0%";
                                    lblNoPercent3.Text = "0%";
                                    lblOtherPercent3.Text = "0%";
                                }

                                #endregion

                                break;

                            case 3:

                                _voteId4 = votes[i].Id;

                                #region Biểu quyết 4

                                gb4.Text = string.Format("Biểu quyết {0}: {1} - Tổng số cổ phiếu biểu quyết: {2} - Tỉ lệ: {3}%", (i + 1), votes[i].DisplayName, totalShareOfVote > 0 ? string.Format("{0:#,###}", totalShareOfVote) : "0", Math.Round((totalShareOfVote / totalShare) * 100, 2));
                                pn4.Visible = true;

                                if (totalShareOfVote > 0)
                                {
                                    totalYes = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Yes, votes[i].Id);
                                    totalNo = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.No, votes[i].Id);
                                    totalOther = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Other, votes[i].Id);

                                    lblYes4.Text = string.Format("{0:#,###}", totalYes);
                                    lblNo4.Text = string.Format("{0:#,###}", totalNo);
                                    lblOther4.Text = string.Format("{0:#,###}", totalOther);

                                    lblYesPercent4.Text = Math.Round((totalYes / totalShareOfVote) * 100, 2) + "%";
                                    lblNoPercent4.Text = Math.Round((totalNo / totalShareOfVote) * 100, 2) + "%";
                                    lblOtherPercent4.Text = Math.Round((totalOther / totalShareOfVote) * 100, 2) + "%";

                                    lblOtherText4.Text = LoadOtherText(int.Parse(cbo4.Text), votes[i].Id);
                                }
                                else
                                {
                                    lblYesPercent4.Text = "0%";
                                    lblNoPercent4.Text = "0%";
                                    lblOtherPercent4.Text = "0%";
                                }

                                #endregion

                                break;
                        }
                    }
            }
        }

        string LoadOtherText(int item, int voteId)
        {
            var tmp = string.Empty;
            var hv = new HolderVoteBusiness();
            var aBc = hv.GetTopAnswerName(item, (int)MyConstant.AnswerType.Other, voteId);
            if (aBc.Any())
                foreach (var value in aBc)
                    tmp += string.Format("- {0} - Số cổ phiếu: {1:#,###}\n", value.Item1, value.Item2);
            else
                tmp = "Không có ý kiến khác";

            return tmp;
        }

        #endregion

        #region event

        private void ReportVote_Load(object sender, EventArgs e)
        {
            LoadData();

            _thread = new Thread(new ThreadStart(ReceiveMsg));
            _thread.Start();
        }

        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOtherText1.Text = LoadOtherText(int.Parse(cbo1.Text), _voteId1);
        }

        private void cbo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOtherText2.Text = LoadOtherText(int.Parse(cbo2.Text), _voteId2);
        }

        private void cbo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOtherText3.Text = LoadOtherText(int.Parse(cbo3.Text), _voteId3);
        }

        private void cbo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOtherText4.Text = LoadOtherText(int.Parse(cbo4.Text), _voteId4);
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

        private void btnView_Click(object sender, EventArgs e)
        {
            var report = new ReportWizard();

            #region Source

            var listDataSource = new ArrayList();
            var hb = new HolderBusiness();
            var hv = new HolderVoteBusiness();

            var totalShare = hb.TotalShareIsConfirm(true);

            if (totalShare > 0)
            {
                var vb = new VoteBusiness();
                var votes = vb.GetAlls(true);

                if (votes.Any())
                    for (var i = 0; i < votes.Count; i++)
                    {
                        var reportDto = new ReportDto();
                        var totalShareOfVote = hv.TotalShareByVote(votes[i].Id);

                        reportDto.Title = "Tổng số lượng cổ phiếu tham gia đại hội: " + string.Format("{0:#,###}", totalShare);
                        reportDto.VoteName = string.Format("Biểu quyết {0}: {1} - Tổng số cổ phiếu biểu quyết: {2} - Tỉ lệ: {3}%", (i + 1), votes[i].DisplayName, totalShareOfVote > 0 ? string.Format("{0:#,###}", totalShareOfVote) : "0", Math.Round((totalShareOfVote / totalShare) * 100, 2));

                        if (totalShareOfVote > 0)
                        {
                            var totalYes = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Yes, votes[i].Id);
                            var totalNo = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.No, votes[i].Id);
                            var totalOther = hv.TotalSharedByAnswerType((int)MyConstant.AnswerType.Other,
                                votes[i].Id);

                            reportDto.TotalYes = string.Format("{0:#,###}", totalYes);
                            reportDto.TotalNo = string.Format("{0:#,###}", totalNo);
                            reportDto.TotalOther = string.Format("{0:#,###}", totalOther);

                            reportDto.TotalYesPercent = Math.Round((totalYes / totalShareOfVote) * 100, 2) + "%";
                            reportDto.TotalNoPercent = Math.Round((totalNo / totalShareOfVote) * 100, 2) + "%";
                            reportDto.TotalOtherPercent = Math.Round((totalOther / totalShareOfVote) * 100, 2) + "%";

                            switch (i)
                            {
                                case 0:
                                    reportDto.OtherText = LoadOtherText(int.Parse(cbo1.Text), votes[i].Id);
                                    break;

                                case 1:
                                    reportDto.OtherText = LoadOtherText(int.Parse(cbo2.Text), votes[i].Id);
                                    break;

                                case 2:
                                    reportDto.OtherText = LoadOtherText(int.Parse(cbo3.Text), votes[i].Id);
                                    break;

                                case 3:
                                    reportDto.OtherText = LoadOtherText(int.Parse(cbo4.Text), votes[i].Id);
                                    break;
                            }

                        }
                        else
                        {
                            reportDto.TotalYesPercent = "0%";
                            reportDto.TotalNoPercent = "0%";
                            reportDto.TotalOtherPercent = "0%";
                        }

                        listDataSource.Add(reportDto);
                    }
            }

            // Populate the list with records. 

            #endregion

            report.DataSource = listDataSource;
            for (var i = 0; i < listDataSource.Count; i++)
                report.DataBind("Title","VoteName", "TotalYes", "TotalYesPercent", "TotalNo", "TotalNoPercent", "TotalOther", "TotalOtherPercent", "OtherText");

            var tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var report = new ReportWizard();
            var tool = new ReportPrintTool(report);
            tool.Print();
        }
    }
}
