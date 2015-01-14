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
using UI.Common;

namespace UI
{
    public partial class TcpChat : Form
    {
        #region Variables

        private static Socket _client;
        private static byte[] _data = new byte[1024];

        #endregion

        public TcpChat()
        {
            InitializeComponent();
            txtMsg.Focus();
        }

        #region function

        void ReceiveData()
        {
            while (true)
            {
                var recv = _client.Receive(_data);
                var data = Encoding.ASCII.GetString(_data, 0, recv);
                if (data.Equals(MyConstant.Config.KeyWord))
                {
                    lstResult.Items.Add(data);
                    break;
                }
            }
            _client.Close();
        }

        void AcceptConn(IAsyncResult iar)
        {
            var oldServer = (Socket)iar.AsyncState;
            _client = oldServer.EndAccept(iar);
            lstResult.Items.Add("Connected from: " + _client.RemoteEndPoint);
            var receiver = new Thread(new ThreadStart(ReceiveData));
            receiver.Start();
        }

        void Connected(IAsyncResult iar)
        {
            try
            {
                _client.EndConnect(iar);
                lstResult.Items.Add("Connected to: " + _client.RemoteEndPoint);
                var receiver = new Thread(new ThreadStart(ReceiveData));
                receiver.Start();
            }
            catch { }
        }

        void SendData(IAsyncResult iar)
        {
            var socket = (Socket)iar.AsyncState;
            var send = socket.EndSend(iar);
        }

        #endregion

        #region protected

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                lstResult.Items.Add("Connecting...");
                _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ipe = new IPEndPoint(IPAddress.Parse(string.IsNullOrEmpty(MyConstant.Config.IpAddress) ? "192.168.1.2" : MyConstant.Config.IpAddress.Trim()), 9050);
                _client.BeginConnect(ipe, new AsyncCallback(Connected), _client);
            }
            catch { }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            var newSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                var ipA = (Dns.GetHostByName(Dns.GetHostName())).AddressList;
                var ipAddress = ipA.Any() ? ipA[0] : IPAddress.Any;

                var ipe = new IPEndPoint(IPAddress.Any, 9050);
                newSock.Bind(ipe);
                newSock.Listen(5);
                newSock.BeginAccept(new AsyncCallback(AcceptConn), newSock);

            }
            catch { newSock.Dispose(); }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var message = Encoding.ASCII.GetBytes(txtMsg.Text.Trim());
                txtMsg.Text = "";
                _client.BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendData), _client);
            }
            catch { }
        }

        #endregion
    }
}
