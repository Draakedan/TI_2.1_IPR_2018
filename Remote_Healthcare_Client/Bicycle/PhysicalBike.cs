using Remote_Healthcare_Client.SerialCommunication;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Remote_Healthcare_Client.Bicycle
{
    class PhysicalBike : Bike
    {
        private SerialManager Manager;
        private Thread worker;
        public Queue<String> Outgoing;

        public PhysicalBike(String COMPort, IX7DataListener listener)
        {
            Outgoing = new Queue<string>();
            Manager = new SerialManager(listener,this,COMPort, 9600, 0);
            worker = new Thread(new ThreadStart(Manager.Start));
            worker.Start();
        }

        public override string GetID()
        {
            throw new NotImplementedException();
        }

        public override void GetVariables()
        {
            Outgoing.Enqueue("ST");
        }

        public override void Reset()
        {
            Outgoing.Enqueue("RS");
        }

        public override void SetDistance(int hectometers)
        {
            Outgoing.Enqueue($"PD{hectometers}");
        }

        public override void SetEnergy(int kiloJoules)
        {
            Outgoing.Enqueue($"PE{kiloJoules}");
        }

        public override void SetPower(int speed)
        {
            Outgoing.Enqueue($"PW{speed}");
        }

        public override void SetTime(int seconds)
        {
            Outgoing.Enqueue($"PT{(int)(Math.Floor((decimal)seconds / 60))}{seconds % 60}");
        }

        public override void SetTime(DateTime time)
        {
            Outgoing.Enqueue($"PT{time.Minute}{time.Second}");
        }

        protected override void StartEdit()
        {
            Outgoing.Enqueue($"CD");
        }

        public override void SetCountdownMode()
        {
            Outgoing.Enqueue("CD");
        }

        public override void SetCountupMode()
        {
            Outgoing.Enqueue("CM");
        }
    }
}
