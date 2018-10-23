namespace Remote_Healthcare
{
    partial class DocGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param bikeID="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.getPatientData = new System.Windows.Forms.Button();
            this.addPatientButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.GraphsButton = new System.Windows.Forms.Button();
            this.BycicleButton = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BicyclePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.getPatientData);
            this.panel7.Controls.Add(this.addPatientButton);
            this.panel7.Controls.Add(this.RefreshButton);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.GraphsButton);
            this.panel7.Controls.Add(this.BycicleButton);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(249, 813);
            this.panel7.TabIndex = 1;
            // 
            // getPatientData
            // 
            this.getPatientData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.getPatientData.FlatAppearance.BorderSize = 0;
            this.getPatientData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getPatientData.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.getPatientData.ForeColor = System.Drawing.Color.White;
            this.getPatientData.Location = new System.Drawing.Point(21, 160);
            this.getPatientData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.getPatientData.Name = "getPatientData";
            this.getPatientData.Size = new System.Drawing.Size(171, 43);
            this.getPatientData.TabIndex = 7;
            this.getPatientData.Text = "Patient Data";
            this.getPatientData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.getPatientData.UseVisualStyleBackColor = false;
            this.getPatientData.Click += new System.EventHandler(this.getPatientData_Click);
            // 
            // addPatientButton
            // 
            this.addPatientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addPatientButton.FlatAppearance.BorderSize = 0;
            this.addPatientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPatientButton.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.addPatientButton.ForeColor = System.Drawing.Color.White;
            this.addPatientButton.Location = new System.Drawing.Point(21, 392);
            this.addPatientButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Size = new System.Drawing.Size(171, 43);
            this.addPatientButton.TabIndex = 6;
            this.addPatientButton.Text = "Add Patient";
            this.addPatientButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addPatientButton.UseVisualStyleBackColor = false;
            this.addPatientButton.Click += new System.EventHandler(this.addPatientButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.Location = new System.Drawing.Point(21, 442);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(175, 33);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Visible = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "RemoteHealthCare";
            // 
            // panel9
            // 
            this.panel9.AccessibleName = "";
            this.panel9.BackColor = System.Drawing.Color.Firebrick;
            this.panel9.Location = new System.Drawing.Point(0, 80);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(15, 59);
            this.panel9.TabIndex = 3;
            // 
            // GraphsButton
            // 
            this.GraphsButton.FlatAppearance.BorderSize = 0;
            this.GraphsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GraphsButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphsButton.ForeColor = System.Drawing.Color.White;
            this.GraphsButton.Location = new System.Drawing.Point(21, 120);
            this.GraphsButton.Name = "GraphsButton";
            this.GraphsButton.Size = new System.Drawing.Size(175, 33);
            this.GraphsButton.TabIndex = 3;
            this.GraphsButton.Text = "Graphs";
            this.GraphsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GraphsButton.UseVisualStyleBackColor = true;
            this.GraphsButton.Click += new System.EventHandler(this.GraphsButton_Click);
            // 
            // BycicleButton
            // 
            this.BycicleButton.FlatAppearance.BorderSize = 0;
            this.BycicleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BycicleButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BycicleButton.ForeColor = System.Drawing.Color.White;
            this.BycicleButton.Location = new System.Drawing.Point(21, 80);
            this.BycicleButton.Name = "BycicleButton";
            this.BycicleButton.Size = new System.Drawing.Size(175, 31);
            this.BycicleButton.TabIndex = 2;
            this.BycicleButton.Text = "Bicycles";
            this.BycicleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BycicleButton.UseVisualStyleBackColor = true;
            this.BycicleButton.Click += new System.EventHandler(this.BycicleButton_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Firebrick;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(249, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1255, 17);
            this.panel8.TabIndex = 2;
            // 
            // BicyclePanel
            // 
            this.BicyclePanel.AutoScroll = true;
            this.BicyclePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BicyclePanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BicyclePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BicyclePanel.Location = new System.Drawing.Point(249, 17);
            this.BicyclePanel.Margin = new System.Windows.Forms.Padding(0);
            this.BicyclePanel.Name = "BicyclePanel";
            this.BicyclePanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BicyclePanel.Size = new System.Drawing.Size(1255, 796);
            this.BicyclePanel.TabIndex = 3;
            this.BicyclePanel.WrapContents = false;
            this.BicyclePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BicyclePanel_Paint);
            // 
            // GraphPanel
            // 
            this.GraphPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GraphPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.GraphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphPanel.Location = new System.Drawing.Point(184, 14);
            this.GraphPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GraphPanel.Size = new System.Drawing.Size(937, 535);
            this.GraphPanel.TabIndex = 3;
            this.GraphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            // 
            // DocGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 813);
            this.Controls.Add(this.BicyclePanel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DocGUI";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BycicleButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button GraphsButton;
        private System.Windows.Forms.Panel panel8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.FlowLayoutPanel BicyclePanel;
        private System.Windows.Forms.Panel GraphPanel;
        private System.Windows.Forms.Button addPatientButton;
        private System.Windows.Forms.Button getPatientData;
        
    }
}