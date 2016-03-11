using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WireLessPC
{
    class MousekeysUtility
    {
        #region Reference external library
        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
          wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point pt);
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
        #endregion

        #region Method for public static
        #region Process Commands Function
        public static void processCommand(String command)
        {
            try
            {
                if (command != null && command.StartsWith(GlobalConstants.DOLLAR))//Execute Dos/Shell commands
                {
                    String[] com = command.Trim().Split('|');
                    executCommand(com[1]);
                }
                else if (command != null && command.ToLower().StartsWith(GlobalConstants.MOUSE.ToLower()))
                {
                    String[] com = command.Trim().Split('|');
                    if (com[1].ToLower().StartsWith(GlobalConstants.mMOVE.ToLower()))
                    { 
                        mouseMove(com[1]);
                    }
                    else if (com[1].ToLower().StartsWith(GlobalConstants.mUP.ToLower()))
                    {
                        Point point = getcorsorPos();
                        mouse_event(MouseEventFlag.Wheel, point.X, point.Y, 1, UIntPtr.Zero);
                    }
                    else if (com[1].ToLower().StartsWith(GlobalConstants.mDOWN.ToLower()))
                    {
                        Point point = getcorsorPos();
                        mouse_event(MouseEventFlag.Wheel, point.X, point.Y, 0, UIntPtr.Zero);
                    }
                    else if (com[1].ToLower().StartsWith(GlobalConstants.mLEFT.ToLower()))
                    {
                        Point point = getcorsorPos();
                        mouse_event(MouseEventFlag.LeftDown, point.X, point.Y, 0, UIntPtr.Zero);
                        mouse_event(MouseEventFlag.LeftUp, point.X, point.Y, 0, UIntPtr.Zero);
                    }
                    else if (com[1].ToLower().StartsWith(GlobalConstants.mRIGHT.ToLower()))
                    {
                        Point point = getcorsorPos();
                        mouse_event(MouseEventFlag.RightDown, point.X, point.Y, 0, UIntPtr.Zero);
                        mouse_event(MouseEventFlag.RightUp, point.X, point.Y, 0, UIntPtr.Zero);
                    }
                }
                else if (command != null && command.ToLower().StartsWith(GlobalConstants.KEY.ToLower()))
                {
                    String[] com = command.Trim().Split('|');
                    if (com[1].ToLower().StartsWith(GlobalConstants.SPACE.ToLower()))
                    {
                        sendkey(" ");
                    }
                    else
                        sendkey(com[1]);
                }
                else if (command != null && command.ToLower().StartsWith(GlobalConstants.PPT.ToLower()))
                {
                    String[] com = command.Trim().Split('|');
                    if (com[1].ToLower().StartsWith(GlobalConstants.PRE.ToLower()))
                    {
                        sendkey("{LEFT}");
                    }
                    else if (com[1].ToLower().StartsWith(GlobalConstants.NEXT.ToLower()))
                    {
                        sendkey("{RIGHT}");
                    }
                    else if (com[1].ToLower().StartsWith(GlobalConstants.START.ToLower()))
                    {
                        sendkey(GlobalConstants.F5VALUE);
                    }
                    else if (com[1].ToLower().StartsWith(GlobalConstants.STOP.ToLower()))
                    {
                        sendkey(GlobalConstants.ESCVALUE);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message.ToString());
            }
        }
        #endregion

        #endregion

        #region Methods for private static
        #region Function for executing dos/shell commands
        private static void executCommand(String command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.StandardInput.WriteLine(command);
        }
        #endregion

        #region Function for moving mouse position
        private static void mouseMove(String command)
        {
            if (command.IndexOf(":") > 0)
            {
                String[] pos = command.Split(':');
                Point point = getcorsorPos();
                int x = -5000, y = -5000;
                try
                {
                    x = Convert.ToInt32(pos[1])*5 + point.X;
                    y = Convert.ToInt32(pos[2])*5 + point.Y;
                    SetCursorPos(x, y);
                }
                catch (Exception emovemouse)
                {
                    System.Console.WriteLine("emovemouse: " + emovemouse.Message.ToString() + " cmd value: " + command);
                }
            }
        }
        #endregion
        #region private method for sendkeys.sendWait
        private static void sendkey(String key)
        {
            SendKeys.SendWait(key);
            SendKeys.Flush();
        }
        #endregion

        #region Function for getting current position of corsor
        private static Point getcorsorPos()
        {
            Point currentPoint = new Point();
            GetCursorPos(out currentPoint);
            return currentPoint;
        }
        #endregion
        #endregion
    }
}
