using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GodEyeServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1(serverSocket));
            
            Form1 InitForm = new Form1(serverSocket);
#if DEBUG
#else
            InitForm.ShowDialog();
#endif
            if (InitForm.DialogResult.Equals(DialogResult.OK))
            {
                //If start the Listening Service Successfully
                Application.Run(new ClientListForm(serverSocket));
            }
        }
    }
}
