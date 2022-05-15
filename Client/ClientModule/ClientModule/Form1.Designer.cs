
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
            this.postTextBox.Location = new System.Drawing.Point(115, 236);
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
            this.label4.Location = new System.Drawing.Point(62, 238);
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
            this.send_button.Location = new System.Drawing.Point(296, 230);
            this.send_button.Margin = new System.Windows.Forms.Padding(2);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(63, 27);
            this.send_button.TabIndex = 10;
            this.send_button.Text = "Send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // allposts_button
            // 
            this.allposts_button.Enabled = false;
            this.allposts_button.Location = new System.Drawing.Point(331, 323);
            this.allposts_button.Margin = new System.Windows.Forms.Padding(2);
            this.allposts_button.Name = "allposts_button";
            this.allposts_button.Size = new System.Drawing.Size(62, 27);
            this.allposts_button.TabIndex = 11;
            this.allposts_button.Text = "All Posts";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 410);
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
            this.Text = "Form1";
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
    }
}

