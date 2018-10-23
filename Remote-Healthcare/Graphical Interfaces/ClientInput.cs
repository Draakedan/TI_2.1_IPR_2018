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
using System.Collections;

namespace Remote_Healthcare
{
    public partial class ClientInput : Form
    {
        public string[] comports;

        public ClientInput()
        {
            //patientClient = new PatientClient();
            InitializeComponent();
            InitializeComports();
        }

        private void InitializeComports()
        {
            int listsize = 50;
            comports = new string[listsize];
            for (int i = 0;i < listsize; i++)
            {
                comportBox.Items.Add("COM" + i);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int selectedItem = comportBox.SelectedIndex;
            if(selectedItem == -1)
            {
                selectedItem = 0;
            }
            string port = (string)comportBox.Items[selectedItem];
            //new ClientGUI(port).Show();
            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ClientInput_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
