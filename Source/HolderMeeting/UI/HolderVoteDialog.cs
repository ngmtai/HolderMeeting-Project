using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using UI.Common;
using UI.Component;

namespace UI
{
    public partial class HolderVoteDialog : Form
    {
        public HolderVoteDialog()
        {
            InitializeComponent();
        }

        #region variables

        public int HolderId;
        private decimal _currentShared = 0;
        private decimal _totalShared = 0;
        private int _loY;

        #endregion

        #region function

        void LoadDetail(int holderId)
        {
            var hb = new HolderBusiness();
            var detail = hb.Detail(holderId);

            if (detail != null && detail.Id > 0)
            {
                lblCode.Text = detail.Code;
                lblName.Text = detail.Name;
                lblAuthorizer.Text = detail.AuthorizerName;
                lblTotalShared.Text = detail.TotalShare.HasValue ? detail.TotalShare.Value > 0 ? string.Format("{0:#,###}", detail.TotalShare.Value) : "0" : "0";
                if (detail.TotalShare != null)
                {
                    _totalShared = detail.TotalShare.Value;

                    var hvb = new HolderVoteBusiness();
                    var shareIsVote = hvb.TotalSharedIsVote(detail.Id);

                    _currentShared = detail.TotalShare.Value - shareIsVote;
                }
                lblCurrentShared.Text = _currentShared > 0 ? string.Format("{0:#,###}", _currentShared) : "0";
            }
        }

        void RenderVote(int index, int voteId, string voteName)
        {
            var tabIndex = index*5;
            if (_loY <= 0)
                _loY = 45;
            const int loX = 10;
            var loY = _loY;

            var lblVote = new LabelControl
            {
                Location = new Point(loX, loY),
                Size = new Size(44, 13),
                Text = index + ". " + voteName
            };

            var groupBox = new GroupBox();
            var radYes = new RadioButton();
            var radNo = new RadioButton();
            var radOther = new RadioButton();

            radYes.AutoSize = true;
            radYes.Location = new Point(loX + 30, 20);
            radYes.Name = "rad" + voteId + "Yes";
            radYes.Size = new Size(85, 17);
            radYes.TabStop = true;
            radYes.Text = "Đồng ý";
            radYes.UseVisualStyleBackColor = true;
            radYes.CheckedChanged += rad_CheckedChanged;
            radYes.TabIndex = tabIndex;
            tabIndex += 1;

            radNo.AutoSize = true;
            radNo.Location = new Point(loX + 100, 20);
            radNo.Name = "rad" + voteId + "No";
            radNo.Size = new Size(85, 17);
            radNo.TabStop = true;
            radNo.Text = "Không đồng ý";
            radNo.UseVisualStyleBackColor = true;
            radNo.CheckedChanged += rad_CheckedChanged;
            radNo.TabIndex = tabIndex;
            tabIndex += 1;

            radOther.AutoSize = true;
            radOther.Location = new Point(loX + 200, 20);
            radOther.Name = "rad" + voteId + "Other";
            radOther.Size = new Size(85, 17);
            radOther.TabStop = true;
            radOther.Text = "Ý kiến khác";
            radOther.UseVisualStyleBackColor = true;
            radOther.CheckedChanged += radOther_CheckedChanged;
            radOther.TabIndex = tabIndex;
            tabIndex += 1;

            var txt = new TextBox
            {
                Location = new Point(loX + 300, 20),
                Name = "txt" + voteId + "Other",
                Size = new Size(250, 20),
                TabIndex = tabIndex,
                Enabled = false
            };
            tabIndex += 1;

            groupBox.Controls.Add(radYes);
            groupBox.Controls.Add(radNo);
            groupBox.Controls.Add(radOther);
            groupBox.Controls.Add(txt);
            groupBox.Location = new Point(loX + 30, loY + 20);
            groupBox.Name = "gb" + voteId;
            groupBox.Size = new Size(600, 60);
            groupBox.TabStop = false;
            groupBox.Text = "";

            var labelControl = new LabelControl
            {
                Location = new Point(loX + 30, loY + groupBox.Size.Height + 40),
                Size = new Size(113, 13),
                Text = "Số cổ phiếu biểu quyết:"
            };

            var numericTextBox = new NumericTextBox()
            {
                Location = new Point(loX + 160, loY + groupBox.Size.Height + 40),
                Name = "num" + voteId,
                Size = new Size(90, 20),
                TabIndex = tabIndex,
                TextAlign = HorizontalAlignment.Right
            };

            numericTextBox.Leave += numericTextBox_Leave;

            _loY = numericTextBox.Location.Y + 30;

            var hvb = new HolderVoteBusiness();
            var aBc = hvb.GetByVoteId(HolderId, voteId);
            if (aBc != null)
            {
                if (aBc.TotalShare != null) numericTextBox.Text = string.Format("{0:#,###}", aBc.TotalShare.Value);
                switch (aBc.AnswerType)
                {
                    case (int)MyConstant.AnswerType.Yes:
                        radYes.Checked = true;
                        break;

                    case (int)MyConstant.AnswerType.No:
                        radNo.Checked = true;
                        break;

                    case (int)MyConstant.AnswerType.Other:
                        radOther.Checked = true;
                        txt.Enabled = true;
                        txt.Text = aBc.AnswerName;
                        break;
                }
            }

            gcVote.Controls.Add(lblVote);
            gcVote.Controls.Add(groupBox);
            gcVote.Controls.Add(numericTextBox);
            gcVote.Controls.Add(labelControl);
        }

