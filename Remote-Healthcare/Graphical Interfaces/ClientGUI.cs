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
using Remote_Healthcare.DataHandling;

namespace Remote_Healthcare
{
    public partial class ClientGUI : Form
    {
        private SerialManager Manager;
        private Thread Worker;
        private String Output;
        public ClientGUI()
        {
            InitializeComponent();
        }

        private void ClientGUI_Load(object sender, EventArgs e)
        {
            SerialDataHandler.getInstance().InitializeBike(1);
            VRHandler.getInstance().SetupScene(400, 400);
            
        }

        private void ClientGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
