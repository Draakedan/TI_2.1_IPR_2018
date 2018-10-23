using Remote_Healthcare.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Healthcare
{
    public partial class DoctorInput : Form
    {
        DoctorClient doctorClient;

        public DoctorInput()
        {
            InitializeComponent();

            usernameTextBox.Text = "test";
            passwordTextBox.Text = "test";

            inlogGegevensIncorrectLabel.Visible = false;
            Thread clientThread = new Thread(StartClient);
            clientThread.Start();
        }

        private void StartClient()
        {
            doctorClient = new DoctorClient();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
    
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            bool isLoginCorrect = doctorClient.loginForGUI(username, password);
            if (isLoginCorrect)
            {
                new DocGUI(doctorClient).Show();
                this.Visible = false;
            }
            else
            {
                inlogGegevensIncorrectLabel.Visible = true;
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
            }

        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
