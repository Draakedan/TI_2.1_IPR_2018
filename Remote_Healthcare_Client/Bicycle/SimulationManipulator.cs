using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Remote_Healthcare_Client.Bicycle;

namespace Remote_Healthcare_Client.Bicycle
{
    public partial class SimulationManipulator : Form
    {
        private SimulatedBike bike;
        public SimulationManipulator(Bike bike)
        {
            InitializeComponent();
            this.bike = (SimulatedBike)bike;
            trbPower.Maximum = 100;
            trbDistance.Maximum = 1000;
            trbTime.Maximum = 3599;
            trbSpeed.Maximum = 100;
        }

        private void trbSpeed_Scroll(object sender, EventArgs e)
        {
            
        }

        private void SimulationManipulator_Load(object sender, EventArgs e)
        {

        }

        private void trbSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            bike.SetSpeed(Convert.ToInt32(trbSpeed.Value));
            lblSpeed.Text = $"Speed ({trbSpeed.Value})";
        }

        private void trbTime_MouseUp(object sender, MouseEventArgs e)
        {
            bike.SetTime(Convert.ToInt32(trbTime.Value));
            lblTime.Text = $"Time ({trbTime.Value})";
        }

        private void trbEnergy_MouseUp(object sender, MouseEventArgs e)
        {
            bike.SetEnergy(Convert.ToInt32(trbEnergy.Value));
            lblEnergy.Text = $"Energy ({trbEnergy.Value})";
        }

        private void trbPower_MouseUp(object sender, MouseEventArgs e)
        {
            bike.SetPower(Convert.ToInt32(trbPower.Value));
            lblPower.Text = $"Power ({trbPower.Value})";
        }

        private void trbDistance_MouseUp(object sender, MouseEventArgs e)
        {
            bike.SetDistance(Convert.ToInt32(trbDistance.Value * 10));
            lblDistance.Text = $"Distance ({trbDistance.Value * 10})";
        }
    }
}
