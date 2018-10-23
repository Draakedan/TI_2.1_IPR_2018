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
    partial class AddPatient : Form
    {
        DocGUI docGui;

        public AddPatient(DocGUI docGui)
        {
            InitializeComponent();
            this.docGui = docGui;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getPatientNameTextBox.Text != String.Empty)
            {
                docGui.AddNewPatientToGUI(getPatientNameTextBox.Text);
                docGui.Enabled = true;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please enter the required fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            docGui.Enabled = true;
            this.Dispose();
        }
    }
}
