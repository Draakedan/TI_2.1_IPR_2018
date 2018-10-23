namespace Remote_Healthcare.Graphical_Interfaces
{
    partial class AddPatient
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
            this.addPatientButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.getPatientNameTextBox = new System.Windows.Forms.TextBox();
            this.GeenCorrecteNaamLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addPatientButton
            // 
            this.addPatientButton.BackColor = System.Drawing.Color.DarkGray;
            this.addPatientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPatientButton.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.addPatientButton.Location = new System.Drawing.Point(59, 60);
            this.addPatientButton.Margin = new System.Windows.Forms.Padding(4);
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Size = new System.Drawing.Size(100, 28);
            this.addPatientButton.TabIndex = 3;
            this.addPatientButton.Text = "Add patient";
            this.addPatientButton.UseVisualStyleBackColor = false;
            this.addPatientButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DarkGray;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.cancelButton.Location = new System.Drawing.Point(197, 60);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // getPatientNameTextBox
            // 
            this.getPatientNameTextBox.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.getPatientNameTextBox.Location = new System.Drawing.Point(165, 13);
            this.getPatientNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.getPatientNameTextBox.Name = "getPatientNameTextBox";
            this.getPatientNameTextBox.Size = new System.Drawing.Size(132, 23);
            this.getPatientNameTextBox.TabIndex = 0;
            // 
            // GeenCorrecteNaamLabel
            // 
            this.GeenCorrecteNaamLabel.AutoSize = true;
            this.GeenCorrecteNaamLabel.Location = new System.Drawing.Point(83, 92);
            this.GeenCorrecteNaamLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GeenCorrecteNaamLabel.Name = "GeenCorrecteNaamLabel";
            this.GeenCorrecteNaamLabel.Size = new System.Drawing.Size(0, 17);
            this.GeenCorrecteNaamLabel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label1.Location = new System.Drawing.Point(55, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Patient name:";
            // 
            // AddPatient
            // 
            this.AcceptButton = this.addPatientButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(349, 144);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GeenCorrecteNaamLabel);
            this.Controls.Add(this.getPatientNameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addPatientButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add patient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addPatientButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox getPatientNameTextBox;
        private System.Windows.Forms.Label GeenCorrecteNaamLabel;
        private System.Windows.Forms.Label label1;
    }
}