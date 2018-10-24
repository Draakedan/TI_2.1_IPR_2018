using System;
using System.Linq;
using System.Windows.Forms;
using Remote_Healthcare.Client;
using Remote_Healthcare.Graphical_Interfaces;

namespace Remote_Healthcare
{
    partial class BicycleCustomControl : UserControl
    {
        public string bikeID { get; }
        DoctorClient doctorClient;
        public string patientnaam { get; }
        ChatForm chatform;
        
        public BicycleCustomControl(string patientNaam, string bikeID, DoctorClient doctorClient)
        {
            InitializeComponent();
            this.patientnaam = patientNaam;
            bttnEnd1.Enabled = false;

            circleSpeedBar.Value = 0;
            circleTimeBar.Value = 0;
            circlePowerBar.Value = 0;
            circleDistanceBar.Value = 0;

            this.bikeID = bikeID;
            lblusername1.Text = patientNaam;
            this.doctorClient = doctorClient;
        }

        public void SetPatientData(PointOfTime patientData)
        {
            Invoke(new Action(() => {
                Tuple<int, int> values = ConvertDoubleToTuple(patientData.power);
                ChangePower(values.Item1, values.Item2);
                values = ConvertDoubleToTuple(patientData.speed);
                ChangeSpeed(values.Item1, values.Item2);
                values = ConvertDoubleToTuple(patientData.bikeTime);
                ChangeTime(values.Item1, values.Item2);
                values = ConvertDoubleToTuple(patientData.distance);
                ChangeDistance(values.Item1, values.Item2);
            }));
        }

        private Tuple<int, int> ConvertDoubleToTuple(double value)
        {
            int fullvalue;
            int brokenvalue;
            if (!Convert.ToString(value).Contains('.'))
            {
                fullvalue = (int)value;
                brokenvalue = ((int)value - fullvalue) * 100;
                
            } else
            {
                string[] values = Convert.ToString(value).Split('.');
                fullvalue = int.Parse(values[0]);
                brokenvalue = int.Parse(values[1]);
            }
            return new Tuple<int, int>(fullvalue, brokenvalue);

        }
        
        public void ChangePower(int fullValue, int brokenValue)
        {
            circlePowerBar.SubscriptText = $".{brokenValue}";
            circlePowerBar.Text = $"{(fullValue - 25) / 4}";

            if (!((fullValue - 25) / 4 < 0))
                circlePowerBar.Value = (fullValue - 25) / 4;
            else
                circlePowerBar.Value = 0;
            

            circlePowerBar.Update();
        }

        public void ChangeSpeed(int fullValue, int brokenValue)
        {
            circleSpeedBar.SubscriptText = $".{brokenValue}";
            circleSpeedBar.Text = $"{fullValue}";

            if (brokenValue > 50)
                fullValue++;

            circleSpeedBar.Value = fullValue;

            circleSpeedBar.Update();
        }

        public void ChangeDistance(int beforecomma, int aftercomma)
        {
            circleDistanceBar.SubscriptText = $".{aftercomma}";
            circleDistanceBar.Text = $"{beforecomma}";

            circleDistanceBar.Value = beforecomma;

            circleDistanceBar.Update();
        }

        public void ChangeTime(int Minutes, int Seconds)
        {
            circleTimeBar.Text = $"{(int)Math.Floor(Minutes / 60d)}:";
            circleTimeBar.SubscriptText = $"{Minutes % 60}";


            circleTimeBar.Value = Minutes;
            circleTimeBar.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new StartCourseGUI(this).Show();
            this.Enabled = false;
        }

        public void StartCourse(double age, double gender, double weight)
        {
            int fullvalue;
            int brokenvalue;

            ChangeDistance((int)weight, (int) (weight - ((int) weight)) * 10);
            
            fullvalue = (int) age;
            brokenvalue = ((int) age - fullvalue) * 100;
            ChangePower(fullvalue, brokenvalue);

            fullvalue = (int) gender;
            brokenvalue = ((int) gender - fullvalue) * 100;
            ChangeTime(fullvalue, brokenvalue);

            doctorClient.StartCourse(bikeID, age.ToString(), gender.ToString(), weight.ToString());
            

            bttnStart1.Enabled = false;
            bttnEnd1.Enabled = true;

            Refresh();
        }

        public void EndCourse()
        {
            ChangeDistance(0,0);
            ChangePower(0, 0);
            ChangeTime(0, 0);
            ChangeSpeed(0, 0);
            bttnStart1.Enabled = true;
            bttnEnd1.Enabled = false;

            doctorClient.EndCourse(bikeID);

            Refresh();
        }

        private void bttnEnd1_Click(object sender, EventArgs e)
        {
            new EndCourse(this).Show();
            this.Enabled = false;
        }

        private void chatButton_Click(object sender, EventArgs e)
        {
            chatform = new ChatForm(bikeID, doctorClient);
            chatform.Show();
            chatform.BringToFront();
        }

        private void powerPlus_Click(object sender, EventArgs e)
        {
            if(!(circlePowerBar.Value >= 100))
                doctorClient.SetPower(bikeID, 1);
        }

        private void powerMinus_Click(object sender, EventArgs e)
        {
            if (!(circlePowerBar.Value <= 0))
                doctorClient.SetPower(bikeID , -1);
        }

        private void circleSpeedBar_Click(object sender, EventArgs e)
        {

        }
    }
}
