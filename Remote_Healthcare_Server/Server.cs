using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Remote_Healthcare_Server
{
    class Server
    {
        private List<ServerClient> Clients = new List<ServerClient>();
        private SortedList<string, string> doctorAccounts;
        private int BikeCount = 1;

        public Server()
        {
            Console.WriteLine("Started a server at port 6666");
            TcpListener listener = new TcpListener(IPAddress.Any, 6666);
            listener.Start();
            
            CheckDoctorDataFile();
            AddTestAccount();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread thread = new Thread(HandleClientThread);
                thread.Start(client);
                Console.WriteLine("Er heeft een client verbinding gemaakt met de Server");
                
            }
        }

        public void HandleClientThread(object obj)
        {
          
            TcpClient client = obj as TcpClient;

            string clientSort = ReadTextMessage(client);
            dynamic receivedData = JsonConvert.DeserializeObject(clientSort);
            string command = receivedData.command;
            string type = receivedData.data.type;
            Console.WriteLine("komt iets binnen");

            if (type == "patient")
            {
                Console.WriteLine("Patient has connected");
                HandlePatient(client);
            }
            else if (type == "doctor")
            {
                Console.WriteLine("Doctor has connected");
                HandleDoctor(client);
            }
            
        }

        private void HandlePatient(TcpClient client)
        {
            Patient clientPatient = new Patient();

            string bikeID = "Bike" + BikeCount;
            BikeCount++;

            ServerClient CurrentClient = new ServerClient(client);
            CurrentClient.ClientName = bikeID;
            Clients.Add(CurrentClient);
            
            bool done = false;
            while (!done && client.Connected)
            {
                if (CurrentClient.PatientName != "" && CurrentClient.StartCourse)
                {
                    SendDataRequest(CurrentClient);
                }
            }

            client.Close();
        }

        private void HandleDoctor(TcpClient client)
        {
            ServerClient CurrentClient = new ServerClient(client);
                
            bool done = false;
            while (!done && client.Connected)
            {
                HandleData(CurrentClient, ReadTextMessage(client));
            }

            client.Close();
        }

        private void HandleData(ServerClient CurrentClient, string jsonString)
        {
            dynamic receivedData = JsonConvert.DeserializeObject(jsonString);
            string command = receivedData.command;
            string data = receivedData.data;

            switch (command)
            {
                case "login":
                    HandleLogin(CurrentClient, data);
                    break;
                case "create_account":
                    HandleCreateAccount(CurrentClient, data);
                    break;
                case "chat":
                    HandleChat(data);
                    break;
                case "broadcast":
                    HandleBroadcast(data);
                    break;
                case "patient_data":
                    HandlePatientData(CurrentClient, data);
                    break;
                case "check_bikes":
                    HandleCheckBikes(CurrentClient);
                    break;
                case "add_patient":
                    HandleAddPatient(CurrentClient, data);
                    break;
                case "current_PoT":
                    HandleCurrentPoT(CurrentClient, data);
                    break;
                case "client_disconnect":
                    HandleClientDisconnect(CurrentClient, data);
                    break;
                default:
                    HandleDefault(CurrentClient, command, data);
                    break;
            }
        }

        private void HandleLogin(ServerClient CurrentClient, string data)
        {
            dynamic loginData = JsonConvert.DeserializeObject(data);
            string username = loginData.username;
            string password = loginData.password;

            CurrentClient.ClientName = username;
            Clients.Add(CurrentClient);

            Console.WriteLine("gelezen username = {0}", username);

            if (IsLoginCorrect(username, password))
                WriteTextMessage(CurrentClient.Client, "AccountExists");
            else
                WriteTextMessage(CurrentClient.Client, "AccountDoesntExist");
        }

        private void HandleCreateAccount(ServerClient CurrentClient, string data)
        {
            dynamic accountData = JsonConvert.DeserializeObject(data);
            string username = accountData.username;
            string password = accountData.password;

            if (doctorAccounts.Keys.Contains(username))
                WriteTextMessage(CurrentClient.Client, "AccountExists");
            else
            {
                AddDoctorAccount(username, password);
                WriteTextMessage(CurrentClient.Client, "AccountCreated");
            }
        }

        private void HandleChat(string data)
        {
            Console.WriteLine(data);
            dynamic receivedData = JsonConvert.DeserializeObject(data);
            string bikeID = receivedData.bikeID;

            ServerClient client = FindClientByBikeID(bikeID);
            WriteTextMessage(client.Client, CreateJsonCommand("chat", data));
        }

        private void HandleBroadcast(string data)
        {
            Console.WriteLine("Sending a broadcast to all patients");
            Console.WriteLine(data);
            foreach (ServerClient client in Clients)
            {
                if(client.ClientName.Contains("Bike"))
                 WriteTextMessage(client.Client, CreateJsonCommand("broadcast", data));
            }
        }

        private void HandlePatientData(ServerClient CurrentClient, string data)
        {
            dynamic patientNameData = JsonConvert.DeserializeObject(data);
            string patientName = patientNameData.patientName;
            string patientData = ReadPatientFromFile(patientName);
            WriteTextMessage(CurrentClient.Client, CreateJsonCommand("patient_data", patientData));
        }

        private void HandleCheckBikes(ServerClient CurrentClient)
        {
            string message = "";
            foreach (ServerClient Client in Clients)
            {
                if (Client.ClientName.Contains("Bike") && Client.Available == true)
                    message = "bike_available";
            }
            WriteTextMessage(CurrentClient.Client, message);
        }

        private void HandleAddPatient(ServerClient currentClient, string data)
        {
            dynamic patientNameData = JsonConvert.DeserializeObject(data);
            string patientName = patientNameData.patientName;

            string patientData = ReadPatientFromFile(patientName);

            if (patientData == "PatientNotFound")
            {
                Patient newPatient = new Patient(patientName);
                WritePatientToFile(newPatient);
            }

            string bikeID = "no_bike";
            foreach (ServerClient client in Clients)
            {
                if (client.ClientName.Contains("Bike") && client.Available == true)
                {
                    client.Available = false;
                    bikeID = client.ClientName;
                    client.PatientName = patientName;
                    break;
                }
            }
            WriteTextMessage(currentClient.Client, bikeID);
        }

        private void HandleCurrentPoT(ServerClient currentClient, string data)
        {
            PointOfTime PoT = JsonConvert.DeserializeObject<PointOfTime>(data);
            Patient patient = JsonConvert.DeserializeObject<Patient>(ReadPatientFromFile(currentClient.PatientName));
            patient.addPointOfTime(PoT);
            WritePatientToFile(patient);
        }

        private void HandleClientDisconnect(ServerClient CurrentClient, string data)
        {
            CurrentClient.Client.Close();
            Console.WriteLine(CurrentClient.ClientName + " has disconnected from the server");
        }

        private void HandleDefault(ServerClient currentClient, string command, string data)
        {
            dynamic receivedBikeID = JsonConvert.DeserializeObject(data);
            string bikeID = receivedBikeID.bikeID;

            ServerClient client = FindClientByBikeID(bikeID);
            if(command == "course_start" && client != null)
            {
                client.StartCourse = true;
                client.DoctorName = currentClient.ClientName;
            }
            else if(command == "course_stop" && client != null)
            {
                client.StartCourse = false;
                client.DoctorName = "";

                string patientData = ReadPatientFromFile(client.PatientName);
                Patient currentPatient = JsonConvert.DeserializeObject<Patient>(data);

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), client.PatientName + "_temp.txt");
                string[] courseData = File.ReadAllLines(path);
                for (int i = 1; i < courseData.Length; i++)
                {
                    dynamic receivedData = JsonConvert.DeserializeObject(courseData[i]);

                    int power = receivedData.power;
                    double distance = receivedData.distance;
                    double energy = receivedData.energy;
                    double rpm = receivedData.rpm;
                    string time = receivedData.time;

                    PointOfTime pointOfTime = new PointOfTime(
                        power, distance, energy, rpm, time); ;

                    currentPatient.addPointOfTime(pointOfTime);
                }
                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), client.PatientName + ".txt");
                File.Delete(path1);
                currentPatient.name = client.PatientName;
                WritePatientToFile(currentPatient);

            }
            WriteTextMessage(client.Client, CreateJsonCommand(command, data));
        }

        private ServerClient FindClientByBikeID(string bikeID)
        {
            ServerClient wantedClient = null;
            foreach (ServerClient client in Clients)
                if (client.ClientName == bikeID)
                    wantedClient = client;
            return wantedClient;
        }

        private void SendDataRequest(ServerClient currentClient)
        {
            //WriteTextMessage(currentClient.Client, CreateJsonCommand("data/request", null));
            string bikeData = ReadTextMessage(currentClient.Client);
            dynamic receivedData = JsonConvert.DeserializeObject(bikeData);
            string patientData = JsonConvert.SerializeObject(new
            {
                command = receivedData.command,
                bikeID = currentClient.ClientName,
                data = receivedData.data,
            });
            Console.WriteLine(patientData);
            
            string savableData = Environment.NewLine + JsonConvert.SerializeObject(receivedData.data);
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), currentClient.PatientName + "_temp.txt");
            File.AppendAllText(path, savableData);

            foreach (ServerClient client in Clients)
                if (client.ClientName == currentClient.DoctorName)
                    WriteTextMessage(client.Client, CreateJsonCommand("bike_data", patientData));
        }

        private bool IsLoginCorrect(String username, String password)
        {
            bool correctLogin = false;
            if (username != "" && password != "")
            {
                foreach (string userKey in doctorAccounts.Keys)
                {
                    if (userKey == username && doctorAccounts[userKey] == password)
                    {
                        correctLogin = true;
                    }
                }
            }
            return correctLogin;
        }

        private void AddDoctorAccount(string Username, string Password)
        {
            if (doctorAccounts == null)
            {
                doctorAccounts = new SortedList<string, string>();
            }
            if (!doctorAccounts.ContainsKey(Username))
            {
                doctorAccounts.Add(Username, Password);
            }

            string JsonAccounts = JsonConvert.SerializeObject(doctorAccounts);
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "DoctorData.txt");
            File.WriteAllText(path, JsonAccounts);
        }

        private void AddTestAccount()
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes("test");
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string encryptedData = System.Text.Encoding.ASCII.GetString(data);

            if (doctorAccounts == null)
                doctorAccounts = new SortedList<string, string>();
            if (!doctorAccounts.ContainsKey(encryptedData))
                doctorAccounts.Add(encryptedData, encryptedData);

            string JsonAccounts = JsonConvert.SerializeObject(doctorAccounts);
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "DoctorData.txt");
            File.WriteAllText(path, JsonAccounts);

            Patient testPatient = new Patient("test");
            testPatient.addPointOfTime(new PointOfTime(50, 12.5, 60, 15.8, "13:00"));
            testPatient.addPointOfTime(new PointOfTime(40, 11, 50, 14, "12:00"));
            testPatient.addPointOfTime(new PointOfTime(55, 9.5, 55, 12.6, "11:00"));
            WritePatientToFile(testPatient);
        }

        private string CreateJsonCommand(string command, string data)
        {
            string output = JsonConvert.SerializeObject(new
            {
                command = command,
                data = data,

            });
            return output;
        }

        private void WriteTextMessage(TcpClient client, string message)
        {
            try
            {
                var stream = new StreamWriter(client.GetStream(), Encoding.UTF32);
                stream.WriteLine(message);
                Console.WriteLine(message);
                stream.Flush();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Er is een fout opgetreden in de verbinding");
            }

        }

        private string ReadTextMessage(TcpClient client)
        {
            string line = "";
            try
            {
                StreamReader stream = new StreamReader(client.GetStream(), Encoding.UTF32);
                if (client.Connected)
                    line = stream.ReadLine();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Er is een fout opgetreden in de verbinding");
            }
            catch (IOException e)
            {
                Console.WriteLine("Er is een fout opgetreden in de verbinding");
            }
            if(line == "" || line == null)
                Console.WriteLine(line);
            return line;
        }

        private void WritePatientToFile(Patient patient)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), patient.name + ".txt");
            string data = JsonConvert.SerializeObject(patient);
            File.WriteAllText(path, data);
        }

        private string ReadPatientFromFile(string patientName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), patientName + ".txt");
            if (File.Exists(path))
                return File.ReadAllText(path);
            else
                return "PatientNotFound";
        }

        private void CheckDoctorDataFile()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "DoctorData.txt");
            if (!File.Exists(path))
            {
                Console.WriteLine("Er is nog geen File gevonden waarin de al aangemaakte doctorAccounts staan, dus deze wordt aangemaakt!");
                var myFile = File.Create(path);
                myFile.Close();
            }
            else if (File.Exists(path))
            {
                Console.WriteLine("Er is een bestand gevonden met bestaande doctorAccounts");
                string doctorData = File.ReadAllText(path);
                doctorAccounts = JsonConvert.DeserializeObject<SortedList<string, string>>(doctorData);
            }
        }
    }
}
