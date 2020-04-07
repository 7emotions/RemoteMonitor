using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace GodEyeServer
{
    public partial class GodEyeForm : Form
    {
        private int SW = 0;//The Width of screen
        private int SH = 0;//The Height of screen
        private Socket clientSocket;
        private byte[] buffer = new byte[1024 * 500];
        private static GodEyeForm sf;//we can use it to refresh

        public GodEyeForm(Socket socket)
        {
            try
            {
                InitializeComponent();
                sf = this;
                clientSocket = socket;

                byte[] vs = new byte[10];
                int count = 0;
                //Get The Width of screen
                socket.Send(Encoding.UTF8.GetBytes("W"));
                count = socket.Receive(vs);
                SW = int.Parse(Encoding.UTF8.GetString(vs, 0, count));

#if DEBUG
                Console.WriteLine("Get SW:" + SW.ToString());
#endif

                //Get The Height of screen
                socket.Send(Encoding.UTF8.GetBytes("H"));
                count = socket.Receive(vs);
                SH = int.Parse(Encoding.UTF8.GetString(vs, 0, count));


#if DEBUG
                Console.WriteLine("Get SH:" + SH.ToString());
#endif


                if (!SW.Equals(0) && !SH.Equals(0))
                {
                    this.Width = this.pic.Width = SW;
                    this.Height = this.pic.Height = SH;
                    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallBack, socket);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnOff()
        {
            try
            {
                clientSocket.Send(Encoding.UTF8.GetBytes("B"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void ReceiveCallBack(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            try
            {
                int count = socket.EndReceive(ar);
                MemoryStream ms = new MemoryStream(sf.buffer, 0, count);
                sf.pic.Image = Image.FromStream(ms);
                ms.Close();
                socket.Send(Encoding.UTF8.GetBytes("B"));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            socket.BeginReceive(sf.buffer, 0, sf.buffer.Length, SocketFlags.None, ReceiveCallBack, socket);
        }

    }
}
