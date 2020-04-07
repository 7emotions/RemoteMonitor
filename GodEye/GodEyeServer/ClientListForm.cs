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
using System.Net;

namespace GodEyeServer
{
    
    public partial class ClientListForm : Form
    {
        private Socket serverSocket;
        /// <summary>
        /// By using this static class,we can visit the control easily
        /// </summary>
        private static ClientListForm UIHelper = null;

        private delegate void StorageClientDelegate(Socket socket);
        public ClientListForm(Socket socket)
        {
            InitializeComponent();
            //Add root node to tree
            TreeNode root = this.tree_clients.Nodes.Add("root", "127.0.0.1");
            root.ToolTipText = "Local PC";
            this.serverSocket = socket;
            UIHelper = this;
            
            serverSocket.BeginAccept(AcceptCallBack, serverSocket);
        }

        private static void AcceptCallBack(IAsyncResult ar)
        {
            Socket serverSocket = ar.AsyncState as Socket;
            Socket clientSocket = serverSocket.EndAccept(ar);

            //Add client to tree
            StorageClientDelegate storageClientDelegate = new StorageClientDelegate(StorageClient);
            UIHelper.Invoke(storageClientDelegate, new object[] { clientSocket });

            serverSocket.BeginAccept(AcceptCallBack, serverSocket);
        }

        /// <summary>
        /// Storage the Client which has had connected
        /// </summary>
        /// <param name="clientSocket">the Client which has had connected</param>
        private static void StorageClient(Socket clientSocket)
        {
            TreeNode node = UIHelper.tree_clients.Nodes["root"].Nodes.Add(clientSocket.RemoteEndPoint.ToString());
            node.Tag = clientSocket;
            node.ContextMenuStrip = UIHelper.contextMenuStrip1;

        }

        private void tree_clients_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.Equals("root"))
            {
                return;
            }
            
            if (e.Button.Equals(MouseButtons.Right))
            {
                //var p = PointToScreen(tree_clients.Location);
                //int x = MousePosition.X - p.X;
                //int y = MousePosition.Y - p.Y;
                
                return;
            }

            TreeNode node = tree_clients.SelectedNode;
            GodEyeForm godEye = new GodEyeForm(node.Tag as Socket);
            godEye.OnOff();
            godEye.Show();
        }

        private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tree_clients.SelectedNode;
            GodEyeForm godEye = new GodEyeForm(node.Tag as Socket);
            godEye.OnOff();
            godEye.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree_clients.SelectedNode.Name.Equals("root"))
            {
                return;
            }
            tree_clients.SelectedNode.Remove();
        }
    }
}
