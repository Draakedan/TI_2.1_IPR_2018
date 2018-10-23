namespace Remote_Healthcare
{
    partial class GraphCustomControll
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GraphicChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicChart)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphicChart
            // 
            chartArea1.Name = "ChartArea1";
            this.GraphicChart.ChartAreas.Add(chartArea1);
            this.GraphicChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.GraphicChart.Legends.Add(legend1);
            this.GraphicChart.Location = new System.Drawing.Point(0, 0);
            this.GraphicChart.Name = "GraphicChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Speed";
            this.GraphicChart.Series.Add(series1);
            this.GraphicChart.Size = new System.Drawing.Size(739, 404);
            this.GraphicChart.TabIndex = 0;
            this.GraphicChart.Text = "chart1";
            // 
            // GraphCustomControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GraphicChart);
            this.Name = "GraphCustomControll";
            this.Size = new System.Drawing.Size(739, 404);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GraphicChart;
    }
}
