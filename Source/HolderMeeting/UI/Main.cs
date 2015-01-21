using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;
using UI.Common;

namespace UI
{
    public partial class Main : Form
    {
        private readonly List<Form> _childForms;
        private Socket _socket;
        private IPEndPoint _iep;
        private byte[] _data;
        private string _formActive = string.Empty;

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

        XtraMdiTabPage FindPageByText(string pageText)
        {
            foreach (XtraMdiTabPage page in mdiParentManager.Pages)
            {
                if (page.Text == pageText)
                    return page;
            }
            return null;
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

        private void mniConnect_Click_1(object sender, EventArgs e)
        {
            var frm = new frmConnect();
            var result = frm.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    frm.Dispose();
                    mniSend.Visible = mniHolder.Visible =
                        mniVote.Visible = mniHolderVote.Visible = mniReport.Visible = mniAbout.Visible = true;
                    mnMain.Visible = true;

                    break;

                case DialogResult.Cancel:
                    frm.Dispose();

                    break;
            }

        }

        private void mniSend_Click(object sender, EventArgs e)
        {
            try
            {
                _socket.SendTo(_data, _iep);
            }
            catch { }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _iep = new IPEndPoint(IPAddress.Broadcast, 9050);
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            _data = Encoding.ASCII.GetBytes(MyConstant.Config.KeyWordConnect);
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

        private void mdiParentManager_PageRemoved(object sender, MdiTabPageEventArgs e)
        {
            foreach (var childForm in _childForms)
            {
                var aBc = FindPageByText(childForm.Text);
                if (aBc == null)
                {
                    _childForms.Remove(_childForms.Single(t => t.Name == childForm.Name));
                    break;
                }
            }
        }

        #endregion

    }
}
