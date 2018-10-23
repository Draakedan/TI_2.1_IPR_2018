namespace Remote_Healthcare
{
    partial class BicycleCustomControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.powerPlus = new System.Windows.Forms.Button();
            this.powerMinus = new System.Windows.Forms.Button();
            this.Chatbutton = new System.Windows.Forms.Button();
            this.bttnStart1 = new System.Windows.Forms.Button();
            this.bttnEnd1 = new System.Windows.Forms.Button();
            this.circlePowerBar = new Remote_Healthcare.CircularProgressBar();
            this.circleSpeedBar = new Remote_Healthcare.CircularProgressBar();
            this.circleDistanceBar = new Remote_Healthcare.CircularProgressBar();
            this.circleTimeBar = new Remote_Healthcare.CircularProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDistance1 = new System.Windows.Forms.Label();
            this.lblTime1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPower1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblusername1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.powerPlus);
            this.panel1.Controls.Add(this.powerMinus);
            this.panel1.Controls.Add(this.Chatbutton);
            this.panel1.Controls.Add(this.bttnStart1);
            this.panel1.Controls.Add(this.bttnEnd1);
            this.panel1.Controls.Add(this.circlePowerBar);
            this.panel1.Controls.Add(this.circleSpeedBar);
            this.panel1.Controls.Add(this.circleDistanceBar);
            this.panel1.Controls.Add(this.circleTimeBar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDistance1);
            this.panel1.Controls.Add(this.lblTime1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblPower1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 779);
            this.panel1.TabIndex = 0;
            // 
            // powerPlus
            // 
            this.powerPlus.BackColor = System.Drawing.Color.DarkGray;
            this.powerPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerPlus.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.powerPlus.Location = new System.Drawing.Point(37, 187);
            this.powerPlus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.powerPlus.Name = "powerPlus";
            this.powerPlus.Size = new System.Drawing.Size(28, 33);
            this.powerPlus.TabIndex = 1;
            this.powerPlus.Text = "+";
            this.powerPlus.UseVisualStyleBackColor = false;
            this.powerPlus.Click += new System.EventHandler(this.powerPlus_Click);
            // 
            // powerMinus
            // 
            this.powerMinus.BackColor = System.Drawing.Color.DarkGray;
            this.powerMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerMinus.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.powerMinus.Location = new System.Drawing.Point(203, 187);
            this.powerMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.powerMinus.Name = "powerMinus";
            this.powerMinus.Size = new System.Drawing.Size(28, 33);
            this.powerMinus.TabIndex = 14;
            this.powerMinus.Text = "-";
            this.powerMinus.UseVisualStyleBackColor = false;
            this.powerMinus.Click += new System.EventHandler(this.powerMinus_Click);
            // 
            // Chatbutton
            // 
            this.Chatbutton.BackColor = System.Drawing.Color.DarkGray;
            this.Chatbutton.FlatAppearance.BorderSize = 0;
            this.Chatbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Chatbutton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chatbutton.Location = new System.Drawing.Point(0, 698);
            this.Chatbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chatbutton.Name = "Chatbutton";
            this.Chatbutton.Size = new System.Drawing.Size(512, 43);
            this.Chatbutton.TabIndex = 2;
            this.Chatbutton.Text = "Chat";
            this.Chatbutton.UseVisualStyleBackColor = false;
            this.Chatbutton.Click += new System.EventHandler(this.chatButton_Click);
            // 
            // bttnStart1
            // 
            this.bttnStart1.BackColor = System.Drawing.Color.DarkGray;
            this.bttnStart1.FlatAppearance.BorderSize = 0;
            this.bttnStart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnStart1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnStart1.Location = new System.Drawing.Point(0, 63);
            this.bttnStart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnStart1.Name = "bttnStart1";
            this.bttnStart1.Size = new System.Drawing.Size(512, 43);
            this.bttnStart1.TabIndex = 0;
            this.bttnStart1.Text = "Start Course";
            this.bttnStart1.UseVisualStyleBackColor = false;
            this.bttnStart1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bttnEnd1
            // 
            this.bttnEnd1.BackColor = System.Drawing.Color.Firebrick;
            this.bttnEnd1.FlatAppearance.BorderSize = 0;
            this.bttnEnd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnEnd1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnEnd1.Location = new System.Drawing.Point(0, 114);
            this.bttnEnd1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnEnd1.Name = "bttnEnd1";
            this.bttnEnd1.Size = new System.Drawing.Size(512, 43);
            this.bttnEnd1.TabIndex = 1;
            this.bttnEnd1.Text = "End Course";
            this.bttnEnd1.UseVisualStyleBackColor = false;
            this.bttnEnd1.Click += new System.EventHandler(this.bttnEnd1_Click);
            // 
            // circlePowerBar
            // 
            this.circlePowerBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circlePowerBar.AnimationSpeed = 500;
            this.circlePowerBar.BackColor = System.Drawing.Color.Transparent;
            this.circlePowerBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.circlePowerBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circlePowerBar.InnerColor = System.Drawing.SystemColors.WindowFrame;
            this.circlePowerBar.InnerMargin = 2;
            this.circlePowerBar.InnerWidth = -1;
            this.circlePowerBar.Location = new System.Drawing.Point(17, 207);
            this.circlePowerBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.circlePowerBar.MarqueeAnimationSpeed = 2000;
            this.circlePowerBar.Name = "circlePowerBar";
            this.circlePowerBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.circlePowerBar.OuterMargin = -25;
            this.circlePowerBar.OuterWidth = 25;
            this.circlePowerBar.ProgressColor = System.Drawing.Color.Blue;
            this.circlePowerBar.ProgressWidth = 20;
            this.circlePowerBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 12.11881F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circlePowerBar.Size = new System.Drawing.Size(233, 215);
            this.circlePowerBar.StartAngle = 270;
            this.circlePowerBar.SubscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circlePowerBar.SubscriptMargin = new System.Windows.Forms.Padding(5, -25, 0, 0);
            this.circlePowerBar.SubscriptText = "";
            this.circlePowerBar.SuperscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circlePowerBar.SuperscriptMargin = new System.Windows.Forms.Padding(20, 35, 0, -25);
            this.circlePowerBar.SuperscriptText = "%";
            this.circlePowerBar.TabIndex = 13;
            this.circlePowerBar.Text = "0";
            this.circlePowerBar.TextMargin = new System.Windows.Forms.Padding(-2, 8, 0, 0);
            this.circlePowerBar.Value = 68;
            // 
            // circleSpeedBar
            // 
            this.circleSpeedBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circleSpeedBar.AnimationSpeed = 500;
            this.circleSpeedBar.BackColor = System.Drawing.Color.Transparent;
            this.circleSpeedBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.circleSpeedBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleSpeedBar.InnerColor = System.Drawing.SystemColors.WindowFrame;
            this.circleSpeedBar.InnerMargin = 2;
            this.circleSpeedBar.InnerWidth = -1;
            this.circleSpeedBar.Location = new System.Drawing.Point(259, 466);
            this.circleSpeedBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.circleSpeedBar.MarqueeAnimationSpeed = 2000;
            this.circleSpeedBar.Name = "circleSpeedBar";
            this.circleSpeedBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.circleSpeedBar.OuterMargin = -25;
            this.circleSpeedBar.OuterWidth = 26;
            this.circleSpeedBar.ProgressColor = System.Drawing.Color.Red;
            this.circleSpeedBar.ProgressWidth = 20;
            this.circleSpeedBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.circleSpeedBar.Size = new System.Drawing.Size(233, 215);
            this.circleSpeedBar.StartAngle = 270;
            this.circleSpeedBar.SubscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleSpeedBar.SubscriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.circleSpeedBar.SubscriptText = ".0";
            this.circleSpeedBar.SuperscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleSpeedBar.SuperscriptMargin = new System.Windows.Forms.Padding(20, 35, 0, -20);
            this.circleSpeedBar.SuperscriptText = "Km/h";
            this.circleSpeedBar.TabIndex = 12;
            this.circleSpeedBar.Text = "0";
            this.circleSpeedBar.TextMargin = new System.Windows.Forms.Padding(-2, 8, 0, 0);
            this.circleSpeedBar.Value = 68;
            // 
            // circleDistanceBar
            // 
            this.circleDistanceBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circleDistanceBar.AnimationSpeed = 500;
            this.circleDistanceBar.BackColor = System.Drawing.Color.Transparent;
            this.circleDistanceBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.circleDistanceBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleDistanceBar.InnerColor = System.Drawing.SystemColors.WindowFrame;
            this.circleDistanceBar.InnerMargin = 2;
            this.circleDistanceBar.InnerWidth = -1;
            this.circleDistanceBar.Location = new System.Drawing.Point(17, 466);
            this.circleDistanceBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.circleDistanceBar.MarqueeAnimationSpeed = 2000;
            this.circleDistanceBar.Name = "circleDistanceBar";
            this.circleDistanceBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.circleDistanceBar.OuterMargin = -25;
            this.circleDistanceBar.OuterWidth = 26;
            this.circleDistanceBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circleDistanceBar.ProgressWidth = 20;
            this.circleDistanceBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.circleDistanceBar.Size = new System.Drawing.Size(233, 215);
            this.circleDistanceBar.StartAngle = 270;
            this.circleDistanceBar.SubscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleDistanceBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -25, 0, 0);
            this.circleDistanceBar.SubscriptText = ".0";
            this.circleDistanceBar.SuperscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleDistanceBar.SuperscriptMargin = new System.Windows.Forms.Padding(20, 35, 0, -25);
            this.circleDistanceBar.SuperscriptText = "Km";
            this.circleDistanceBar.TabIndex = 11;
            this.circleDistanceBar.Text = "0";
            this.circleDistanceBar.TextMargin = new System.Windows.Forms.Padding(-2, 8, 0, 0);
            this.circleDistanceBar.Value = 68;
            // 
            // circleTimeBar
            // 
            this.circleTimeBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circleTimeBar.AnimationSpeed = 500;
            this.circleTimeBar.BackColor = System.Drawing.Color.Transparent;
            this.circleTimeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.circleTimeBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleTimeBar.InnerColor = System.Drawing.SystemColors.WindowFrame;
            this.circleTimeBar.InnerMargin = 2;
            this.circleTimeBar.InnerWidth = -1;
            this.circleTimeBar.Location = new System.Drawing.Point(259, 207);
            this.circleTimeBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.circleTimeBar.MarqueeAnimationSpeed = 2000;
            this.circleTimeBar.Maximum = 3600;
            this.circleTimeBar.Name = "circleTimeBar";
            this.circleTimeBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.circleTimeBar.OuterMargin = -25;
            this.circleTimeBar.OuterWidth = 26;
            this.circleTimeBar.ProgressColor = System.Drawing.Color.Lime;
            this.circleTimeBar.ProgressWidth = 20;
            this.circleTimeBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.circleTimeBar.Size = new System.Drawing.Size(233, 215);
            this.circleTimeBar.StartAngle = 270;
            this.circleTimeBar.SubscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleTimeBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -25, 0, 0);
            this.circleTimeBar.SubscriptText = ".0";
            this.circleTimeBar.SuperscriptColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleTimeBar.SuperscriptMargin = new System.Windows.Forms.Padding(20, 35, 0, -25);
            this.circleTimeBar.SuperscriptText = "Min";
            this.circleTimeBar.TabIndex = 10;
            this.circleTimeBar.Text = "0";
            this.circleTimeBar.TextMargin = new System.Windows.Forms.Padding(-2, 8, 0, 0);
            this.circleTimeBar.Value = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Speed";
            // 
            // lblDistance1
            // 
            this.lblDistance1.AutoSize = true;
            this.lblDistance1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance1.Location = new System.Drawing.Point(84, 439);
            this.lblDistance1.Name = "lblDistance1";
            this.lblDistance1.Size = new System.Drawing.Size(84, 21);
            this.lblDistance1.TabIndex = 7;
            this.lblDistance1.Text = "Distance";
            // 
            // lblTime1
            // 
            this.lblTime1.AutoSize = true;
            this.lblTime1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime1.Location = new System.Drawing.Point(356, 180);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(47, 21);
            this.lblTime1.TabIndex = 6;
            this.lblTime1.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Power";
            // 
            // lblPower1
            // 
            this.lblPower1.AutoSize = true;
            this.lblPower1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower1.Location = new System.Drawing.Point(105, 219);
            this.lblPower1.Name = "lblPower1";
            this.lblPower1.Size = new System.Drawing.Size(61, 21);
            this.lblPower1.TabIndex = 5;
            this.lblPower1.Text = "Power";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.lblusername1);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(508, 63);
            this.panel4.TabIndex = 0;
            // 
            // lblusername1
            // 
            this.lblusername1.AutoSize = true;
            this.lblusername1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername1.Location = new System.Drawing.Point(223, 21);
            this.lblusername1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblusername1.Name = "lblusername1";
            this.lblusername1.Size = new System.Drawing.Size(54, 21);
            this.lblusername1.TabIndex = 0;
            this.lblusername1.Text = "User1";
            // 
            // BicycleCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BicycleCustomControl";
            this.Size = new System.Drawing.Size(512, 755);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblusername1;
        private System.Windows.Forms.Button bttnEnd1;
        private System.Windows.Forms.Button bttnStart1;
        private CircularProgressBar cirpSpeed1;
        private CircularProgressBar cirpDistance1;
        private CircularProgressBar cirpTime1;
        private CircularProgressBar cirpPower1;
        private System.Windows.Forms.Label lblTime1;
        private System.Windows.Forms.Label lblPower1;
        private System.Windows.Forms.Label lblDistance1;
        private CircularProgressBar cirpSpeed2;
        private CircularProgressBar cripDistance2;
        private CircularProgressBar cirpTime2;
        private CircularProgressBar cirpPower2;
        private CircularProgressBar cirpSpeed3;
        private CircularProgressBar cirpDistance3;
        private CircularProgressBar cirpTime3;
        private CircularProgressBar cirpPower3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CircularProgressBar circlePowerBar;
        private CircularProgressBar circleDistanceBar;
        private CircularProgressBar circleTimeBar;
        private CircularProgressBar circleSpeedBar;
        private System.Windows.Forms.Button Chatbutton;
        private System.Windows.Forms.Button powerPlus;
        private System.Windows.Forms.Button powerMinus;
    }
}
