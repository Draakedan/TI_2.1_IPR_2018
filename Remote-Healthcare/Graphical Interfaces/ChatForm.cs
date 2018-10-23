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
    partial class ChatForm : Form
    {
        DoctorClient doctorClient;
        public string bikeID { get; }
        public ChatForm(string bikeID, DoctorClient doctorClient)
        {
            InitializeComponent();
            this.doctorClient = doctorClient;
            this.bikeID = bikeID;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string message = ChatTextBox.Text;
            ChatLogTextBox.Text = ChatLogTextBox.Text + message + Environment.NewLine;
            doctorClient.SendChatMessage(bikeID, message);
            ChatTextBox.Text = "";
        }

        private void broadcastButton_Click(object sender, EventArgs e)
        {
            string message = ChatTextBox.Text;
            ChatLogTextBox.Text = ChatLogTextBox.Text + "Broadcast: " + message + Environment.NewLine;
            doctorClient.SendBroadcast(message);
            ChatTextBox.Text = "";
        }
    }
}
