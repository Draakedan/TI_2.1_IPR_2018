using Newtonsoft.Json;
using Remote_Healthcare_Client.Bicycle;
using Remote_Healthcare_Client.DataHandling;
using Remote_Healthcare_Client.VRConnection;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;

namespace Remote_Healthcare_Client.ServerConnection
{
    class Connection : IReceiver, IBikeDataListener
    {
        private TCPReceiver receiver;
        private Thread worker;
        private TcpClient client;
        private BikeDataPackage latestBikeData;
        private System.Timers.Timer dataRequestTimer;

        private bool dataRequested;

        public Connection(string ip, int port)
        {
            dataRequested = false;
            SerialDataHandler.getInstance().AddSubscriberToHandler(this);
            ConnectToServer(ip,port);

            latestBikeData = new BikeDataPackage("1970-01-01-00:00:00", "0", "0", "0", "0");
            dataRequestTimer = new System.Timers.Timer(100);
            dataRequestTimer.Elapsed += OnTimerTick;
            dataRequestTimer.AutoReset = true;
            dataRequestTimer.Enabled = true;
            dataRequestTimer.Start();

            client.GetStream().Flush();
            SendMessage(ServerCommands.ClientType());
        }

        public void EndConnection()
        {
            client.GetStream().Flush();
            client.GetStream().Close();
            client.Close();
            //tim zn ip: 145.49.13.212
            //port 6666
        }

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
            if (message != null && message != "")
            {
                StreamWriter sw = new StreamWriter(client.GetStream(), Encoding.UTF32);
                sw.WriteLine(message);
                sw.Flush();
            }
        }

        private void ConnectToServer(string ip, int port)
        {
            try
            {
                Console.WriteLine($"Connecting to {ip}:{port}");
                client = new TcpClient(ip, port);
            } catch(Exception ex)
            {
                Console.WriteLine("Error: Server not available");
                Console.WriteLine("Error code: " + ex.ToString());
                Console.WriteLine("Retrying connection");
            }
            if (!client.Connected)
                ConnectToServer(ip, port);
            else
            {
                Console.WriteLine("Connected succesfully");
                AddReceiverThread();
            }
        }

        private void AddReceiverThread()
        {
            receiver = new TCPReceiver(client, this);
            worker = new Thread(new ThreadStart(receiver.Start));
            worker.Start();
        }

        private void HandleData(string command, string data)
        {
            dynamic receivedData = JsonConvert.DeserializeObject(data);
            switch (command)
            {
                case "chat":
                    string directMessage = "[DM]:" + receivedData.message;
                    Console.WriteLine("New message received: " + directMessage);
                    break;
                case "broadcast":
                    string broadcastMessage = "[BC]:"+ receivedData.message;
                    Console.WriteLine("New message received: " + broadcastMessage);
                    break;
                case "course_start":
                    string time = receivedData.time;
                    string power = receivedData.power;
                    string distance = receivedData.distance;
                    BikeDataPackage package = new BikeDataPackage(time, power, "0", distance, "0");
                    StartCourse(package);
                    break;
                case "course_stop":
                    EndCourse();
                    break;
                case "set_power":
                    int increment = receivedData.increment;
                    SetPower(increment);
                    break;
                case "client/id":
                    ServerCommands.BikeID = Convert.ToInt32(receivedData.id);
                    break;
                case "stop_vr":
                    VRHandler.getInstance().ResetScene();
                    break;

            }
        }

        private void StartCourse(BikeDataPackage bdp)
        {
            DateTime newBikeTime = new DateTime(1970, 01, 01, 00, (int) Math.Floor(int.Parse(bdp.time) / 60d), int.Parse(bdp.time) % 60);

            SerialDataHandler.getInstance().ResetWithVariables(int.Parse(bdp.power),  Convert.ToInt32(newBikeTime.Minute), Convert.ToInt32(newBikeTime.Second), (int) (double.Parse(bdp.distance) * 1000));
            
            dataRequested = true;

            //VRHandler.getInstance().SetupScene(400, 400);

            // Set variables
            // Start sending variables
            // Setup VR
        }
        private void EndCourse()
        {
            dataRequested = false;
            VRHandler.getInstance().ResetScene();
        }

        private void SetPower(int increment)
        {
            int latestbikepower = ((int.Parse(latestBikeData.power) - 25) / 4);
            SerialDataHandler.getInstance().SetPower(latestbikepower + increment);
        }

        private void ParseData(string receivedData)
        {
            dynamic message;
            if (receivedData != "" || receivedData != null)
            {
                try
                {
                    message = JsonConvert.DeserializeObject(receivedData);
                } catch(Exception e)
                {
                    message = JsonConvert.DeserializeObject(receivedData.Substring(1));
                }
                string command = message.command;
                string data = message.data;
                HandleData(command, data);
            }
        }

        public void IsStringReceived(string message)
        {
            Console.WriteLine(message);
            ParseData(message);
        }

        public void OnBikeDataReceived(BikeDataPackage package)
        {
            latestBikeData = package;
        }

        private void OnTimerTick(object source, ElapsedEventArgs args)
        {
            //Console.WriteLine("Tick");
            SerialDataHandler.getInstance().RequestStatus();

            if(dataRequested)
            {
                SendMessage(ServerCommands.SendBikeData(latestBikeData));
                //Console.WriteLine("Tock");
            }
        }
    }
}
