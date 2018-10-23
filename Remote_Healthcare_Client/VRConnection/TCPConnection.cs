using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using Remote_Healthcare_Client.DataHandling;

namespace Remote_Healthcare_Client.VRConnection
{
    class TCPConnection
    {
        private bool looping = true;
        private Stream stream;
        private Thread worker;
        private TcpClient connection;
        private IReceiver listener1;
        private String ID;
        private TCPReceiver receiver;

        private int retries;

        public TCPConnection(IReceiver listener, String ip, int port)
        {
            retries = 0;
            this.listener1 = listener;
            ConnectTCP(ip, port);
            
        }


        public void StopConnection()
        {
            receiver.Stop();
            worker.Join();
            looping = false;
            Console.WriteLine("Stopped connections");
        }

        public void SendData(string message)
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
        {   if(retries == 10)
            {
                Environment.Exit(0);
            }
            bool connected = false;
            Console.Write("--Connecting to VR-Server |");
            try
            {
                connected = true;
                connection = new TcpClient(ip, port);
                
            } catch
            {
                connected = false;
            }
            if (connected)
            {
                this.stream = connection.GetStream();
                StartWorker(this.stream);
                Console.WriteLine("OK");
            } else
            {
                Console.Write("ERROR|");
                Console.WriteLine($"Retrying connection| Tries left {10 - retries}");
                Thread.Sleep(1000);
                retries++;
                ConnectTCP(ip, port);
            }
        }

        private void StartWorker(Stream incomming)
        {
            receiver = new TCPReceiver(this.connection, this.listener1);
            receiver.SwitchReceiveMode();
            worker = new Thread(new ThreadStart(receiver.Start));
            worker.Start();
        }


    }
}
