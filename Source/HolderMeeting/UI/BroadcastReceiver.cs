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

namespace UI
{
    public partial class BroadcastReceiver : Form
    {
        private Thread _thread;
        private Socket _socket;

        public BroadcastReceiver()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void BroadcastReceiver_Load(object sender, EventArgs e)
        {
            _thread = new Thread(new ThreadStart(ReceiveMsg));
            _thread.Start();
        }

        void ReceiveMsg()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                var iep = new IPEndPoint(IPAddress.Any, 9050);
                _socket.Bind(iep);
                var ep = (EndPoint)iep;
                lbl.Text = "Ready to receive...";
                while (true)
                {
                    var data = new byte[1024];
                    var recv = _socket.ReceiveFrom(data, ref ep);
                    var strData = Encoding.ASCII.GetString(data, 0, recv);
                    var tmp = "\n" + strData + " from " + ep;
                    lbl.Text += tmp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive - ReceiveMsg(): " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void BroadcastReceiver_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _socket.Dispose();
                _thread.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive - FormClosing: " + ex.Message, "Error", MessageBoxButtons.OK);
                Dispose();
            }
        }
    }
}
