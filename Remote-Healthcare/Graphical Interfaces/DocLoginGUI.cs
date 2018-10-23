using Remote_Healthcare.Client;
using Remote_Healthcare.Graphical_Interfaces;
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
        private DoctorClient DoctorClient;

        public DoctorInput(string ip)
        {
            InitializeComponent();
            Thread ClientThread = new Thread(() => StartClient(ip));
            ClientThread.Start();
        }

        private void StartClient(string ip)
        {
            DoctorClient = new DoctorClient(ip);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool LoginCorrect = DoctorClient.GuiDataToServer("login", usernameText.Text, passwordText.Text);

            usernameText.Text = "";
            passwordText.Text = "";
            usernameText.Focus();

            if (LoginCorrect)
            {
                DocGUI docGUI = new DocGUI(DoctorClient);
                DoctorClient.DocGUI = docGUI;
                docGUI.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("The username and/or password was incorrect,\r\nplease try again");
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(DoctorClient != null)
                DoctorClient.Disconnect();
            this.Dispose();
        }

        private void createNewAccount_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount(this, DoctorClient);
            createAccount.Show();
            this.Enabled = false;
        }
    }
}
