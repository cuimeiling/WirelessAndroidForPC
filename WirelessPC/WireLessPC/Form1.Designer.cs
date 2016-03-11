using System.Drawing;
namespace WireLessPC
{
    partial class mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.pcmd = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbcmdport = new System.Windows.Forms.TextBox();
            this.lcmdport = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ddip = new System.Windows.Forms.ComboBox();
            this.lip = new System.Windows.Forms.Label();
            this.bstart = new System.Windows.Forms.Button();
            this.bstop = new System.Windows.Forms.Button();
            this.lstatus = new System.Windows.Forms.Label();
            this.ninotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.pbimage = new System.Windows.Forms.PictureBox();
            this.pcmd.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).BeginInit();
            this.SuspendLayout();
            // 
            // pcmd
            // 
            this.pcmd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pcmd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pcmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcmd.Controls.Add(this.panel1);
            this.pcmd.Controls.Add(this.bstart);
            this.pcmd.Controls.Add(this.bstop);
            this.pcmd.Location = new System.Drawing.Point(-11, 26);
            this.pcmd.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.pcmd.Name = "pcmd";
            this.pcmd.Size = new System.Drawing.Size(493, 98);
            this.pcmd.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(5, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 139);
            this.panel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.tbcmdport);
            this.panel3.Controls.Add(this.lcmdport);
            this.panel3.Location = new System.Drawing.Point(9, 48);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 38);
            this.panel3.TabIndex = 0;
            // 
            // tbcmdport
            // 
            this.tbcmdport.BackColor = System.Drawing.Color.White;
            this.tbcmdport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbcmdport.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbcmdport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbcmdport.ForeColor = System.Drawing.Color.Black;
            this.tbcmdport.Location = new System.Drawing.Point(93, 10);
            this.tbcmdport.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tbcmdport.Name = "tbcmdport";
            this.tbcmdport.Size = new System.Drawing.Size(161, 19);
            this.tbcmdport.TabIndex = 8;
            // 
            // lcmdport
            // 
            this.lcmdport.AutoSize = true;
            this.lcmdport.BackColor = System.Drawing.Color.Transparent;
            this.lcmdport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lcmdport.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lcmdport.Location = new System.Drawing.Point(5, 10);
            this.lcmdport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lcmdport.Name = "lcmdport";
            this.lcmdport.Size = new System.Drawing.Size(80, 16);
            this.lcmdport.TabIndex = 11;
            this.lcmdport.Text = "命令端口:";
            this.lcmdport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ddip);
            this.panel2.Controls.Add(this.lip);
            this.panel2.Location = new System.Drawing.Point(9, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 38);
            this.panel2.TabIndex = 0;
            // 
            // ddip
            // 
            this.ddip.BackColor = System.Drawing.Color.White;
            this.ddip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ddip.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddip.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ddip.IntegralHeight = false;
            this.ddip.Location = new System.Drawing.Point(77, 9);
            this.ddip.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.ddip.Name = "ddip";
            this.ddip.Size = new System.Drawing.Size(185, 24);
            this.ddip.TabIndex = 7;
            // 
            // lip
            // 
            this.lip.AutoSize = true;
            this.lip.BackColor = System.Drawing.Color.Transparent;
            this.lip.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lip.ForeColor = System.Drawing.Color.DimGray;
            this.lip.Location = new System.Drawing.Point(5, 10);
            this.lip.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lip.Name = "lip";
            this.lip.Size = new System.Drawing.Size(64, 16);
            this.lip.TabIndex = 12;
            this.lip.Text = "IP地址:";
            // 
            // bstart
            // 
            this.bstart.BackColor = System.Drawing.Color.Transparent;
            this.bstart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bstart.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bstart.Location = new System.Drawing.Point(329, 3);
            this.bstart.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bstart.Name = "bstart";
            this.bstart.Size = new System.Drawing.Size(117, 42);
            this.bstart.TabIndex = 3;
            this.bstart.Text = "开始";
            this.bstart.UseVisualStyleBackColor = false;
            this.bstart.Click += new System.EventHandler(this.bstart_Click);
            // 
            // bstop
            // 
            this.bstop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bstop.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bstop.Location = new System.Drawing.Point(329, 48);
            this.bstop.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bstop.Name = "bstop";
            this.bstop.Size = new System.Drawing.Size(117, 42);
            this.bstop.TabIndex = 4;
            this.bstop.Text = "停止";
            this.bstop.UseVisualStyleBackColor = true;
            this.bstop.Click += new System.EventHandler(this.bstop_Click);
            // 
            // lstatus
            // 
            this.lstatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstatus.Location = new System.Drawing.Point(42, 5);
            this.lstatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(374, 21);
            this.lstatus.TabIndex = 9;
            this.lstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ninotification
            // 
            this.ninotification.Icon = ((System.Drawing.Icon)(resources.GetObject("ninotification.Icon")));
            this.ninotification.Text = "WirelessKey";
            this.ninotification.Visible = true;
            this.ninotification.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ninotification_MouseDoubleClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.lstatus);
            this.panel5.Controls.Add(this.pbimage);
            this.panel5.Location = new System.Drawing.Point(0, 130);
            this.panel5.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(473, 35);
            this.panel5.TabIndex = 10;
            // 
            // pbimage
            // 
            this.pbimage.ErrorImage = global::WireLessPC.Properties.Resources.bots2;
            this.pbimage.Image = global::WireLessPC.Properties.Resources.pause;
            this.pbimage.InitialImage = global::WireLessPC.Properties.Resources.play2;
            this.pbimage.Location = new System.Drawing.Point(7, 3);
            this.pbimage.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.pbimage.Name = "pbimage";
            this.pbimage.Size = new System.Drawing.Size(31, 27);
            this.pbimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbimage.TabIndex = 8;
            this.pbimage.TabStop = false;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WireLessPC.Properties.Resources._04;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(461, 166);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pcmd);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("楷体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Android控制鼠盘";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainform_FormClosing);
            this.Load += new System.EventHandler(this.mainform_Load);
            this.pcmd.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pcmd;
        private System.Windows.Forms.Button bstart;
        private System.Windows.Forms.Button bstop;
        public System.Windows.Forms.PictureBox pbimage;
        public System.Windows.Forms.Label lstatus;
        private System.Windows.Forms.NotifyIcon ninotification;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbcmdport;
        private System.Windows.Forms.Label lcmdport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ddip;
        private System.Windows.Forms.Label lip;
        private System.Windows.Forms.Panel panel5;
    }
}

