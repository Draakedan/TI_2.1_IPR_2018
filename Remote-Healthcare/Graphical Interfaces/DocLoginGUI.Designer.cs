namespace Remote_Healthcare
{
    partial class DoctorInput
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
            this.usernameText = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.createNewAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.usernameText.Location = new System.Drawing.Point(113, 11);
            this.usernameText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(177, 23);
            this.usernameText.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.DarkGray;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.okButton.Location = new System.Drawing.Point(33, 84);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 31);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Login";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DarkGray;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.cancelButton.Location = new System.Drawing.Point(204, 118);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 31);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.passwordText.Location = new System.Drawing.Point(113, 48);
            this.passwordText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.Size = new System.Drawing.Size(177, 23);
            this.passwordText.TabIndex = 1;
            // 
            // createNewAccount
            // 
            this.createNewAccount.BackColor = System.Drawing.Color.DarkGray;
            this.createNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createNewAccount.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.createNewAccount.Location = new System.Drawing.Point(113, 84);
            this.createNewAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createNewAccount.Name = "createNewAccount";
            this.createNewAccount.Size = new System.Drawing.Size(179, 30);
            this.createNewAccount.TabIndex = 3;
            this.createNewAccount.Text = "Create new account";
            this.createNewAccount.UseVisualStyleBackColor = false;
            this.createNewAccount.Click += new System.EventHandler(this.createNewAccount_Click);
            // 
            // DoctorInput
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(340, 197);
            this.ControlBox = false;
            this.Controls.Add(this.createNewAccount);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.usernameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button createNewAccount;
    }
}