        #endregion

        #region event

        private void HolderVoteDialog_Load(object sender, EventArgs e)
        {
            LoadDetail(HolderId);
            var vb = new VoteBusiness();
            var votes = vb.GetAlls(true);
            if (votes.Any())
                for (var i = 0; i < votes.Count; i++)
                    RenderVote(i + 1, votes[i].Id, votes[i].DisplayName);
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            var lstHolderVote = new List<Holder_Vote>();
            var vb = new VoteBusiness();
            var votes = vb.GetAlls(true);
            var msg = string.Empty;
            decimal shared = 0;

            if (votes.Any())
                for (var i = 0; i < votes.Count; i++)
                {
                    var blAnswer = false;
                    var holderVote = new Holder_Vote();
                    var radYes = (RadioButton)Controls.Find("rad" + votes[i].Id + "Yes", true)[0];
                    if (radYes.Checked)
                    {
                        holderVote.AnswerType = (int)MyConstant.AnswerType.Yes;
                        holderVote.AnswerName = "Đồng ý";
                        blAnswer = true;
                    }
                    else
                    {
                        var radNo = (RadioButton)Controls.Find("rad" + votes[i].Id + "No", true)[0];
                        if (radNo.Checked)
                        {
                            holderVote.AnswerType = (int)MyConstant.AnswerType.No;
                            holderVote.AnswerName = "Không đồng ý";
                            blAnswer = true;
                        }
                        else
                        {
                            var radOther = (RadioButton)Controls.Find("rad" + votes[i].Id + "Other", true)[0];
                            if (radOther.Checked)
                            {
                                holderVote.AnswerType = (int)MyConstant.AnswerType.Other;
                                var txt = (TextBox)Controls.Find("txt" + votes[i].Id + "Other", true)[0];
                                if (string.IsNullOrEmpty(txt.Text))
                                    msg += "\nBiểu quyết " + (i + 1) + ":\n - Phải nhập ý kiến khác.";
                                else
                                {
                                    holderVote.AnswerName = txt.Text.Trim();
                                    blAnswer = true;
                                }
                            }
                        }
                    }

                    if (holderVote.AnswerType.HasValue && blAnswer)
                    {
                        var numericTextBox = (NumericTextBox)Controls.Find("num" + votes[i].Id, true)[0];
                        var totalShare = numericTextBox.Text.Replace(",", "");
                        if (string.IsNullOrEmpty(totalShare.Trim()))
                            totalShare = "0";
                        holderVote.TotalShare = decimal.Parse(totalShare.Trim());

                        shared += holderVote.TotalShare.Value;

                        if (shared <= _totalShared)
                        {
                            holderVote.VoteId = votes[i].Id;
                            holderVote.IsActive = true;
                            holderVote.CreateDate = DateTime.Now;
                            holderVote.HolderId = HolderId;

                            lstHolderVote.Add(holderVote);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng cổ phiếu vượt quá số lượng cổ phiếu hiện có", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var hvb = new HolderVoteBusiness();
            if (hvb.Saves(lstHolderVote))
            {
                MessageBox.Show("Biểu quyết thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Lỗi, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void rad_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var rad = (RadioButton)sender;
                var txt = (TextBox)Controls.Find(rad.Name.Replace("rad", "txt").Replace("Yes", "Other").Replace("No", "Other"), true)[0];

                txt.Enabled = false;
                txt.Text = string.Empty;
            }
            catch { }
        }

        void radOther_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var rad = (RadioButton)sender;
                var txt = (TextBox)Controls.Find(rad.Name.Replace("rad", "txt"), true)[0];

                txt.Enabled = true;
                txt.Focus();
            }
            catch { }
        }

        void numericTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var vb = new VoteBusiness();
                var votes = vb.GetAlls(true);

                decimal shared = 0;

                if (votes.Any())
                    for (var i = 0; i < votes.Count; i++)
                    {
                        var numericTextBox = (NumericTextBox)Controls.Find("num" + votes[i].Id, true)[0];
                        var totalShare = numericTextBox.Text.Replace(",", "");
                        if (!string.IsNullOrEmpty(totalShare.Trim()))
                            shared += decimal.Parse(totalShare);
                    }

                //lblCurrentShared.Text = string.Format("{0:#,###}", _currentShared > shared ? _currentShared - shared : 0);
                lblCurrentShared.Text = string.Format("{0:#,###}", _totalShared > shared ? _totalShared - shared : 0);
            }
            catch { }
        }

        #endregion
    }
}
