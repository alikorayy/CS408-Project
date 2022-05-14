
namespace ServerModule
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
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.serverConsole = new System.Windows.Forms.RichTextBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(83, 28);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(163, 20);
            this.portTextBox.TabIndex = 0;
            // 
            // labelPort
            // 
            this.labelPort.Location = new System.Drawing.Point(0, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(100, 23);
            this.labelPort.TabIndex = 5;
            // 
            // serverConsole
            // 
            this.serverConsole.Location = new System.Drawing.Point(37, 88);
            this.serverConsole.Name = "serverConsole";
            this.serverConsole.Size = new System.Drawing.Size(506, 197);
            this.serverConsole.TabIndex = 4;
            this.serverConsole.Text = "";
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(266, 18);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(121, 38);
            this.buttonListen.TabIndex = 3;
            this.buttonListen.Text = "Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.serverConsole);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.portTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.RichTextBox serverConsole;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Label label1;
    }
}

