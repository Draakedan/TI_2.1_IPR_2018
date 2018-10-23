using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Remote_Healthcare.Bicycle;

namespace Remote_Healthcare.Graphical_Interfaces
{
    public partial class SimulationManipulator : Form
    {
        private SimulatedBike bike;
        public SimulationManipulator(Bike bike)
        {
            InitializeComponent();
            this.bike = (SimulatedBike)bike;
        }

        private void trbSpeed_Scroll(object sender, EventArgs e)
        {
            bike.SetSpeed(Convert.ToInt32(trbSpeed.Value));
            //lblSpeedValue.Text = trbSpeed.Value.ToString();
            lblSpeed.Text = $"Speed ({trbSpeed.Value})";
        }

        private void SimulationManipulator_Load(object sender, EventArgs e)
        {

        }
    }
}
