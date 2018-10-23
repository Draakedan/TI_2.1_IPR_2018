using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Healthcare
{
    public partial class GraphCustomControll : UserControl
    {
        public string GraphName { get; }

        public GraphCustomControll(string GraphName)
        {
            InitializeComponent();
            //this.GraphName = GraphName;
            //ChangeGraphStye();
            //GraphicChart.Update();
        }

        private void ChangeGraphStye()
        {
            GraphicChart.ChartAreas[0].AxisY.ScaleView.Zoom(-15, 15);
            GraphicChart.ChartAreas[0].AxisX.ScaleView.Zoom(-15, 2);
            GraphicChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            GraphicChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            GraphicChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
        }

        public void AddData(double x, double y)
        {
            GraphicChart.Series[0].Points.AddXY(x, y);
            GraphicChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

    }
}
