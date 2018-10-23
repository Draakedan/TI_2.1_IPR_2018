using Remote_Healthcare.Client;
using Remote_Healthcare.Graphical_Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Remote_Healthcare
{
    partial class DocGUI : Form
    {
        private DoctorClient doctorClient;
        private List<BicycleCustomControl> bikes;
        private List<GraphCustomControll> graphs;
        
        public DocGUI(DoctorClient doctorClient)
        {
            this.doctorClient = doctorClient;
            InitializeComponent();
            panel9.Height = BycicleButton.Height;
            panel9.Top = BycicleButton.Top;
            bikes = new List<BicycleCustomControl>();
            graphs = new List<GraphCustomControll>();
            generateGraphs();
            
        }

        public void SetBikeData(string bikeID, PointOfTime patientData)
        {
            foreach(BicycleCustomControl bike in bikes)
            {
                if(bike.bikeID == bikeID)
                {
                    bike.SetPatientData(patientData);
                }
            }
        }

        private void BycicleButton_Click(object sender, EventArgs e)
        {
            panel9.Height = BycicleButton.Height;
            panel9.Top = BycicleButton.Top;
            GraphPanel.Visible = false;
            BicyclePanel.Visible = true;
        }

        private void GraphsButton_Click(object sender, EventArgs e)
        {
            panel9.Height = GraphsButton.Height;
            panel9.Top = GraphsButton.Top;
            BicyclePanel.Visible = false;
            GraphPanel.Visible = true;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            AddDataToGraph("Speed", 0.1, 0.2);
            AddDataToGraph("Speed", 1.1, 2.1);
            AddDataToGraph("Speed", 2.1, 4.2);
            AddDataToGraph("Speed", 3.1, 1.8);
            foreach (BicycleCustomControl bicycle in bikes)
            {
                bicycle.Refresh();
                bicycle.Update();
            }
            BicyclePanel.Refresh();

            foreach (GraphCustomControll graph in graphs)
            {
                graph.Refresh();
                graph.Update();
            }
            GraphPanel.Refresh();

           
        }

        public void RemoveBike(string name)
        {
            for (int index = 0; index < bikes.Count; index++)
            {
                if (bikes.ElementAt(index).bikeID == name)
                {
                    bikes.RemoveAt(index);
                    index = bikes.Count + 2;
                }
            }
        }

        public void AddNewPatientToGUI(string name)
        {
            string bikeID = doctorClient.AddPatientToBike(name);
            bikes.Add(new BicycleCustomControl(name, bikeID, doctorClient));
          
            BicyclePanel.Refresh();
        }

        public void UpdateBicycleData()
        {
            BicyclePanel.Refresh();
        }

        public void AddDataToGraph(string graphName, double xValue, double yValue)
        {
            GraphCustomControll graphCustom = null;
            for (int index = 0; index < graphs.Count; index++)
            {
                if (graphs.ElementAt(index).GraphName == graphName)
                {
                    graphCustom = graphs.ElementAt(index);
                    index = bikes.Count + 2;
                }
            }

            graphCustom.AddData(xValue, yValue);
        }

        private void generateGraphs()
        {
            graphs.Add(new GraphCustomControll("Speed"));
            graphs.Add(new GraphCustomControll("Power"));
            graphs.Add(new GraphCustomControll("Distance"));
        }

        private void BicyclePanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (BicycleCustomControl bicycle in bikes)
            {
                if (!BicyclePanel.Controls.Contains(bicycle))
                    BicyclePanel.Controls.Add(bicycle);
            }
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            if (GraphPanel.Controls.Count == 0)
            {                
                foreach (GraphCustomControll graph in graphs)
                {
                    if (!GraphPanel.Controls.Contains(graph))
                        GraphPanel.Controls.Add(graph);
                }
            }
        }

        private void addPatientButton_Click(object sender, EventArgs e)
        {
            if (doctorClient.CheckBikes())
            {
                new AddPatient(this).Show();
                this.Enabled = false;
            }
            else
                MessageBox.Show("There are no bikes available to connect a patient to");
        }

        private void getPatientData_Click(object sender, EventArgs e)
        {
            PatientData patientData = new PatientData(doctorClient);
            doctorClient.PatientDataPanel = patientData;
            patientData.Show();
        }
    }
}
