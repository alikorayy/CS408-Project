
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
            this.portTextBox.Location = new System.Drawing.Point(111, 34);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(216, 22);
            this.portTextBox.TabIndex = 0;
            // 
            // labelPort
            // 
            this.labelPort.Location = new System.Drawing.Point(0, 0);
            this.labelPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(133, 28);
            this.labelPort.TabIndex = 5;
            // 
            // serverConsole
            // 
            this.serverConsole.Location = new System.Drawing.Point(49, 108);
            this.serverConsole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serverConsole.Name = "serverConsole";
            this.serverConsole.ReadOnly = true;
            this.serverConsole.Size = new System.Drawing.Size(673, 242);
            this.serverConsole.TabIndex = 4;
            this.serverConsole.Text = "";
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(355, 22);
            this.buttonListen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(161, 47);
            this.buttonListen.TabIndex = 3;
            this.buttonListen.Text = "Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.serverConsole);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.portTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
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

