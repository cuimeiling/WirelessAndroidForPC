using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WireLessPC
{
    class CommandExecutorThread
    {
        #region Variables Defined
        private Socket socket = null;
        Thread receivThread = null;
        WireLessPC.ReceiveSender handleScript = null;
        mainform mainformc = null;
        #endregion

        #region Constructor with Ip Address and corresponding port
        public CommandExecutorThread(String ip, int port, Object form)
        {
            this.mainformc = form as mainform;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(ip);
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, port);
            socket.Bind(ipendpoint);
            socket.Listen(GlobalConstants.MAXLISTENSOCKETS);
        }
        #endregion

        #region Start a new Thread to handle message received from the end socket
        public void Handle()
        {
            while (socket != null && socket.IsBound)
            {
                Socket executorSocket = socket.Accept();
                this.mainformc.showmessage(executorSocket.RemoteEndPoint.ToString());
                this.mainformc.changeIco(new System.Drawing.Bitmap(Properties.Resources.bot));
                receivThread = new Thread(new ThreadStart((handleScript = new WireLessPC.ReceiveSender(executorSocket, this.mainformc)).receiveMessage));
                receivThread.Start();
            }
        }
        #endregion

        #region Function for destorying class and release all the resource
        public void Abort()
        {
            if (this.socket != null)
            {
                if (this.socket.Connected)
                {
                    this.socket.Disconnect(true);
                    this.socket = null;
                }
                else
                {
                    this.socket.Dispose();
                    this.socket = null;
                }
            }
            if (this.receivThread != null)
            {
                this.receivThread.Abort();
                if (this.handleScript != null)
                {
                    this.handleScript.Abort();
                }
                this.handleScript = null;
            }
        }
        #endregion
    }
}
