using Remote_Healthcare.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Healthcare
{
    partial class StartCourseGUI : Form
    {
        BicycleCustomControl bicycleCustomControl;

        public StartCourseGUI(BicycleCustomControl bicycleCustomControl)
        {
            InitializeComponent();
            this.bicycleCustomControl = bicycleCustomControl;
            usernameLabel.Text = bicycleCustomControl.patientnaam;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(startCourseDistanceTextfield.Text != String.Empty && startCoursePowerTextfield.Text != String.Empty && startCourseTimeTextfield.Text != String.Empty)
            {
                string power = startCoursePowerTextfield.Text;
                string time = startCourseTimeTextfield.Text;
                string distance = startCourseDistanceTextfield.Text;
                if (Convert.ToInt64(power) < 100 && Convert.ToInt64(time) < 60 && Convert.ToInt64(distance) < 10000 && Convert.ToInt64(power) > 0 && Convert.ToInt64(time) > 0 && Convert.ToInt64(distance) > 0)
                {
                    bicycleCustomControl.StartCourse(double.Parse(power), double.Parse(time) * 60, double.Parse(distance));
                    bicycleCustomControl.Enabled = true;
                    this.Dispose();
                }
                else
                {
                    if (Convert.ToInt64(power) > 100 || Convert.ToInt64(power) < 0)
                    {
                        startCoursePowerTextfield.Text = "";
                    }
                    if (Convert.ToInt64(time) > 100 || Convert.ToInt64(time) < 0)
                    {
                        startCourseTimeTextfield.Text = "";
                    }
                    if (Convert.ToInt64(distance) > 100 || Convert.ToInt64(distance) < 0)
                    {
                        startCourseDistanceTextfield.Text = "";
                    }
                    MessageBox.Show("Niet alle velden zijn juist ingevuld,\r\n100 is de maximale waarde");
                }
            }
            else
            {
                MessageBox.Show("Niet alle velden zijn juist ingevuld,\r\n100 is de maximale waarde");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bicycleCustomControl.Enabled = true;
            this.Dispose();
        }
    }
}
