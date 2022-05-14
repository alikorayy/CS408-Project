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
        bool username_check = false;
        Socket clientsocket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            //this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            //this.FormClosing += new FormClosingEventHandler(disconnect_button_Click);
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = IP_TextBox.Text;
            int portnum;
            string user_name = username_text.Text;
            if (Int32.TryParse(IP_TextBox.Text, out portnum))
            {
                try
                {   
                    clientsocket.Connect(IP, portnum);
                    connected = true;
                 
                    if (user_name != "")
                    {
                        Byte[] buffer_username = Encoding.Default.GetBytes(user_name);
                        clientsocket.Send(buffer_username);
                       
                        Thread receivethread = new Thread(Receive);
                        receivethread.Start();
                       

                    }

                }

                catch {
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
                    Byte[] buffer = new Byte[256];
                    clientsocket.Receive(buffer);
                    string incomingmessage = Encoding.Default.GetString(buffer);
                    incomingmessage = incomingmessage.Substring(0, incomingmessage.IndexOf("\0"));
                    if (incomingmessage == "0")
                    {
                        connected = false;
                        client_log.AppendText("Please enter a vaild username!");
                        Byte[] buffer_username = Encoding.Default.GetBytes(incomingmessage+"has connected.");
                        clientsocket.Send(buffer_username);
                        clientsocket.Close();

                    }
                    else if(incomingmessage == "1") {
                        client_log.AppendText("Hello"+incomingmessage+"!"+ "You are connected to the server.");
                        connect_button.Enabled = false;
                        disconnect_button.Enabled = true;
                        post_box.Enabled = true;
                        allposts_button.Enabled = true;
                        send_button.Enabled = true;
                    }
                    client_log.AppendText(incomingmessage + "\n");
                }
                catch
                {
                    if (!terminating)
                    {

                        connect_button.Enabled = true;
                        post_box.Enabled = false;
                        allposts_button.Enabled = false;
                        send_button.Enabled = false;
                        disconnect_button.Enabled = false;

                    }
                    clientsocket.Close();
                    connected = false;
                }
            }
        }



        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void send_button_Click(object sender, EventArgs e)
        {

        }
    }
}
