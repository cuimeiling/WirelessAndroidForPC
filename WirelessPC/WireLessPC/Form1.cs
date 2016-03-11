using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace WireLessPC
{
    public partial class mainform : Form
    {
        #region Variables Defined
        Boolean connected = false;
        private WireLessPC.CommandExecutorThread cmdthread = null;
        Thread threadExe = null;
        Thread threadSender = null;
        #endregion

        #region Constructor to initial UI
        public mainform()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Mainform_load to Initial IP and corresponding ports
        private void mainform_Load(object sender, EventArgs e)
        {
            loadIp();
            loadPort();
            this.bstop.Enabled = false;
        }
        #endregion

        #region Private Function for loading Ip address
        private void loadIp()
        {
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addressList = IpEntry.AddressList;
            if (addressList != null)
            {
                for (int i = 0; i < addressList.Length; i++)
                {
                    if (!addressList[i].IsIPv6LinkLocal && addressList[i] != null && addressList[i].ToString().Length > 0 && addressList[i].ToString().Length<=15)
                    {
                        ddip.Items.Add(addressList[i].ToString());
                    }
                }
            }
            ddip.Text = ddip.Items.Count > 0 ? GlobalConstants.SELECTADDRESS : GlobalConstants.NOIPADDRESSFOUND;
        }
        #endregion

        #region Private Function for Loading corresponding ports
        private void loadPort()
        {
            this.tbcmdport.Text = GlobalConstants.CMDPORTVALUE;
        }
        #endregion

        #region Event minToolStripMenuItem_Click to Min mainform
        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ninotification.Visible = true;
        }
        #endregion

        #region Event bstart_Click to Start listen socket at specified port
        private void bstart_Click(object sender, EventArgs e)
        {
            startService();
            if (connected)
            {
                this.pbimage.Image = this.pbimage.InitialImage;
                this.lstatus.Text = GlobalConstants.SERVERSTATUSINLISTEN;
                this.bstart.Enabled = false;
                this.bstop.Enabled = true;
            }
        }
        #endregion

        #region Private Method startService to start to listen socket at specified ports
        private void startService()
        {
            try
            {
                if (this.ddip.Text != null && this.ddip.Text.Length > 0 && this.ddip.Text.IndexOf(".") > 0)
                {
                    int cmdPort = -1;
                    if (this.tbcmdport.Text != null && this.tbcmdport.Text.ToString().Length > 0)
                    {
                        try
                        {
                            cmdPort = int.Parse(this.tbcmdport.Text.ToString().Trim());
                        }
                        catch (Exception e)
                        {
                            if (cmdPort != -1)
                            {
                                    connected = false;
                            }
                            else
                            {
                                if (GlobalConstants.OK.ToLower() == System.Windows.Forms.MessageBox.Show(GlobalConstants.CMDPORT + this.tbcmdport.Text.ToString() + GlobalConstants.PORTINVALID1555, GlobalConstants.PORTINVALID, MessageBoxButtons.OKCancel).ToString().ToLower())
                                {
                                    this.tbcmdport.Text = GlobalConstants.PORT1556;
                                    cmdPort = 1555;
                                }
                                else
                                {
                                    cmdPort = -1;
                                    connected = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GlobalConstants.OK.ToLower() == System.Windows.Forms.MessageBox.Show(GlobalConstants.CMDPORT + this.tbcmdport.Text.ToString() + GlobalConstants.PORTINVALID1555, GlobalConstants.PORTINVALID, MessageBoxButtons.OKCancel).ToString().ToLower())
                        {
                            this.tbcmdport.Text = GlobalConstants.PORT1556;
                            cmdPort = 1555;
                        }
                        else
                        {
                            cmdPort = -1;
                            connected = false;
                        }
                    }
                    if (cmdPort != -1)
                    {
                        threadExe = new Thread(new ThreadStart((this.cmdthread = new WireLessPC.CommandExecutorThread(this.ddip.Text.ToString().Trim(), cmdPort,this)).Handle));
                        threadExe.Start();
                        connected = true;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(GlobalConstants.PROMPTSELECTADDRESS);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Event mainform_Resize for resizing mainform
        private void mainform_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ninotification.Visible = true;
            }
        }
        #endregion

        #region Event ninotification_MouseDoubleClick for showing the hidden mainform
        private void ninotification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.ninotification.Visible = true;
        }
        #endregion

        #region Event bstop_Click for stoping listening socket
        private void bstop_Click(object sender, EventArgs e)
        {
            stopListen();
        }
        #endregion

        #region Event exit_Click for Exiting application wirelessmousekeyboard
        private void exit_Click(object sender, EventArgs e)
        {
            exitApp();
        }
        #endregion

        #region Private Method for Exiting application wirelessmousekeyboard
        private void exitApp()
        {
            stopListen();
            Process.GetCurrentProcess().Kill();
            this.ninotification.Visible = false;
            this.ninotification.Dispose();
            this.Close();
        }
        #endregion

        #region Private Method for stoping listening service
        private void stopListen()
        {
            if (this.cmdthread != null)
            {
                this.threadExe.Abort();
                this.threadExe = null;
                this.cmdthread.Abort();
                this.cmdthread = null;
            }
            this.bstart.Enabled = true;
            this.bstop.Enabled = false;
            this.lstatus.Text = "";
            System.Drawing.Image image = new System.Drawing.Bitmap(Properties.Resources.pause);
            this.pbimage.Image = image;
        }
        #endregion

        #region Event show_Click from notification to show the mainform
        private void show_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ninotification.Visible = true;
        }
        #endregion


        #region Event exitToolStripMenuItem_Click from menu to exit application wirelessmousekeyboard
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitApp();
        }
        #endregion

        #region Event stop_Click notification to stop listen
        private void stop_Click(object sender, EventArgs e)
        {
            stopListen();
        }
        #endregion

        #region Event mainform_FormClosing to exit application wirelessmousekeyboard before closing win form
        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            exitApp();
        }
        #endregion

        #region Delegate to process lstatus and pbimage
        delegate void ShowMessageHandler(string message);
        public void showmessage(String message)
        {
          if(this.InvokeRequired){
              ShowMessageHandler show = new ShowMessageHandler(processmessage);
              this.BeginInvoke(show, message);
          }
          else{
            this.lstatus.Text = message;
          }
        }

        public void processmessage(String message)
        {
            this.lstatus.Text = message;
        }
        delegate void changeIcoHandler(System.Drawing.Image image);
        public void changeIco(System.Drawing.Image image)
        {
            if (this.InvokeRequired)
            {
                changeIcoHandler show = new changeIcoHandler(processIco);
                this.BeginInvoke(show, image);
            }
            else
            {
                this.pbimage.Image = image;
            }
        }
        public void processIco(System.Drawing.Image image)
        {
            this.pbimage.Image = image;
        }
        #endregion
    }
}
