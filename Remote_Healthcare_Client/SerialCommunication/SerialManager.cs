using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO.Ports;
using Remote_Healthcare_Client.Bicycle;

namespace Remote_Healthcare_Client.SerialCommunication
{
    class SerialManager
    {
        private SerialPort connection;
        private String port;
        private string message;
        private int speed;
        private readonly int id;
        IX7DataListener listener;
        PhysicalBike bike;


        public SerialManager(IX7DataListener listener,PhysicalBike b, String port, int speed, int id)
        {
            this.port = port;
            this.speed = speed;
            this.id = id;
            this.listener = listener;
            this.bike = b;
            this.message = "";
            InitializeConnection();
        }

        /// <summary>
        /// Initializes the serial connection and assigns connection variables
        /// </summary>
        private void InitializeConnection()
        {
            try
            {
                connection = new SerialPort(port, speed);
                connection.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                connection.DtrEnable = true;
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Starts the looping sending process in the thread
        /// if there is no commands to send in the queue then it does nothing
        /// </summary>
        public void Start()
        {
            bool looping = true;
            String message;

            bike.Outgoing.Enqueue("RS");
            bike.Outgoing.Enqueue("CM");
            while (looping)
            {
                Thread.Sleep(100); // delays the checking process to save system resources
                if (bike.Outgoing.Count != 0)
                {

                    try
                    {
                        for (int i = 0; i < bike.Outgoing.Count; i++)
                        {
                            message = bike.Outgoing.Dequeue();
                            connection.WriteLine(message);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"Serial was not able to send message");
                        Debug.WriteLine(e.StackTrace.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Handles the message data present in the port
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs</param>
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (listener != null)
            {
                int character = connection.ReadByte();
                if(character == 13 || character == 10) // if character is CR or LB then send the data to the manager
                {
                    if(message == "ACK" || message == "RUN")
                    {
                        Debug.WriteLine($"Bike sent {message}");
                        message = "";
                    } else
                    {
                        if(message != "")
                        {
                            listener.OnDataReceived(message);
                            message = "";
                        }
                        
                    }
                    
                } else if (character == 9) // if character is a TAB then record a | in the message
                {
                    message += "|";
                } else if(character == 8) // if character is a BKSPC then remove last character from the message
                {
                    message = message.Remove(message.Length - 1);
                }
                else // if the character is a normal character then add it to the message
                {
                    message += Convert.ToString(Convert.ToChar(character));
                }

                //listener.OnDataReceived(connection.ReadByte());
            }
        }
    }
}
