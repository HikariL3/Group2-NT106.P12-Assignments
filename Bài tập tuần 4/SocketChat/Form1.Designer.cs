
namespace SocketChat
{
    partial class Server
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
            this.Message = new System.Windows.Forms.RichTextBox();
            this.Send = new System.Windows.Forms.Button();
            this.Click = new System.Windows.Forms.Button();
            this.IP_Address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Send_File = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(16, 41);
            this.Message.Margin = new System.Windows.Forms.Padding(4);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(501, 266);
            this.Message.TabIndex = 0;
            this.Message.Text = "";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(16, 316);
            this.Send.Margin = new System.Windows.Forms.Padding(4);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(503, 57);
            this.Send.TabIndex = 1;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            // 
            // Click
            // 
            this.Click.Location = new System.Drawing.Point(376, 2);
            this.Click.Margin = new System.Windows.Forms.Padding(4);
            this.Click.Name = "Click";
            this.Click.Size = new System.Drawing.Size(100, 28);
            this.Click.TabIndex = 2;
            this.Click.Text = "Listen";
            this.Click.UseVisualStyleBackColor = true;
            this.Click.Click += new System.EventHandler(this.button2_Click);
            // 
            // IP_Address
            // 
            this.IP_Address.Location = new System.Drawing.Point(93, 6);
            this.IP_Address.Margin = new System.Windows.Forms.Padding(4);
            this.IP_Address.Name = "IP_Address";
            this.IP_Address.Size = new System.Drawing.Size(273, 22);
            this.IP_Address.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP";
            // 
            // Send_File
            // 
            this.Send_File.Location = new System.Drawing.Point(13, 381);
            this.Send_File.Margin = new System.Windows.Forms.Padding(4);
            this.Send_File.Name = "Send_File";
            this.Send_File.Size = new System.Drawing.Size(503, 57);
            this.Send_File.TabIndex = 5;
            this.Send_File.Text = "SendFile";
            this.Send_File.UseVisualStyleBackColor = true;
            this.Send_File.Click += new System.EventHandler(this.Send_File_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 446);
            this.Controls.Add(this.Send_File);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP_Address);
            this.Controls.Add(this.Click);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Message);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Server";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Message;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Click;
        private System.Windows.Forms.TextBox IP_Address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Send_File;
    }
}

