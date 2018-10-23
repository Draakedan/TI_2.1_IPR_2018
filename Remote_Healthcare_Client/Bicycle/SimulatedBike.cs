using Remote_Healthcare_Client.SerialCommunication;
using System;
using System.Threading;

namespace Remote_Healthcare_Client.Bicycle
{
    class SimulatedBike : Bike
    {
        private int rpm;
        private int distance;
        private int energy;
        private int power;
        private DateTime time;
        private string id;

        Thread worker;

        private IX7DataListener listener;
        private SimulationManipulator sm;

        public SimulatedBike(IX7DataListener listener, int id)
        {
            this.rpm = 0;
            this.distance = 0;
            this.energy = 0;
            this.time = new DateTime(1970, 1, 1, 0, 0, 0);
            this.power = 25;
            this.id = id.ToString();
            this.listener = listener;


            worker = new Thread(new ThreadStart(StartThread));
            worker.Start();
        }

        public void StartThread()
        {
            sm = new SimulationManipulator(this);
            sm.ShowDialog();
        }
        public void SetSpeed(int speed)
        {
            rpm = speed;
            GetVariables();
        }

        public override void SetPower(int speed)
        {
            this.power = (int)Math.Floor((speed * 4d) + 25d);
        }

        public override void SetDistance(int hectometers)
        {
            this.distance = hectometers / 10;
        }
        public override void SetEnergy(int kiloJoules)
        {
            energy = kiloJoules;
        }
        public override void SetTime(int seconds)
        {
            int min = (int)Math.Floor(seconds / 60.0);
            int sec = seconds % 60;
            time = new DateTime(1970, 01, 01, 0, min, sec);
            //time = new DateTime();
        }
        public override void SetTime(DateTime time)
        {
            this.time = time;
        }

        public override string GetID()
        {
            return id;
        }

        public override void SetCountdownMode()
        {
            Console.WriteLine($"{this} does not have that functionality");
        }

        public override void SetCountupMode()
        {
            Console.WriteLine($"{this} does not have that functionality");
        }

        public override void Reset()
        {
            this.rpm = 0;
            this.distance = 0;
            this.energy = 0;
            this.time = new DateTime(1970, 1, 1, 0, 0, 0);
            this.power = 25;
            this.id = "SimBike";
        }
        protected override void StartEdit()
        {
            this.rpm = 0;
            this.distance = 0;
            this.energy = 0;
            this.time = new DateTime(1970, 1, 1, 0, 0, 0);
            this.power = 25;
            this.id = "SimBike";
        }

        public override void GetVariables()
        {
            listener.OnDataReceived($"0|{this.rpm}|{this.energy}|0|{this.power}|{this.distance}|{this.time.Minute}:{this.time.Second}|0");
        }


    }
}
