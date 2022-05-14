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
        int postID = 0;
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
                    Byte[] buffer = new Byte[1000];
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
                    else if (type == "P")
                    {                       
                        string[] newData = message.Split(';');
                        string consoleMessage = newData[0];
                        string username = newData[1];
                        string postContent = newData[2];
                        string timeStamp = newData[3];
                        if (postID == 0)
                        {
                            postID = 1;
                            string newContent = username + "|" + postID + "|" + postContent + "|" + timeStamp;
                            File.AppendAllText(@"../../post-db.txt", newContent + Environment.NewLine);
                            serverConsole.AppendText(consoleMessage + "\n" + postContent + "\n");
                        }
                        else
                        {
                            foreach (string line in File.ReadLines(@"../../post-db.txt"))
                            {
                                string[] lineData = line.Split('|');
                                int tempPostID = Int32.Parse(lineData[1]);
                                if (tempPostID == postID)
                                {
                                    postID += 1;
                                }
                            }
                            string newContent = username + "|" + postID + "|" + postContent + "|" + timeStamp;
                            File.AppendAllText(@"../../post-db.txt", newContent + Environment.NewLine);
                            serverConsole.AppendText(consoleMessage + "\n" + postContent + "\n");
                        }
                    }
                    else if (type == "R")
                    {
                        foreach (string line in File.ReadLines(@"../../post-db.txt"))
                        {                             
                            string[] lineData = line.Split('|');
                            string tempUsername = lineData[0];
                            string tempPostID = lineData[1];
                            string tempPostContent = lineData[2];
                            string tempTimeStamp = lineData[3];
                            if (message != tempUsername)
                            {
                                string postMessage = "Username: " + tempUsername + "\n" + "PostID: " + tempPostID + "\n" + "Post: " + tempPostContent + "\n" + "Time: " + tempTimeStamp + "\n";
                                Byte[] postInfo = Encoding.Default.GetBytes(postMessage);
                                thisClient.Send(postInfo);
                            }   

                        }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string line in File.ReadLines(@"../../post-db.txt"))
            {
                string[] lineData = line.Split('|');
                int tempPostID = Int32.Parse(lineData[1]);
                postID = tempPostID;
            }
            string maxID = postID.ToString();
            serverConsole.AppendText(maxID);
        }
    }
}
