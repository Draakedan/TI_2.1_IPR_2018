namespace Remote_Healthcare.Graphical_Interfaces
{
    partial class PatientData
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
            this.patientName = new System.Windows.Forms.TextBox();
            this.historicData = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // patientName
            // 
            this.patientName.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.patientName.Location = new System.Drawing.Point(290, 16);
            this.patientName.Name = "patientName";
            this.patientName.Size = new System.Drawing.Size(318, 23);
            this.patientName.TabIndex = 0;
            // 
            // historicData
            // 
            this.historicData.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.historicData.Location = new System.Drawing.Point(12, 86);
            this.historicData.Name = "historicData";
            this.historicData.ReadOnly = true;
            this.historicData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.historicData.Size = new System.Drawing.Size(703, 343);
            this.historicData.TabIndex = 1;
            this.historicData.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter the required patient name here:";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.DarkGray;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.searchButton.Location = new System.Drawing.Point(625, 14);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(90, 27);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Historic patient data:";
            // 
            // PatientData
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(731, 446);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.historicData);
            this.Controls.Add(this.patientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientData";
            this.Text = "PatientData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox patientName;
        private System.Windows.Forms.RichTextBox historicData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label2;
    }
}