using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Healthcare_Server
{
    class ServerClient
    {
        public TcpClient Client { get; }
        //naam van de client, is een bikeID in het geval van de patient
        public string ClientName { get; set; }
        //alleen voor patient
        public string PatientName { get; set; }
        //alleen voor patient, naam van de doctor die hem monitort
        public string DoctorName { get; set; }
        public bool Available { get; set; }
        public bool StartCourse { get; set; }

        public ServerClient(TcpClient Client)
        {
            this.Client = Client;
            this.ClientName = "";
            this.PatientName = "";
            this.DoctorName = "";
            this.Available = true;
            this.StartCourse = false;
        }
    }
}
