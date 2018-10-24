using Newtonsoft.Json;
using Remote_Healthcare.Bicycle;
using Remote_Healthcare.Graphical_Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Remote_Healthcare.Client
{
    class DoctorClient
    {
        private static TcpClient client;
        public DocGUI DocGUI { get; set; }
        public PatientData PatientDataPanel { get; set; }


        public DoctorClient(string serverIpAddress)
        {
            client = new TcpClient(serverIpAddress, 6666);

            string clientType = JsonConvert.SerializeObject(new
            {
                command = "client/type",
                data = new
                {
                    type = "doctor",
                }
            });

            WriteTextMessage(clientType);
        }
        
        public bool GuiDataToServer(string command, string username, string password)
        {
            bool loginCorrect = false;

            Tuple<string, string> encryptedLogin = EncryptLoginData(username, password);
            username = encryptedLogin.Item1;
            password = encryptedLogin.Item2;

            string loginData = JsonConvert.SerializeObject(new
                { 
                    username = username,
                    password = password,
                    
                });
                        
            WriteTextMessage(CreateJsonCommand(command, loginData));

            string responseFromServer = ReadTextMessage();
            if (responseFromServer == "AccountExists" && command == "login")
                loginCorrect = true;
            if (responseFromServer == "AccountCreated")
                loginCorrect = true;

            return loginCorrect;
        }

        private Tuple<string, string> EncryptLoginData(string username, string password)
        {
            byte[] usernameData = System.Text.Encoding.ASCII.GetBytes(username);
            usernameData = new System.Security.Cryptography.SHA256Managed().ComputeHash(usernameData);
            string encryptedUsername = System.Text.Encoding.ASCII.GetString(usernameData);

            byte[] passwordData = System.Text.Encoding.ASCII.GetBytes(password);
            passwordData = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordData);
            string encryptedPassword = System.Text.Encoding.ASCII.GetString(passwordData);
            
            return new Tuple<string, string>(encryptedUsername, encryptedPassword);
        }
                
        public void StartCourse(string bikeID, string power, string time, string distance)
        {
            string data = JsonConvert.SerializeObject(new
            {
                bikeID = bikeID,
                power = power,
                time = time,
                distance = distance,
            });

            WriteTextMessage(CreateJsonCommand("course_start", data));
            Thread patientDataThread = new Thread(ReceivePatientData);
            patientDataThread.Start();
        }

        private void ReceivePatientData()
        {
            while(true)
            {
                string receivedMessage = ReadTextMessage();
            }
        }

        public void EndCourse(string bikeID)
        {
            string data = JsonConvert.SerializeObject(new
            {
                bikeID = bikeID,
            });
            WriteTextMessage(CreateJsonCommand("course_stop", data));
        }

        public void cacluculateVO2(int gewicht, int leeftijd, int geslacht, int HartSlagEinde)
        {
            return (132.853 - (0.0769 * gewicht) - (0.3877 * leeftijd) + (6.315 * geslacht) - (3.2649 * 7) - (0.1565 * HartSlagEinde));
        }

        public void SetPower(string bikeID, int increment)
        {
            string data = JsonConvert.SerializeObject(new
            {
                bikeID = bikeID,
                increment = increment,
            });
            WriteTextMessage(CreateJsonCommand("set_power", data));
        }

        public void SendChatMessage(string bikeID, string message)
        {
            string data = JsonConvert.SerializeObject(new
            {
                bikeID = bikeID,
                message = message,
            });

            WriteTextMessage(CreateJsonCommand("chat", data));
        }

        public void SendBroadcast(string message)
        {
            string data = JsonConvert.SerializeObject(new
            {
                message = message,
            });

            WriteTextMessage(CreateJsonCommand("broadcast", data));
        }

        public void GetPatientData(string patientName)
        {
            string data = JsonConvert.SerializeObject(new
            {
                patientName = patientName,
            });

            WriteTextMessage(CreateJsonCommand("patient_data", data));
            DecodeJsonCommand(ReadTextMessage());
        }

        public bool CheckBikes()
        {
            WriteTextMessage(CreateJsonCommand("check_bikes", ""));
            string response = ReadTextMessage();
            if (response == "bike_available")
                return true;
            else
                return false;
        }

        public string AddPatientToBike(string patientName)
        {
            string data = JsonConvert.SerializeObject(new
            {
                patientName = patientName,
            });
            WriteTextMessage(CreateJsonCommand("add_patient", data));

            string bikeID = ReadTextMessage();
            return bikeID;
        }

        public void Disconnect()
        {
            WriteTextMessage(CreateJsonCommand("client_disconnect", ""));
            client.Close();
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
        
        private void DecodeJsonCommand(string jsonString)
        {
            dynamic receivedData = null;
            try
            {
                receivedData = JsonConvert.DeserializeObject(jsonString);
            }
            catch (Exception e)
            {
                string newJson = jsonString.Replace("\0", "");
                while(newJson.Contains(@"\\\"))
                    newJson = newJson.Replace(@"\\\", @"\");
                receivedData = JsonConvert.DeserializeObject(newJson);
            }
            string command = receivedData.command;
            string data = receivedData.data;

            if (command == "patient_data")
            {
                Patient searchedPatient = null;
                if (!data.Contains("PatientNotFound"))
                    searchedPatient = JsonConvert.DeserializeObject<Patient>(data);
                PatientDataPanel.SetPatientData(searchedPatient);
            }
        }

        private void HandleBikeData(string data)
        {
            dynamic receivedData = null;
            try
            {
                receivedData = JsonConvert.DeserializeObject(data);
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            string bikeData = receivedData.data;
            dynamic patientData = JsonConvert.DeserializeObject(bikeData);
            
            int power = patientData.data.power;
            double distance = patientData.data.distance;
            double energy = patientData.data.energy;
            double rpm = patientData.data.rpm;
            string time = patientData.data.time;

            PointOfTime pointOfTime = new PointOfTime(
                power, distance, energy, rpm, time);;
            
            string temp = patientData.bikeID;

            DocGUI.SetBikeData(temp, pointOfTime);
        }

        private string ReadTextMessage()
        {
            StreamReader streamReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            
            string readMessage = streamReader.ReadLine();

            if(readMessage.Contains("bike_data"))
            {
                HandleBikeData(readMessage);
            }

            return readMessage;
        }

        public void WriteTextMessage(string message)
        {
            StreamWriter streamWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            streamWriter.WriteLine(message);
            streamWriter.Flush();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
