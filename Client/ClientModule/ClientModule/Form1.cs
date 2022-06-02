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
                    string message3 = user_name + " tried to connect to the server but cannot because this user is already connected!|C";
                    if (incomingmessage == "0")
                    {
                        connected = false;
                        client_log.AppendText("This username is not in the database!\n");
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
                        IP_TextBox.Enabled = false;
                        portText.Enabled = false;
                        username_text.Enabled = false;
                        removefriend_button.Enabled = true;
                        username2_text.Enabled = true;
                        addfriend_button.Enabled = true;
                        postID_Text.Enabled = true;
                        delete_button.Enabled = true;
                        mypost_button.Enabled = true;
                        friendpost_button.Enabled = true;
                        string sendMessage = user_name + "|SNDF";
                        Byte[] buffer_two = Encoding.Default.GetBytes(sendMessage);
                        clientsocket.Send(buffer_two);


                    }
                    else if (incomingmessage == "2") 
                    {
                        connected = false;
                        client_log.AppendText(user_name + " is already connected to the server.\n");
                        Byte[] buffer_one = Encoding.Default.GetBytes(message3);
                        clientsocket.Send(buffer_one);
                        clientsocket.Close();
                    }
                    else
                    {
                        if (incomingmessage.Contains("$#$"))
                        {
                            string[] seperator = { "$#$" };
                            string[] incomingData = incomingmessage.Split(seperator, StringSplitOptions.None);
                            string tempUsername = incomingData[0];
                            string tempFriendUsername = incomingData[1];
                            if (tempUsername == user_name)
                            {
                                client_log.AppendText("You have added " + tempFriendUsername + " as friend.\n");
                                friendlist_box.Items.Add(tempFriendUsername);
                            }
                            else if (tempFriendUsername == user_name)
                            {
                                client_log.AppendText(tempUsername + " added you as a friend. You are friends now :)\n");
                                friendlist_box.Items.Add(tempUsername);
                            }

                        }
                        else if (incomingmessage.Contains("#$#"))
                        {
                            string[] seperator = { "#$#" };
                            string[] incomingData = incomingmessage.Split(seperator, StringSplitOptions.None);
                            string tempUsername = incomingData[0];
                            string tempFriendUsername = incomingData[1];
                            if (tempUsername == user_name)
                            {
                                client_log.AppendText("You can not add " + tempFriendUsername + " as friend because you are already friends.\n");
                            }
                            else if (tempFriendUsername == user_name)
                            {
                                client_log.AppendText(tempUsername + " tried to add you as a friend but can not. Because you are already friends.\n");
                            }

                        }
                        else if(incomingmessage.Contains("&%&"))
                        {
                            string[] seperator = { "&%&" };
                            string[] incomingData = incomingmessage.Split(seperator, StringSplitOptions.None);
                            string all_friends = incomingData[0];
                            string[] all_friends_list = all_friends.Split('-');
                            foreach( var item in all_friends_list)
                            {
                                friendlist_box.Items.Add(item);
                            }
                        }
                        
                        else if (incomingmessage.Contains("&$&"))
                        {
                            string[] seperator = { "&$&" };
                            string[] incomingData = incomingmessage.Split(seperator, StringSplitOptions.None);
                            string tempUsername = incomingData[0];
                            string tempFriendUsername = incomingData[1];
                            if (tempUsername == user_name)
                            {
                                client_log.AppendText("You have removed " + tempFriendUsername + " from your friendlist.\n");
                                friendlist_box.Items.Remove(tempFriendUsername);
                            }
                            else if (tempFriendUsername == user_name)
                            {
                                client_log.AppendText(tempUsername + " removed you from his/her friendlist. You are no longer friends:(\n");
                                friendlist_box.Items.Remove(tempUsername);
                            }
                        }

                        else
                        {
                            client_log.AppendText(incomingmessage + "\n");
                        }
                    }
                   
                }
                catch
                {
                    
                    if (!terminating)
                    {
                        connect_button.Enabled = true;
                        disconnect_button.Enabled = false;
                        postTextBox.Enabled = false;
                        send_button.Enabled = false;
                        allposts_button.Enabled = false;
                        IP_TextBox.Enabled = true;
                        portText.Enabled = true;
                        username_text.Enabled = true;
                        username2_text.Enabled = false;
                        addfriend_button.Enabled = false;
                        postID_Text.Enabled = false;
                        delete_button.Enabled = false;
                        mypost_button.Enabled = false;
                        friendpost_button.Enabled = false;
                        removefriend_button.Enabled = false;
                        friendlist_box.Items.Clear();
                    }
                    connected = false;
                    clientsocket.Close();                   
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
                Thread.Sleep(2);
                string message4 = user_name + "|D";
                Byte[] exitmessage = Encoding.Default.GetBytes(message4);
                clientsocket.Send(exitmessage);
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
            if (connected)
            {
                string user_name = username_text.Text;
                string message3 = user_name + " has disconnected.|C";
                Byte[] message = Encoding.Default.GetBytes(message3);
                clientsocket.Send(message);
                Thread.Sleep(2);
                string message4 = user_name + "|D";
                Byte[] exitmessage = Encoding.Default.GetBytes(message4);
                clientsocket.Send(exitmessage);
            }
            connected = false;
            terminating = true;
            clientsocket.Close();
            connect_button.Enabled = true;
            postTextBox.Enabled = false;
            send_button.Enabled = false;
            allposts_button.Enabled = false;
            disconnect_button.Enabled = false;
            IP_TextBox.Enabled = true;
            portText.Enabled = true;
            username_text.Enabled = true;
            username2_text.Enabled = false;
            addfriend_button.Enabled = false;
            postID_Text.Enabled = false;
            delete_button.Enabled = false;
            mypost_button.Enabled = false;
            friendpost_button.Enabled = false;
            removefriend_button.Enabled = false;
            friendlist_box.Items.Clear();
            client_log.AppendText("You are disconnected!\n");
        }
        private void mypost_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;
            string ackMessage = "Showed users posts for " + user_name + ".|C";
            Byte[] requestMessage = Encoding.Default.GetBytes(ackMessage);
            clientsocket.Send(requestMessage);
            string message1 = user_name + "|RU";
            Byte[] message = Encoding.Default.GetBytes(message1);
            clientsocket.Send(message);
            client_log.AppendText("Showing your posts:\n");
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;
            string postID = postID_Text.Text;
            string postIDMessage = postID + "-" + user_name + "|DEL";
            Byte[] postMessage = Encoding.Default.GetBytes(postIDMessage);
            clientsocket.Send(postMessage);
        }

        private void addfriend_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;
            string friend_username = username2_text.Text;
            string addFriendMessage = user_name + "-" + friend_username + "|FRND";
            Byte[] postMessage = Encoding.Default.GetBytes(addFriendMessage);
            clientsocket.Send(postMessage);
        }

        private void friendpost_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;
            string ackMessage = "Showed friends post of " + user_name + ".|C";
            Byte[] requestMessage = Encoding.Default.GetBytes(ackMessage);
            clientsocket.Send(requestMessage);
            string message1 = user_name + "|FR";
            Byte[] message = Encoding.Default.GetBytes(message1);
            clientsocket.Send(message);
            client_log.AppendText("Showing your friends' posts:\n");
        }

        private void removefriend_button_Click(object sender, EventArgs e)
        {
            string user_name = username_text.Text;
            string deleted_username = friendlist_box.SelectedItem.ToString();
            string deleteMessage = user_name +"-"+deleted_username + "|RMVF";
            Byte[] message = Encoding.Default.GetBytes(deleteMessage);
            clientsocket.Send(message);
        }
    }
}
