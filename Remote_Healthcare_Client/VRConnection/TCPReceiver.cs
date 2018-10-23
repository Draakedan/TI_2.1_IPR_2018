using System.Net.Sockets;
using System.IO;
using System;
using System.Text;

namespace Remote_Healthcare_Client.VRConnection
{
    class TCPReceiver
    {
        private StreamReader reader;
        public bool alive = true;
        private IReceiver listener;
        private bool Receivemode = false;
        private NetworkStream stream;

        public TCPReceiver(TcpClient client, IReceiver listener)
        {
            reader = new StreamReader(client.GetStream());
            stream = client.GetStream();
            this.listener = listener;
        }

        public void SwitchReceiveMode()
        {
            Receivemode = true;
        }

        public void Start()
        {
            while (alive)
            {
                ReadStream();
            }
        }

        public void Stop()
        {
            this.alive = false;
        }

        private void ReadStream()
        {
            if (!Receivemode)
            {
                string readLine = "";
                readLine = reader.ReadLine();

                if (readLine != "")
                    listener.IsStringReceived(readLine);
            }
            else
            {
                try
                {
                    byte[] sizeInfo = new byte[4];

                    int totalRead = 0, read = 0;
                    do
                    {
                        read = stream.Read(sizeInfo, totalRead, sizeInfo.Length - totalRead);

                        totalRead += read;
                    } while (totalRead < sizeInfo.Length && read > 0);

                    int messageSize = BitConverter.ToInt32(sizeInfo, 0);

                    byte[] data = new byte[messageSize];

                    totalRead = 0;

                    do
                    {
                        totalRead += read = stream.Read(data, totalRead, data.Length - totalRead);
                    } while (totalRead < messageSize && read > 0);
                    String message = Encoding.UTF8.GetString(data);
                    listener.IsStringReceived(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
