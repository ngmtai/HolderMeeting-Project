using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class BroadcastSend : Form
    {
        private Socket _socket;

        public BroadcastSend()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                var iep = new IPEndPoint(IPAddress.Broadcast, 9050);

                var hostname = Dns.GetHostName();
                var str = string.Format("Send from: {0}\nNội dung: {1}", hostname, textEdit1.Text);
                var data = Encoding.ASCII.GetBytes(str);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

                _socket.SendTo(data, iep);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send - btnSend_Click: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void BroadcastSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _socket.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send - FormClosing: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
