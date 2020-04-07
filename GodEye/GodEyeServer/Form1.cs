using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace GodEyeServer
{
    public partial class Form1 : Form
    {
        private Socket serverSocket;
        public Form1(Socket socket)
        {
            InitializeComponent();
            this.serverSocket = socket;
            nud_port.Value = 1107;
            edt_ipadress.Text = "127.0.0.1";
#if DEBUG
            edt_ipadress.Text = "192.168.5.1";
            String ip = this.edt_ipadress.Text;
            int port = Convert.ToInt32(this.nud_port.Value);
            int maxNumber = Convert.ToInt32(this.nud_max_number.Value);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            serverSocket.Listen(maxNumber);
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            this.Close();
#endif
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            /*
             * 1.Check Data
             * 2.Bind Socket
             * 3.Start Listening Service
             * 4.Close this Form and Return the Result
             */

            //1
            String ip = this.edt_ipadress.Text;
            int port = Convert.ToInt32(this.nud_port.Value);
            int maxNumber = Convert.ToInt32(this.nud_max_number.Value);
            if (!CheckData(ip, port))
            {
                MessageBox.Show("The Data provided by you is invalid.");
                return;
            }

            //2
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));

            //3
            serverSocket.Listen(maxNumber);

            this.DialogResult = DialogResult.OK;
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// Check whether or not the data provided is invalid
        /// </summary>
        /// <param name="ip">the ip address which is going to be bind</param>
        /// <param name="port">the port which is going to be bind</param>
        /// <returns>if the data is valid</returns>
        private Boolean CheckData(String ip,int port)
        {
            IPAddress ipAddr;
            return isPortUsed(port) && IPAddress.TryParse(ip, out ipAddr); 
        }

        /// <summary>
        /// Check whether or not the port provided is in use
        /// </summary>
        /// <param name="port">the port which is provided by user</param>
        /// <returns>if the prot is in use</returns>
        private Boolean isPortUsed(int port)
        {
            //Get the Network Information
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = properties.GetActiveTcpListeners();

            foreach(IPEndPoint ipEndPoint in ipEndPoints)
            {
                if (ipEndPoint.Port.Equals(port))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
