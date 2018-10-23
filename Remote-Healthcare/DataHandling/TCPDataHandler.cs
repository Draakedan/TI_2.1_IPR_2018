using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Remote_Healthcare.TCPCommunication;
using Remote_Healthcare.JsonParse;

namespace Remote_Healthcare.DataHandling
{
    class TCPDataHandler: IReceiver
    {
        private static TCPDataHandler Instance;

        public static TCPDataHandler GetInstance()
        {
            if(Instance == null)
            {
                Instance = new TCPDataHandler();
            }
            return Instance;
        }
        public List<Thread> threads;
        public Queue<String> Outgoing;

        public TCPDataHandler()
        {
            threads = new List<Thread>();
            Outgoing = new Queue<string>();
        }

        /// <summary>
        /// Sends a JSON command to the server.
        /// </summary>
        /// <param name="e">The JSON command to send</param>
        public void AddCommandToQueue(string e)
        {
            // TODO switch the parameter given to commands from commandsheet
            this.Outgoing.Enqueue(e);
        }

        public void AddTCPConnection(String ip, int port)
        {
            threads.Add(new Thread(new ThreadStart(new TCPConnection(this, ip, port).Start)));
            threads[threads.Count - 1].Start();
        }

        public void IsStringReceived(string message)
        {
            String e = message;
            String command = Jsonparser.GetCommandIdentifier(e);
            if (command.Contains("node") || command.Contains("route") || command.Contains("session") || command.Contains("tunnel") || command.Contains("scene"))
            {
                VRHandler.getInstance().ParseCommand(e,command);
            }else
            {
                //TODO add route for other TCP trafic
            }
            
        }
    }
}
