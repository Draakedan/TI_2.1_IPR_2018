using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using Remote_Healthcare.DataHandling;

namespace Remote_Healthcare.TCPCommunication
{
    class TCPConnection
    {
        private bool looping = true;
        private Stream stream;
        private Thread worker;
        private TcpClient connection;
        private IReceiver listener1;
        private String ID;

        public TCPConnection(IReceiver listener, String ip, int port)
        {
            this.listener1 = listener;
            //this.ID = identifier;
            ConnectTCP(ip, port);
            
        }

        public void Start()
        {
            worker.Start();
            while (looping)
            {
                if(TCPDataHandler.GetInstance().Outgoing.Count != 0)
                {
                    SendData(TCPDataHandler.GetInstance().Outgoing.Dequeue());
                }
            }
        }

        private void SendData(string message)
        {
            if (message != null)
            {
                byte[] length = BitConverter.GetBytes(message.Length);
                byte[] data = Encoding.UTF8.GetBytes(message);
                byte[] msg = new byte[length.Length + data.Length];
                length.CopyTo(msg, 0);
                data.CopyTo(msg, length.Length);
                NetworkStream networkStream = connection.GetStream();
                networkStream.Write(msg, 0, msg.Length);
            }
        }

        private void ConnectTCP(String ip, int port)
        {
            connection = new TcpClient(ip, port);
            this.stream = connection.GetStream();
            StartWorker(this.stream);

        }

        private void StartWorker(Stream incomming)
        {
            worker = new Thread(new ThreadStart(new TCPReceiver(this.connection, this.listener1).Start));
        }


    }
}
