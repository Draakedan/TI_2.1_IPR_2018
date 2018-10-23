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
    partial class CreateAccount : Form
    {
        private DoctorInput docInput;
        private DoctorClient DoctorClient;

        public CreateAccount(DoctorInput docInput,  DoctorClient DoctorClient)
        {
            InitializeComponent();
            this.docInput = docInput;
            this.DoctorClient = DoctorClient;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (usernameText.Text != String.Empty && passwordText.Text != String.Empty)
            {
                bool created = DoctorClient.GuiDataToServer("create_account", usernameText.Text, passwordText.Text);
                if (created)
                {
                    docInput.Enabled = true;
                    this.Dispose();
                }
                else
                    MessageBox.Show("There is already an account with this username");
            }
            else
                MessageBox.Show("You need to fill in all fields");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            docInput.Enabled = true;
            this.Dispose();
        }
    }
}
