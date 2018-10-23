using Remote_Healthcare_Client.Bicycle;
using Remote_Healthcare_Client.SerialCommunication;
using System;
using System.Collections.Generic;

namespace Remote_Healthcare_Client.DataHandling
{
    class SerialDataHandler: IX7DataListener
    {
        private static SerialDataHandler Instance;
        private Bike bike;
        private Queue<string> Outgoing;
        private string Message;
        private List<IBikeDataListener> subscribers;
        private BikeDataPackage lastPackage;

        public static SerialDataHandler getInstance()
        {
            if(Instance == null)
            {
                Instance = new SerialDataHandler();
            }
            return Instance;
        }
        private SerialDataHandler()
        {
            subscribers = new List<IBikeDataListener>();
            //lastPackage = new BikeDataPackage(null, null, null, null, null);
        }

        /// <summary>
        /// Adds a subscription to receive the incomming bikedata
        /// </summary>
        /// <param name="listener">Listener that is used as by callback to send bikedata</param>
        public void AddSubscriberToHandler(IBikeDataListener listener)
        {
            subscribers.Add(listener);
        }

        /// <summary>
        /// Initializes a bike to read data from
        /// </summary>
        /// <param name="mode">Suggests the operation mode value has to be 0 OR 1</param>
        public void InitializeBike(int mode)
        {
            switch (mode)
            {
                case 0:
                    bike = new PhysicalBike("COM8",this);
                    break;
                case 1:
                    bike = new SimulatedBike(this, 0);
                    break;
                default:
                    bike = new SimulatedBike(this, 0);
                    break;  
            }
        }

        /// <summary>
        /// Sets the time on the bike's display
        /// </summary>
        /// <param name="hh">Hours</param>
        /// <param name="mm">Minutes</param>
        public void SetTime(int mm, int ss)
        {
            if(ss < 0)
            {
                ss = 0;
            } else if(ss > 59)
            {
                ss = 0;
                mm++;
            }

            if(mm < 0)
            {
                mm = 0;
            }
            bike.SetTime((mm * 60) + ss);        }

        /// <summary>
        /// Sets the distance that is traveled
        /// </summary>
        /// <param name="distance">Value in Kilometers</param>
        public void SetDistance(int distance)
        {
            if(!(distance < 0)){
                bike.SetDistance(distance);
            } else
            {
                bike.SetDistance(0);
            }
            
        }

        /// <summary>
        /// Sets the energy value that is burned while cycling
        /// </summary>
        /// <param name="energy">Value in Kilo Joules</param>
        public void SetEnergy(int energy)
        {
            if(!(energy < 0))
            {
                bike.SetEnergy(0);
            }
        }

        /// <summary>
        /// Sets the cycling difficulty (low value == low resistance) (high value == high resistance)
        /// </summary>
        /// <param name="percentage">Value between 0-100 in %</param>
        public void SetPower(int percentage)
        {
            if(!(percentage < 0 && percentage > 100))
            {
                bike.SetPower(percentage);
            } else
            {
                bike.SetPower(percentage * 0);
            }
            
        }

        /// <summary>
        /// Requests all the bike data
        /// </summary>
        public void RequestStatus()
        {
            bike.GetVariables();
        }

        /// <summary>
        /// Resets bike to zero value's
        /// </summary>
        public void Reset()
        {
            bike.Reset();
        }

        public void ResetWithVariables(int power, int time_minutes, int time_seconds,int distance)
        {
            bike.Reset();
            bike.SetPower(power);
            bike.SetTime((time_minutes  * 60) + time_seconds);
            bike.SetDistance(distance);
        }

        private void ParseData(string message)
        {
            try
            {
                string[] Variables = message.Split(Convert.ToChar("|"));
                string Rpm = Variables[1];
                string Energy = Variables[2];
                string Distance = Variables[5];
                string Power = Variables[4];
                string Time = Variables[6];

                BikeDataPackage pack = new BikeDataPackage(Time, Power, Rpm, Distance, Energy);
                //TODO do something with the received package
                foreach(IBikeDataListener l in subscribers)
                {
                        l.OnBikeDataReceived(pack);
                    
                }
                //Listener.OnMessageReceived(new X7Data(Rpm, Power, Distance, Time, Energy));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.GetType());
            }
        }

        public void OnDataReceived(string e)
        {
            ParseData(e);
        }
    }
}
