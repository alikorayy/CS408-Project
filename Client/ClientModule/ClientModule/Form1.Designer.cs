
namespace ClientModule
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IP_TextBox = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.username_text = new System.Windows.Forms.TextBox();
            this.postTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.connect_button = new System.Windows.Forms.Button();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.send_button = new System.Windows.Forms.Button();
            this.allposts_button = new System.Windows.Forms.Button();
            this.client_log = new System.Windows.Forms.RichTextBox();
            this.friendlist_box = new System.Windows.Forms.ListBox();
            this.username2_text = new System.Windows.Forms.TextBox();
            this.addfriend_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.postID_Text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.delete_button = new System.Windows.Forms.Button();
            this.mypost_button = new System.Windows.Forms.Button();
            this.friendpost_button = new System.Windows.Forms.Button();
            this.removefriend_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IP_TextBox
            // 
            this.IP_TextBox.Location = new System.Drawing.Point(115, 35);
            this.IP_TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IP_TextBox.Name = "IP_TextBox";
            this.IP_TextBox.Size = new System.Drawing.Size(153, 20);
            this.IP_TextBox.TabIndex = 0;
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(115, 72);
            this.portText.Margin = new System.Windows.Forms.Padding(2);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(153, 20);
            this.portText.TabIndex = 1;
            // 
            // username_text
            // 
            this.username_text.Location = new System.Drawing.Point(115, 121);
            this.username_text.Margin = new System.Windows.Forms.Padding(2);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(153, 20);
            this.username_text.TabIndex = 2;
            // 
            // postTextBox
            // 
            this.postTextBox.Enabled = false;
            this.postTextBox.Location = new System.Drawing.Point(115, 349);
            this.postTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.postTextBox.Name = "postTextBox";
            this.postTextBox.Size = new System.Drawing.Size(153, 20);
            this.postTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 352);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Post:";
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(296, 35);
            this.connect_button.Margin = new System.Windows.Forms.Padding(2);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(84, 28);
            this.connect_button.TabIndex = 8;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Enabled = false;
            this.disconnect_button.Location = new System.Drawing.Point(296, 89);
            this.disconnect_button.Margin = new System.Windows.Forms.Padding(2);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(84, 29);
            this.disconnect_button.TabIndex = 9;
            this.disconnect_button.Text = "Disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.disconnect_button_Click);
            // 
            // send_button
            // 
            this.send_button.Enabled = false;
            this.send_button.Location = new System.Drawing.Point(296, 345);
            this.send_button.Margin = new System.Windows.Forms.Padding(2);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(84, 27);
            this.send_button.TabIndex = 10;
            this.send_button.Text = "Send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // allposts_button
            // 
            this.allposts_button.Enabled = false;
            this.allposts_button.Location = new System.Drawing.Point(428, 372);
            this.allposts_button.Margin = new System.Windows.Forms.Padding(2);
            this.allposts_button.Name = "allposts_button";
            this.allposts_button.Size = new System.Drawing.Size(57, 50);
            this.allposts_button.TabIndex = 11;
            this.allposts_button.Text = "All  Posts";
            this.allposts_button.UseVisualStyleBackColor = true;
            this.allposts_button.Click += new System.EventHandler(this.allposts_button_Click);
            // 
            // client_log
            // 
            this.client_log.Location = new System.Drawing.Point(428, 39);
            this.client_log.Margin = new System.Windows.Forms.Padding(2);
            this.client_log.Name = "client_log";
            this.client_log.ReadOnly = true;
            this.client_log.Size = new System.Drawing.Size(210, 312);
            this.client_log.TabIndex = 12;
            this.client_log.Text = "";
            // 
            // friendlist_box
            // 
            this.friendlist_box.FormattingEnabled = true;
            this.friendlist_box.Location = new System.Drawing.Point(115, 166);
            this.friendlist_box.Name = "friendlist_box";
            this.friendlist_box.Size = new System.Drawing.Size(153, 108);
            this.friendlist_box.TabIndex = 13;
            // 
            // username2_text
            // 
            this.username2_text.Enabled = false;
            this.username2_text.Location = new System.Drawing.Point(115, 301);
            this.username2_text.Margin = new System.Windows.Forms.Padding(2);
            this.username2_text.Name = "username2_text";
            this.username2_text.Size = new System.Drawing.Size(153, 20);
            this.username2_text.TabIndex = 14;
            // 
            // addfriend_button
            // 
            this.addfriend_button.Enabled = false;
            this.addfriend_button.Location = new System.Drawing.Point(296, 297);
            this.addfriend_button.Margin = new System.Windows.Forms.Padding(2);
            this.addfriend_button.Name = "addfriend_button";
            this.addfriend_button.Size = new System.Drawing.Size(84, 27);
            this.addfriend_button.TabIndex = 15;
            this.addfriend_button.Text = "Add Friend";
            this.addfriend_button.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 304);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Username:";
            // 
            // postID_Text
            // 
            this.postID_Text.Enabled = false;
            this.postID_Text.Location = new System.Drawing.Point(115, 398);
            this.postID_Text.Margin = new System.Windows.Forms.Padding(2);
            this.postID_Text.Name = "postID_Text";
            this.postID_Text.Size = new System.Drawing.Size(153, 20);
            this.postID_Text.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 401);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Post ID:";
            // 
            // delete_button
            // 
            this.delete_button.Enabled = false;
            this.delete_button.Location = new System.Drawing.Point(296, 394);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(84, 27);
            this.delete_button.TabIndex = 19;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // mypost_button
            // 
            this.mypost_button.Enabled = false;
            this.mypost_button.Location = new System.Drawing.Point(505, 372);
            this.mypost_button.Margin = new System.Windows.Forms.Padding(2);
            this.mypost_button.Name = "mypost_button";
            this.mypost_button.Size = new System.Drawing.Size(57, 50);
            this.mypost_button.TabIndex = 20;
            this.mypost_button.Text = "My Posts";
            this.mypost_button.UseVisualStyleBackColor = true;
            this.mypost_button.Click += new System.EventHandler(this.mypost_button_Click);
            // 
            // friendpost_button
            // 
            this.friendpost_button.Enabled = false;
            this.friendpost_button.Location = new System.Drawing.Point(581, 372);
            this.friendpost_button.Margin = new System.Windows.Forms.Padding(2);
            this.friendpost_button.Name = "friendpost_button";
            this.friendpost_button.Size = new System.Drawing.Size(57, 50);
            this.friendpost_button.TabIndex = 21;
            this.friendpost_button.Text = "Friend\'s Posts";
            this.friendpost_button.UseVisualStyleBackColor = true;
            // 
            // removefriend_button
            // 
            this.removefriend_button.Enabled = false;
            this.removefriend_button.Location = new System.Drawing.Point(296, 185);
            this.removefriend_button.Margin = new System.Windows.Forms.Padding(2);
            this.removefriend_button.Name = "removefriend_button";
            this.removefriend_button.Size = new System.Drawing.Size(84, 61);
            this.removefriend_button.TabIndex = 22;
            this.removefriend_button.Text = "Remove Friend";
            this.removefriend_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 458);
            this.Controls.Add(this.removefriend_button);
            this.Controls.Add(this.friendpost_button);
            this.Controls.Add(this.mypost_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.postID_Text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addfriend_button);
            this.Controls.Add(this.username2_text);
            this.Controls.Add(this.friendlist_box);
            this.Controls.Add(this.client_log);
            this.Controls.Add(this.allposts_button);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postTextBox);
            this.Controls.Add(this.username_text);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.IP_TextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "*/";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP_TextBox;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.TextBox postTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button disconnect_button;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Button allposts_button;
        private System.Windows.Forms.RichTextBox client_log;
        private System.Windows.Forms.ListBox friendlist_box;
        private System.Windows.Forms.TextBox username2_text;
        private System.Windows.Forms.Button addfriend_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox postID_Text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button mypost_button;
        private System.Windows.Forms.Button friendpost_button;
        private System.Windows.Forms.Button removefriend_button;
    }
}

