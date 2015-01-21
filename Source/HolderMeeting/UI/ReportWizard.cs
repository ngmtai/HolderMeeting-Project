using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using BLL;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using UI.Common;

namespace UI
{
    public partial class ReportWizard : XtraReport
    {
        public ReportWizard()
        {
            InitializeComponent();
        }

        public void DataBind(string title, string voteName, string yes, string yesPercent, string no, string noPercent, string other, string otherPercent, string otherText)
        {
            lblTitle.DataBindings.Add("Text", null, title);
            lblVoteName.DataBindings.Add("Text", null, voteName);
            lblYes.DataBindings.Add("Text", null, yes);
            lblYesPercent.DataBindings.Add("Text", null, yesPercent);
            lblNo.DataBindings.Add("Text", null, no);
            lblNoPercent.DataBindings.Add("Text", null, noPercent);
            lblOther.DataBindings.Add("Text", null, other);
            lblOtherPercent.DataBindings.Add("Text", null, otherPercent);
            lblOtherText.DataBindings.Add("Text", null, otherText);
        }

    }
}
