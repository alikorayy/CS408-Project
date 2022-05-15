using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientModule
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientsocket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            //this.FormClosing += new FormClosingEventHandler(disconnect_button_Click);
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = IP_TextBox.Text;
            int portnum;
            string user_name = username_text.Text;
            string username = user_name + "|U";
            if (Int32.TryParse(portText.Text, out portnum))
            {
                try
                {
                    clientsocket.Connect(IP, portnum);
                    connected = true;

                    if (user_name != "")
                    {
                        Byte[] buffer_username = Encoding.Default.GetBytes(username);
                        clientsocket.Send(buffer_username);
                        Thread receivethread = new Thread(Receive);
                        receivethread.Start();
                    }
                    else
                    {
                        client_log.AppendText("Please enter a valid username!\n");
                    }

                }

                catch
                {
                    client_log.AppendText("Could not connected to the server \n");
                }
            }
            else
            {
                client_log.AppendText("Please check your port number.\n");
            }
        }

        private void Receive()
        {

            while (connected)
            {
                try
                {
                    string user_name = username_text.Text;
                    Byte[] buffer = new Byte[1024];
                    clientsocket.Receive(buffer);
                    string incomingmessage = Encoding.Default.GetString(buffer);
                    incomingmessage = incomingmessage.Substring(0, incomingmessage.IndexOf("\0"));
                    string message1 = user_name + " tried to connect to the server but cannot!|C";
                    string message2 = user_name + " has connected.|C";                   
                    if (incomingmessage == "0")
                    {
                        connected = false;
                        client_log.AppendText("Please enter a vaild username! 0 \n");
                        Byte[] buffer_username = Encoding.Default.GetBytes(message1);
                        clientsocket.Send(buffer_username);
                        clientsocket.Close();

                    }
                    else if (incomingmessage == "1")
                    {
                        client_log.AppendText("Hello " + user_name + "!" + " You are connected to the server.\n");
                        Byte[] message = Encoding.Default.GetBytes(message2);
                        clientsocket.Send(message);
                        connect_button.Enabled = false;
                        disconnect_button.Enabled = true;
                        postTextBox.Enabled = true;
                        allposts_button.Enabled = true;
                        send_button.Enabled = true;
                    }
                    else
                    {
                        client_log.AppendText(incomingmessage + "\n");                        
                    }
                   
                }
                catch
                {
                    
                    if (!terminating)
                    {
                        connect_button.Enabled = true;
                        disconnect_button.Enabled = false;                        
                    }                    
                    clientsocket.Close();
                    connected = false;
                }
            }
        }



        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (connected == true)
            {
                string user_name = username_text.Text;
                string message3 = user_name + " has disconnected.|C";
                Byte[] message = Encoding.Default.GetBytes(message3);
                clientsocket.Send(message);
            }
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;                     
            string postContent = postTextBox.Text;
            string timeStamp = GetTimestamp(DateTime.Now);            
            string message1 = user_name + " has sent a post:";
            string message2 = message1 + ";" + user_name + ";" + postContent + ";" + timeStamp + "|P";       
            Byte[] message31 = Encoding.Default.GetBytes(message2);
            clientsocket.Send(message31);            
            client_log.AppendText(user_name + ": " + postContent + "\n");
        }

        private void allposts_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;
            string ackMessage = "Showed all posts for " + user_name + ".|C";
            Byte[] requestMessage = Encoding.Default.GetBytes(ackMessage);
            clientsocket.Send(requestMessage);
            string message1 = user_name + "|R";
            Byte[] message = Encoding.Default.GetBytes(message1);
            clientsocket.Send(message);
            client_log.AppendText("Showing all posts from clients:\n");
        }

        private void disconnect_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;
            string message3 = user_name + " has disconnected.|C";
            Byte[] message = Encoding.Default.GetBytes(message3);
            clientsocket.Send(message);
            connected = false;
            terminating = true;
            clientsocket.Close();
            connect_button.Enabled = true;
            postTextBox.Enabled = false;
            send_button.Enabled = false;
            allposts_button.Enabled = false;
            disconnect_button.Enabled = false;
            client_log.AppendText("You are disconnected!\n");
        }
    }
}
