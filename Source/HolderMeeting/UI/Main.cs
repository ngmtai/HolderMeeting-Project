using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Main : Form
    {
        private readonly List<Form> _childForms;

        public Main()
        {
            _childForms = new List<Form>();
            InitializeComponent();
        }

        #region function

        private void AddChildMdi<T>() where T : Form
        {
            // Open new form if there is no same form
            // otherwise, active form
            var type = typeof(T);
            var instance = (T)Activator.CreateInstance(type);
            var form = instance as Form;

            if (_childForms.Exists(x => x.Name == form.Name))
            {
                var childForm = _childForms.Find(x => x.Name == form.Name);
                childForm.Activate();
            }
            else
            {
                form.MdiParent = this;
                _childForms.Add(form);
                form.Show();
            }
        }

        void LoadHolder()
        {

        }

        void LoadVote()
        {

        }

        void LoadHolderVote()
        {

        }

        #endregion

        #region event

        private void mniConnect_Click(object sender, EventArgs e)
        {
            var frm = new frmConnect();
            var result = frm.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    frm.Dispose();
                    mniHolder.Visible =
                        mniVote.Visible = mniHolderVote.Visible = mniReport.Visible = mniAbout.Visible = true;
                    mnMain.Visible = true;

                    break;

                case DialogResult.Cancel:
                    frm.Dispose();

                    break;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void mniImport_Click(object sender, EventArgs e)
        {
            var frm = new ImportHolder();
            var result = frm.ShowDialog();
            if (result == DialogResult.Cancel)
                frm.Dispose();
        }

        private void mniList_Click(object sender, EventArgs e)
        {
            AddChildMdi<frmHolder>();
        }

        private void mniVote_Click(object sender, EventArgs e)
        {
            AddChildMdi<frmVote>();
        }

        private void mniHolderVote_Click(object sender, EventArgs e)
        {
            AddChildMdi<frmHolder_Vote>();
        }

        private void mniAbout_Click(object sender, EventArgs e)
        {
            var frm = new frmAbout();
            var result = frm.ShowDialog();
            if (result == DialogResult.Cancel)
                frm.Dispose();
        }

        private void mniPercentHolder_Click(object sender, EventArgs e)
        {
            var frm = (ReportCondition)Application.OpenForms["ReportCondition"];
            if (frm != null)
                frm.Activate();
            else
            {
                frm = new ReportCondition();
                frm.Show();
            }
        }

        private void mniPercentVote_Click(object sender, EventArgs e)
        {
            var frm = (ReportVote)Application.OpenForms["ReportVote"];
            if (frm != null)
                frm.Activate();
            else
            {
                frm = new ReportVote();
                frm.Show();
            }
        }

        #endregion

    }
}
