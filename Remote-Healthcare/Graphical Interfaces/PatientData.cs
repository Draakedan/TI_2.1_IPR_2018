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

namespace Remote_Healthcare.Graphical_Interfaces
{
    partial class PatientData : Form
    {
        private DoctorClient DoctorClient;

        public PatientData(DoctorClient DoctorClient)
        {
            InitializeComponent();
            this.DoctorClient = DoctorClient;
        }

        public void SetPatientData(Patient searchedPatient)
        {
            if(searchedPatient != null)
            {
                historicData.Text = searchedPatient.name + ":\r\n";
                foreach (PointOfTime PoT in searchedPatient.timeList)
                    historicData.Text = historicData.Text + PoT.ToString() + "\r\n";
            }
            else
                historicData.Text = "No file of this patient exists";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DoctorClient.GetPatientData(patientName.Text);
        }
    }
}
