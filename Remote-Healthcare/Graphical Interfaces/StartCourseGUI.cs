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
            if(startCourseWeightTextfield.Text != String.Empty && startCourseAgeTextfield.Text != String.Empty && startCourseGenderTextfield.Text != String.Empty)
            {
                string age = startCourseAgeTextfield.Text;
                string gender = startCourseGenderTextfield.Text;
                string weight = startCourseWeightTextfield.Text;
                if (Convert.ToInt64(age) < 100 && Convert.ToInt64(gender) < 60 && Convert.ToInt64(weight) < 10000 && Convert.ToInt64(age) > 0 && Convert.ToInt64(gender) > 0 && Convert.ToInt64(weight) > 0)
                {
                    if (gender == "man" || gender == "Man" || gender == "m" || gender == "M" || gender == "gay")
                        bicycleCustomControl.StartCourse(int.Parse(age), 1, double.Parse(weight));
                    else
                        bicycleCustomControl.StartCourse(int.Parse(age), 0, double.Parse(weight));
                    bicycleCustomControl.Enabled = true;
                    this.Dispose();
                }
                else
                {
                    if (Convert.ToInt64(age) > 100 || Convert.ToInt64(age) < 0)
                    {
                        startCourseAgeTextfield.Text = "";
                    }
                    if (Convert.ToInt64(gender) > 100 || Convert.ToInt64(gender) < 0)
                    {
                        startCourseGenderTextfield.Text = "";
                    }
                    if (Convert.ToInt64(weight) > 100 || Convert.ToInt64(weight) < 0)
                    {
                        startCourseWeightTextfield.Text = "";
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

        private void StartCourseGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
