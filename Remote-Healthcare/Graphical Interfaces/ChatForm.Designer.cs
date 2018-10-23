namespace Remote_Healthcare.Graphical_Interfaces
{
    partial class ChatForm
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
            this.SendButton = new System.Windows.Forms.Button();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.ChatLogTextBox = new System.Windows.Forms.TextBox();
            this.broadcastButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.DarkGray;
            this.SendButton.FlatAppearance.BorderSize = 0;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.SendButton.Location = new System.Drawing.Point(382, 288);
            this.SendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(101, 25);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ChatTextBox.Location = new System.Drawing.Point(22, 288);
            this.ChatTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(356, 23);
            this.ChatTextBox.TabIndex = 0;
            // 
            // ChatLogTextBox
            // 
            this.ChatLogTextBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ChatLogTextBox.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ChatLogTextBox.Location = new System.Drawing.Point(22, 21);
            this.ChatLogTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatLogTextBox.Multiline = true;
            this.ChatLogTextBox.Name = "ChatLogTextBox";
            this.ChatLogTextBox.ReadOnly = true;
            this.ChatLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatLogTextBox.Size = new System.Drawing.Size(460, 242);
            this.ChatLogTextBox.TabIndex = 2;
            // 
            // broadcastButton
            // 
            this.broadcastButton.BackColor = System.Drawing.Color.DarkGray;
            this.broadcastButton.FlatAppearance.BorderSize = 0;
            this.broadcastButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.broadcastButton.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.broadcastButton.ForeColor = System.Drawing.Color.Black;
            this.broadcastButton.Location = new System.Drawing.Point(382, 318);
            this.broadcastButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.broadcastButton.Name = "broadcastButton";
            this.broadcastButton.Size = new System.Drawing.Size(101, 26);
            this.broadcastButton.TabIndex = 2;
            this.broadcastButton.Text = "Broadcast";
            this.broadcastButton.UseVisualStyleBackColor = false;
            this.broadcastButton.Click += new System.EventHandler(this.broadcastButton_Click);
            // 
            // ChatForm
            // 
            this.AcceptButton = this.SendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(509, 370);
            this.Controls.Add(this.broadcastButton);
            this.Controls.Add(this.ChatLogTextBox);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.SendButton);
            this.Location = new System.Drawing.Point(800, 300);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ChatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.TextBox ChatLogTextBox;
        private System.Windows.Forms.Button broadcastButton;
    }
}