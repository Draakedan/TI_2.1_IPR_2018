namespace Remote_Healthcare.Graphical_Interfaces
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
            this.lblNoise = new System.Windows.Forms.Label();
            this.trbNoise = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbNoise)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(22, 46);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(132, 31);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "Speed (0)";
            // 
            // trbSpeed
            // 
            this.trbSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbSpeed.Location = new System.Drawing.Point(182, 26);
            this.trbSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.trbSpeed.Maximum = 200;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(374, 90);
            this.trbSpeed.TabIndex = 3;
            this.trbSpeed.Scroll += new System.EventHandler(this.trbSpeed_Scroll);
            // 
            // lblNoise
            // 
            this.lblNoise.AutoSize = true;
            this.lblNoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoise.Location = new System.Drawing.Point(22, 165);
            this.lblNoise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoise.Name = "lblNoise";
            this.lblNoise.Size = new System.Drawing.Size(158, 31);
            this.lblNoise.TabIndex = 6;
            this.lblNoise.Text = "Noise [WIP]";
            // 
            // trbNoise
            // 
            this.trbNoise.Enabled = false;
            this.trbNoise.Location = new System.Drawing.Point(179, 165);
            this.trbNoise.Margin = new System.Windows.Forms.Padding(4);
            this.trbNoise.Name = "trbNoise";
            this.trbNoise.Size = new System.Drawing.Size(358, 90);
            this.trbNoise.TabIndex = 7;
            // 
            // SimulationManipulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 302);
            this.Controls.Add(this.trbNoise);
            this.Controls.Add(this.lblNoise);
            this.Controls.Add(this.trbSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SimulationManipulator";
            this.Text = "SimulationManipulator";
            this.Load += new System.EventHandler(this.SimulationManipulator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbNoise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Label lblNoise;
        private System.Windows.Forms.TrackBar trbNoise;
    }
}