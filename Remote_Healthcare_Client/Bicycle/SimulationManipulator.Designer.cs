namespace Remote_Healthcare_Client.Bicycle
{
    partial class SimulationManipulator
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
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.lblTime = new System.Windows.Forms.Label();
            this.trbTime = new System.Windows.Forms.TrackBar();
            this.trbEnergy = new System.Windows.Forms.TrackBar();
            this.trbPower = new System.Windows.Forms.TrackBar();
            this.trbDistance = new System.Windows.Forms.TrackBar();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(11, 14);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(62, 18);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "Rpm (0)";
            // 
            // trbSpeed
            // 
            this.trbSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbSpeed.Location = new System.Drawing.Point(91, 14);
            this.trbSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trbSpeed.Maximum = 200;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(390, 48);
            this.trbSpeed.TabIndex = 3;
            this.trbSpeed.Scroll += new System.EventHandler(this.trbSpeed_Scroll);
            this.trbSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbSpeed_MouseUp);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(11, 86);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(63, 18);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time (0)";
            // 
            // trbTime
            // 
            this.trbTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbTime.Location = new System.Drawing.Point(91, 86);
            this.trbTime.Margin = new System.Windows.Forms.Padding(2);
            this.trbTime.Maximum = 200;
            this.trbTime.Name = "trbTime";
            this.trbTime.Size = new System.Drawing.Size(390, 48);
            this.trbTime.TabIndex = 7;
            this.trbTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbTime_MouseUp);
            // 
            // trbEnergy
            // 
            this.trbEnergy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbEnergy.Location = new System.Drawing.Point(91, 155);
            this.trbEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.trbEnergy.Maximum = 200;
            this.trbEnergy.Name = "trbEnergy";
            this.trbEnergy.Size = new System.Drawing.Size(390, 48);
            this.trbEnergy.TabIndex = 8;
            this.trbEnergy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbEnergy_MouseUp);
            // 
            // trbPower
            // 
            this.trbPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbPower.Location = new System.Drawing.Point(91, 219);
            this.trbPower.Margin = new System.Windows.Forms.Padding(2);
            this.trbPower.Maximum = 200;
            this.trbPower.Name = "trbPower";
            this.trbPower.Size = new System.Drawing.Size(390, 48);
            this.trbPower.TabIndex = 9;
            this.trbPower.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbPower_MouseUp);
            // 
            // trbDistance
            // 
            this.trbDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbDistance.Location = new System.Drawing.Point(91, 288);
            this.trbDistance.Margin = new System.Windows.Forms.Padding(2);
            this.trbDistance.Maximum = 200;
            this.trbDistance.Name = "trbDistance";
            this.trbDistance.Size = new System.Drawing.Size(390, 48);
            this.trbDistance.TabIndex = 10;
            this.trbDistance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbDistance_MouseUp);
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergy.Location = new System.Drawing.Point(10, 155);
            this.lblEnergy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(76, 18);
            this.lblEnergy.TabIndex = 11;
            this.lblEnergy.Text = "Energy (0)";
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.Location = new System.Drawing.Point(11, 219);
            this.lblPower.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(73, 18);
            this.lblPower.TabIndex = 12;
            this.lblPower.Text = "Power (0)";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(-1, 288);
            this.lblDistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(88, 18);
            this.lblDistance.TabIndex = 14;
            this.lblDistance.Text = "Distance (0)";
            // 
            // SimulationManipulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 490);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.trbDistance);
            this.Controls.Add(this.trbPower);
            this.Controls.Add(this.trbEnergy);
            this.Controls.Add(this.trbTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.trbSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Name = "SimulationManipulator";
            this.Text = "SimulationManipulator";
            this.Load += new System.EventHandler(this.SimulationManipulator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TrackBar trbTime;
        private System.Windows.Forms.TrackBar trbEnergy;
        private System.Windows.Forms.TrackBar trbPower;
        private System.Windows.Forms.TrackBar trbDistance;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Label lblDistance;
    }
}