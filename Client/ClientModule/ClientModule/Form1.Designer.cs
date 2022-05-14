
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.username_text = new System.Windows.Forms.TextBox();
            this.post_box = new System.Windows.Forms.TextBox();
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
            this.IP_TextBox.Location = new System.Drawing.Point(153, 43);
            this.IP_TextBox.Name = "IP_TextBox";
            this.IP_TextBox.Size = new System.Drawing.Size(203, 22);
            this.IP_TextBox.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(203, 22);
            this.textBox2.TabIndex = 1;
            // 
            // username_text
            // 
            this.username_text.Location = new System.Drawing.Point(153, 149);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(203, 22);
            this.username_text.TabIndex = 2;
            // 
            // post_box
            // 
            this.post_box.Enabled = false;
            this.post_box.Location = new System.Drawing.Point(153, 290);
            this.post_box.Name = "post_box";
            this.post_box.Size = new System.Drawing.Size(203, 22);
            this.post_box.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Post:";
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(395, 43);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(112, 34);
            this.connect_button.TabIndex = 8;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Enabled = false;
            this.disconnect_button.Location = new System.Drawing.Point(395, 109);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(112, 36);
            this.disconnect_button.TabIndex = 9;
            this.disconnect_button.Text = "Disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            // 
            // send_button
            // 
            this.send_button.Enabled = false;
            this.send_button.Location = new System.Drawing.Point(395, 283);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(84, 33);
            this.send_button.TabIndex = 10;
            this.send_button.Text = "Send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // allposts_button
            // 
            this.allposts_button.Enabled = false;
            this.allposts_button.Location = new System.Drawing.Point(441, 398);
            this.allposts_button.Name = "allposts_button";
            this.allposts_button.Size = new System.Drawing.Size(82, 33);
            this.allposts_button.TabIndex = 11;
            this.allposts_button.Text = "All Posts";
            this.allposts_button.UseVisualStyleBackColor = true;
            // 
            // client_log
            // 
            this.client_log.Location = new System.Drawing.Point(571, 48);
            this.client_log.Name = "client_log";
            this.client_log.ReadOnly = true;
            this.client_log.Size = new System.Drawing.Size(278, 383);
            this.client_log.TabIndex = 12;
            this.client_log.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 505);
            this.Controls.Add(this.client_log);
            this.Controls.Add(this.allposts_button);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.post_box);
            this.Controls.Add(this.username_text);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.IP_TextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP_TextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.TextBox post_box;
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

