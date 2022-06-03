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
        string[] client_arr = { };
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
                    Byte[] buffer = new Byte[1024];
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
                        string existMessage = "2";
                        foreach (string line in File.ReadLines(@"../../user-db.txt"))
                        {
                            string databaseUser = line;
                            if (username == databaseUser)
                            {
                                userExists = true;
                                break;
                            }
                        }
                        bool isuseronline = false;
                        foreach (var e in client_arr)
                        {
                            if (e == username)
                            {
                                isuseronline = true;
                                break;
                            }
                        }
                        if (isuseronline == false)
                        {
                            Array.Resize(ref client_arr, client_arr.Length + 1);
                            client_arr[client_arr.Length - 1] = username;
                        }

                        if (userExists)
                        {
                            if (isuseronline == false)
                            {
                                Byte[] buffer2 = Encoding.Default.GetBytes(confirmMessage);
                                thisClient.Send(buffer2);
                            }
                            else if (isuseronline)
                            {
                                Byte[] buffer4 = Encoding.Default.GetBytes(existMessage);
                                thisClient.Send(buffer4);

                            }
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
                                Thread.Sleep(1);
                                thisClient.Send(postInfo);
                            }

                        }
                    }
                    else if (type == "FR")
                    {
                        string username = message;
                        string[] username_friend_list = { };
                        foreach (string line1 in File.ReadLines(@"../../friendlist-db.txt"))
                        {
                            string[] lineData1 = line1.Split('|');
                            string tempUsername1 = lineData1[0];
                            string tempFriendsname1 = lineData1[1];
                            string[] listFriendsname1 = lineData1[1].Split('-');
                            if (username == tempUsername1)
                            {
                                username_friend_list = listFriendsname1;
                            }
                        }
                        foreach (var items in username_friend_list)
                        {
                            foreach (string line in File.ReadLines(@"../../post-db.txt"))
                            {

                                string[] lineData = line.Split('|');
                                string tempUsername = lineData[0];
                                string tempPostID = lineData[1];
                                string tempPostContent = lineData[2];
                                string tempTimeStamp = lineData[3];
                                if (items == tempUsername)
                                {
                                    string postMessage = "Username: " + tempUsername + "\n" + "PostID: " + tempPostID + "\n" + "Post: " + tempPostContent + "\n" + "Time: " + tempTimeStamp + "\n";
                                    Byte[] postInfo = Encoding.Default.GetBytes(postMessage);
                                    Thread.Sleep(1);
                                    thisClient.Send(postInfo);
                                }

                            }
                        }

                    }
                    else if (type == "DEL")
                    {
                        string incomingData = message;
                        string[] dataList = incomingData.Split('-');
                        string postID = dataList[0];
                        string username = dataList[1];
                        int i = 0;
                        int delete_line = 0;
                        bool postId_matched = false;
                        bool username_matched = false;
                        foreach (string line in File.ReadLines(@"../../post-db.txt"))
                        {
                            string[] lineData = line.Split('|');
                            string tempUsername = lineData[0];
                            string tempPostID = lineData[1];
                            string tempPostContent = lineData[2];
                            string tempTimeStamp = lineData[3];

                            if (postID == tempPostID)
                            {
                                postId_matched = true;
                                if (username == tempUsername)
                                {

                                    username_matched = true;
                                    delete_line = i;
                                    break;
                                    //serverConsole.AppendText("Post with ID:" + postID + " is deleted." );
                                    //string message20 = "Post with ID: " + postID + " is deleted successully!";
                                    // Byte[] send = Encoding.Default.GetBytes(message20);
                                    //thisClient.Send(send);
                                }
                            }
                            i = i + 1;
                        }
                        if (postId_matched && username_matched)
                        {
                            delete_Post(delete_line);
                            serverConsole.AppendText("Post with ID:" + postID + " is deleted.\n");
                            string message20 = "Post with ID: " + postID + " is deleted successully!";
                            Byte[] send = Encoding.Default.GetBytes(message20);
                            thisClient.Send(send);

                        }

                        else if (postId_matched && username_matched == false)
                        {
                            serverConsole.AppendText("Post with ID:" + postID + " is not " + username + "'s!\n");
                            string message20 = "Post with ID: " + postID + " is not yours!";
                            Byte[] send = Encoding.Default.GetBytes(message20);
                            thisClient.Send(send);

                        }
                        else if (postId_matched == false && username_matched == false)
                        {

                            serverConsole.AppendText("Post with ID:" + postID + " does not exist!\n");
                            string message20 = "There is no post with ID:" + postID;
                            Byte[] send = Encoding.Default.GetBytes(message20);
                            thisClient.Send(send);
                        }



                    }
                    else if (type == "RU")
                    {
                        foreach (string line in File.ReadLines(@"../../post-db.txt"))
                        {
                            string[] lineData = line.Split('|');
                            string tempUsername = lineData[0];
                            string tempPostID = lineData[1];
                            string tempPostContent = lineData[2];
                            string tempTimeStamp = lineData[3];
                            if (message == tempUsername)
                            {
                                string postMessage = "Username: " + tempUsername + "\n" + "PostID: " + tempPostID + "\n" + "Post: " + tempPostContent + "\n" + "Time: " + tempTimeStamp + "\n";
                                Byte[] postInfo = Encoding.Default.GetBytes(postMessage);
                                Thread.Sleep(1);
                                thisClient.Send(postInfo);
                            }
                        }
                    }
                    else if (type == "FRND")
                    {
                        string incomingData = message;
                        string[] dataList = incomingData.Split('-');
                        string username = dataList[0];
                        string friend_username = dataList[1];
                        bool has_friend = false;
                        bool is_friend = false;
                        bool friend_has_friend = false;
                        bool userExists = false;
                        foreach (string line in File.ReadLines(@"../../user-db.txt"))
                        {
                            string databaseUser = line;
                            if (friend_username == databaseUser)
                            {
                                userExists = true;
                                break;
                            }
                        }
                        if (userExists)
                        {
                            if (username != friend_username)
                            {
                                foreach (string line in File.ReadLines(@"../../friendlist-db.txt"))
                                {
                                    string[] lineData = line.Split('|');
                                    string tempUsername = lineData[0];
                                    string tempFriendsname = lineData[1];
                                    string[] listFriendsname = lineData[1].Split('-');
                                    if (tempUsername == username)
                                    {
                                        has_friend = true;
                                        foreach (string item in listFriendsname)
                                        {
                                            if (item.Contains(friend_username))
                                            {
                                                is_friend = true;
                                                break;
                                            }

                                        }


                                    }
                                    if (tempUsername == friend_username)
                                    {
                                        friend_has_friend = true;
                                    }
                                }
                                if (!is_friend)
                                {
                                    if (has_friend == false)
                                    {
                                        if (friend_has_friend)
                                        {
                                            edit_single_Line(friend_username, username);
                                            string newContent = username + "|" + friend_username;
                                            File.AppendAllText(@"../../friendlist-db.txt", newContent + Environment.NewLine);

                                        }
                                        else if (!friend_has_friend)
                                        {
                                            string newContent = username + "|" + friend_username;
                                            File.AppendAllText(@"../../friendlist-db.txt", newContent + Environment.NewLine);
                                            string newContent2 = friend_username + "|" + username;
                                            File.AppendAllText(@"../../friendlist-db.txt", newContent2 + Environment.NewLine);
                                        }
                                    }
                                    else if (has_friend)
                                    {
                                        if (friend_has_friend)
                                        {
                                            edit_both_Line(username, friend_username);


                                        }
                                        else if (!friend_has_friend)
                                        {
                                            edit_single_Line(username, friend_username);
                                            string newContent = friend_username + "|" + username;
                                            File.AppendAllText(@"../../friendlist-db.txt", newContent + Environment.NewLine);
                                        }
                                    }
                                    foreach (var item in clientSockets)
                                    {
                                        string friend_message = username + "$#$" + friend_username;
                                        Byte[] friend_mess = Encoding.Default.GetBytes(friend_message);
                                        item.Send(friend_mess);
                                    }
                                    serverConsole.AppendText(username + " has added " + friend_username + " as a friend.\n");
                                }
                                else
                                {
                                    foreach (var item in clientSockets)
                                    {
                                        string friend_message = username + "#$#" + friend_username;
                                        Byte[] friend_mess = Encoding.Default.GetBytes(friend_message);
                                        item.Send(friend_mess);
                                    }
                                    serverConsole.AppendText(username + " tried to add " + friend_username + " as a friend but they are already friends!\n");
                                }
                            }
                            else if (username == friend_username)
                            {
                                serverConsole.AppendText("User can not add himself/herself as a friend!\n");
                                string clientError = "You can not add yourself as a friend!";
                                Byte[] SameNameError = Encoding.Default.GetBytes(clientError);
                                thisClient.Send(SameNameError);
                            }
                        }
                        else
                        {
                            serverConsole.AppendText("User tried to add someone as a friend who does not exist in database!\n");
                            string clientError = "You can not add " + friend_username + " as a friend because user does not exist in database!";
                            Byte[] SameNameError = Encoding.Default.GetBytes(clientError);
                            thisClient.Send(SameNameError);
                        }
                    }
                    else if (type == "RMVF")
                    {
                        string incomingData = message;
                        string[] dataList = incomingData.Split('-');
                        string username = dataList[0];
                        string friend_username = dataList[1];
                        bool has_multifriend = false;
                        bool friend_has_multifriend = false;
                        foreach (string line in File.ReadLines(@"../../friendlist-db.txt"))
                        {
                            string[] lineData = line.Split('|');
                            string tempUsername = lineData[0];
                            string tempFriendsname = lineData[1];
                            string[] listFriendsname = lineData[1].Split('-');
                            if (tempUsername == username)
                            {
                                if (listFriendsname.Length != 1)
                                {
                                    has_multifriend = true;
                                }

                            }
                            if (tempUsername == friend_username)
                            {
                                if (listFriendsname.Length != 1)
                                {
                                    friend_has_multifriend = true;
                                }

                            }
                        }
                        if (!has_multifriend)
                        {
                            if (friend_has_multifriend)
                            {
                                fulldelete_single_Line(username, friend_username);
                                

                            }
                            else if (!friend_has_multifriend)
                            {
                                fulldelete_both_Line(username, friend_username);
                            }
                        }
                        else if (has_multifriend)
                        {
                            if (friend_has_multifriend)
                            {
                                fulldelete_none_Line(username, friend_username);


                            }
                            else if (!friend_has_multifriend)
                            {
                                fulldelete_single_Line(friend_username,username);
                            }
                        }
                        foreach (var item in clientSockets)
                        {
                            string friend_message = username + "&$&" + friend_username;
                            Byte[] friend_mess = Encoding.Default.GetBytes(friend_message);
                            item.Send(friend_mess);
                        }
                        serverConsole.AppendText(username + " has removed " + friend_username + " from his/her friendlist.\n");
                    }
                    else if (type == "SNDF")
                    {
                        string username = message;
                        string sendfriendlist = "";
                        foreach (string line in File.ReadLines(@"../../friendlist-db.txt"))
                        {   

                            string[] lineData = line.Split('|');
                            string tempUsername = lineData[0];
                            string tempFriendsname = lineData[1];
                            if (tempUsername == username)
                            {
                                sendfriendlist = tempFriendsname + "&%&";
                                break;
                            }
                        }
                        Byte[] friend_list = Encoding.Default.GetBytes(sendfriendlist);
                        thisClient.Send(friend_list);

                    }
                    else if (type == "D")
                    {
                        string username = message;
                        client_arr = client_arr.Where(val => val != username).ToArray();
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
        }
        private void delete_Post(int lineToDelete)
        {
             
            List<string> linesList = File.ReadAllLines(@"../../post-db.txt").ToList();
            linesList.RemoveAt(lineToDelete);
            File.WriteAllLines((@"../../post-db.txt"), linesList.ToArray());
        }
        
        private void edit_both_Line(string username1, string username2)
        {
            int i = 0;
            int j = 0;
            int username1_index = 0;
            int username2_index = 0;
            string temp_username1_line = "";
            string temp_username2_line = "";
            List<string> linesList = File.ReadAllLines(@"../../friendlist-db.txt").ToList();
            foreach(var item in linesList)
            {
                string[] lineData = item.Split('|');
                if(username1 == lineData[0])
                {
                    username1_index = i;
                    temp_username1_line = item;

                }
                i++;
            }
            linesList.RemoveAt(username1_index);
            foreach(var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username2 == lineData[0])
                {
                    username2_index = j;
                    temp_username2_line = item;

                }
                j++;
            }
            linesList.RemoveAt(username2_index);
            File.WriteAllLines((@"../../friendlist-db.txt"), linesList.ToArray());
            string newUsername1 = temp_username1_line + "-" + username2;
            File.AppendAllText(@"../../friendlist-db.txt", newUsername1 + Environment.NewLine);
            string newUsername2 = temp_username2_line + "-" + username1;
            File.AppendAllText(@"../../friendlist-db.txt", newUsername2 + Environment.NewLine);

        }
        private void edit_single_Line(string username1, string username2)
        {
            int i = 0;
            int username1_index = 0;
            string temp_username1_line = "";
            List<string> linesList = File.ReadAllLines(@"../../friendlist-db.txt").ToList();
            foreach (var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username1 == lineData[0])
                {
                    username1_index = i;
                    temp_username1_line = item;

                }
                i++;
            }
            linesList.RemoveAt(username1_index);
            File.WriteAllLines((@"../../friendlist-db.txt"), linesList.ToArray());
            string newUsername1 = temp_username1_line + "-" + username2;
            File.AppendAllText(@"../../friendlist-db.txt", newUsername1 + Environment.NewLine);
        }
        private void fulldelete_single_Line(string username1, string username2)
        {
            int i = 0;
            int username1_index = 0;
            int username2_index = 0;
            string temp_username2_line = "";
            List<string> linesList = File.ReadAllLines(@"../../friendlist-db.txt").ToList();
            foreach (var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username1 == lineData[0])
                {
                    username1_index = i;

                }
                i++;
            }
            linesList.RemoveAt(username1_index);
            int j = 0;
            foreach (var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username2 == lineData[0])
                {
                    username2_index = j;
                    temp_username2_line = item;
                }
                j++;
            }
            linesList.RemoveAt(username2_index);
            File.WriteAllLines((@"../../friendlist-db.txt"), linesList.ToArray());
            string newUsername2 = temp_username2_line;
            int delete_word_index = newUsername2.IndexOf(username1);
            int delete_word_length = username1.Length;
            if(delete_word_index+delete_word_length==newUsername2.Length)
            {
                newUsername2 = newUsername2.Remove(delete_word_index - 1, delete_word_length + 1);
            }
            else
            {
                newUsername2 = newUsername2.Remove(delete_word_index, delete_word_length + 1);
            }
            File.AppendAllText(@"../../friendlist-db.txt", newUsername2 + Environment.NewLine);

        }
        private void fulldelete_both_Line(string username1, string username2)
        {
            int i = 0;
            int username1_index = 0;
            int username2_index = 0;
            List<string> linesList = File.ReadAllLines(@"../../friendlist-db.txt").ToList();
            foreach (var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username1 == lineData[0])
                {
                    username1_index = i;

                }
                i++;
            }

            linesList.RemoveAt(username1_index);
            int j = 0;
            foreach (var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username2 == lineData[0])
                {
                    username2_index = j;
                }
                j++;
            }
            linesList.RemoveAt(username2_index);
            File.WriteAllLines((@"../../friendlist-db.txt"), linesList.ToArray());
        }
        private void fulldelete_none_Line(string username1, string username2)
        {
            int i = 0;
            int username1_index = 0;
            int username2_index = 0;
            string temp_username1_line = "";
            string temp_username2_line = "";
            List<string> linesList = File.ReadAllLines(@"../../friendlist-db.txt").ToList();
            foreach (var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username1 == lineData[0])
                {
                    username1_index = i;
                    temp_username1_line = item;

                }
                i++;
            }
            linesList.RemoveAt(username1_index);
            int j = 0;
            foreach (var item in linesList)
            {
                string[] lineData = item.Split('|');
                if (username2 == lineData[0])
                {
                    username2_index = j;
                    temp_username2_line = item;
                }
                j++;
            }
            linesList.RemoveAt(username2_index);
            File.WriteAllLines((@"../../friendlist-db.txt"), linesList.ToArray());
            string newUsername1 = temp_username1_line;
            string newUsername2 = temp_username2_line;
            int delete_word_index2 = newUsername2.IndexOf(username1);
            int delete_word_length2 = username1.Length;
            if (delete_word_index2 + delete_word_length2 == newUsername2.Length)
            {
                newUsername2 = newUsername2.Remove(delete_word_index2 - 1, delete_word_length2 + 1);
            }
            else
            {
                newUsername2 = newUsername2.Remove(delete_word_index2, delete_word_length2 + 1);
            }
            File.AppendAllText(@"../../friendlist-db.txt", newUsername2 + Environment.NewLine);
            int delete_word_index1 = newUsername1.IndexOf(username2);
            int delete_word_length1 = username2.Length;
            if (delete_word_index1 + delete_word_length1 == newUsername1.Length)
            {
                newUsername1 = newUsername1.Remove(delete_word_index1 - 1, delete_word_length1 + 1);
            }
            else
            {
                newUsername1 = newUsername1.Remove(delete_word_index1, delete_word_length1 + 1);
            }
            File.AppendAllText(@"../../friendlist-db.txt", newUsername1 + Environment.NewLine);

        }
    }
}

