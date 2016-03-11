using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;

namespace WireLessPC
{
    class ReceiveSender
    {
        #region Variables Defined
        private Socket _socket = null;
        private mainform form = null;
        #endregion

        #region Constructor with parameter socket
        public ReceiveSender(Socket socket, Object form)
        {
            this._socket = socket;
            this.form = form as mainform;
        }
        #endregion

        #region Function for Receiving Messages from socket and executing commands
        public void receiveMessage()
        {
            if (this._socket != null)
            {
                _socket.ReceiveBufferSize = 256;
               
                byte[] mobile = new byte[512];
                _socket.Receive(mobile);
                String mobileStr = System.Text.Encoding.UTF8.GetString(mobile);
                if (mobileStr.IndexOf("\0") >= 0)
                {
                    mobileStr = mobileStr.Substring(0, mobileStr.IndexOf("\0"));
                }
                this.form.showmessage(mobileStr + " " +  _socket.RemoteEndPoint.ToString());
                while (true && _socket.Connected)
                {
                    try
                    {
                        byte[] received = new byte[1024];
                        try
                        {
                            _socket.Receive(received);
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e.Message.ToString());
                            this.form.showmessage("断开连接从"+_socket.RemoteEndPoint.ToString());
                            this.form.changeIco(Properties.Resources.pause);
                        }
                        string cmd = null;
                        System.Console.WriteLine((new DateTime()).Second.ToString());
                        cmd = System.Text.Encoding.UTF8.GetString(received,0,received.Length).Trim();
                        cmd = cmd.Substring(2,20);
                        if (cmd != null)
                        {
                            
                            cmd = cmd.Substring(0, cmd.IndexOf("\0"));
                        }
                        if (cmd.IndexOf("|") > 0)
                        {
                            MousekeysUtility.processCommand(cmd);
                        }
                    }
                    catch (Exception ereceivemessage)
                    {
                        System.Console.WriteLine("ereceivemessage: " + ereceivemessage.Message.ToString());
                    }
                }
            }
        }
        #endregion

        #region Function for destorying class
        public void Abort()
        {
            if (this._socket != null)
            {
                if (this._socket.Connected)
                {
                    this._socket.Dispose();
                    this._socket = null;
                }
                else
                {
                    this._socket.Dispose();
                    this._socket = null;
                }
            }
        }
        #endregion
    }
}
