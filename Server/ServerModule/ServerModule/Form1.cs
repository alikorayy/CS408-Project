using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerModule
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        bool terminate = false;
        bool listening = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

       
        private void buttonListen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(portTextBox.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                buttonListen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                serverConsole.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                serverConsole.AppendText("Please check port number \n");
            }
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);
                    Thread receiveThread = new Thread(() => Receive(newClient)); // updated
                    receiveThread.Start();
                }
                catch
                {
                    if (terminate)
                    {
                        listening = false;
                    }
                    else
                    {
                        serverConsole.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }

        private void Receive(Socket thisClient)
        {
            bool connected = true;
            while (connected && !terminate)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    string[] data = incomingMessage.Split('|');
                    string message = data[0];
                    string type = data[1];
                    if (type == "U")
                    {
                        string username = message;
                        bool userExists = false;
                        string confirmMessage = "1";
                        string errorMessage = "0";
                        foreach (string line in File.ReadLines(@"../../user-db.txt"))
                        {
                            string databaseUser = line;
                            if (username == databaseUser)
                            {
                                userExists = true;
                                break;
                            }
                        }
                        if (userExists)
                        {
                            Byte[] buffer2 = Encoding.Default.GetBytes(confirmMessage);
                            thisClient.Send(buffer2);
                        }
                        else
                        {
                            Byte[] buffer3 = Encoding.Default.GetBytes(errorMessage);
                            thisClient.Send(buffer3);
                        }
                    }
                    else if (type == "C")
                    {
                        serverConsole.AppendText(message + "\n");
                    }

                }
                catch
                {
           

                    if (!terminate)
                    {
                        
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listening = false;
            terminate = true;
            foreach (var item in clientSockets)
            {
                Byte[] sendError = Encoding.Default.GetBytes("The server has disconnected!");
                item.Send(sendError);
            }
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
