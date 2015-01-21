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
using BLL.Common;
using UI.Common;

namespace UI
{
    public partial class frmConnect : Form
    {
        private Thread _thread;
        private Socket _socket;

        public frmConnect()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            BoConstant.Config.ConnectionString = string.Empty;

            if (string.IsNullOrEmpty(txtIp.Text.Trim()))
            {
                MessageBox.Show("Phải nhập đỉa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIp.Focus();
                return;
            }

            string tmp;

            if (!string.IsNullOrEmpty(txtUser.Text.Trim()) && !string.IsNullOrEmpty(txtPass.Text.Trim()))
                tmp = string.Format(BoConstant.Config.ConnectionTemp, txtIp.Text,
                    string.Format(BoConstant.Config.ConnectionAuthorize, txtUser.Text.Trim(), txtPass.Text.Trim()));
            else
                tmp = string.Format(BoConstant.Config.ConnectionTemp, txtIp.Text,
                    BoConstant.Config.ConnectionNonAuthor);
            BoConstant.Config.ConnectionString = tmp;

            try
            {
                MyConstant.Config.IpAddress = IPAddress.Parse(txtIp.Text.Trim()).ToString();
            }
            catch { }

            if (BoCommon.IsConnect())
            {
                MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Không kết nối được", "Thông báo", MessageBoxButtons.OK);
        }

        private void txtIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConnect.PerformClick();
        }

        private void btnGetIp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_thread == null)
                    _thread = new Thread(new ThreadStart(ReceiveMsg));
                else
                {
                    try
                    {
                        _thread.Abort();
                    }
                    catch { }

                    _thread = new Thread(new ThreadStart(ReceiveMsg));
                }

                _thread.Start();
            }
            catch { }
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
                    if (strData.Trim().Equals(MyConstant.Config.KeyWordConnect))
                    {
                        var tmp = ep.ToString();
                        txtIp.Text = tmp.Substring(0, tmp.IndexOf(":"));
                        break;
                    }
                }
                _socket.Close();
                _socket.Dispose();
            }
            catch { }
        }
    }
}
