using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Remote_Healthcare;
using Remote_Healthcare.Graphical_Interfaces;

namespace Remote_Healthcare.Bicycle
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
            this.power = (int)Math.Floor((speed * 3.75) + 25);
        }
        public override void SetDistance(int hectometers)
        {
            distance = distance / 10;
        }
        public override void SetEnergy(int kiloJoules)
        {
            energy = kiloJoules;
        }
        public override void SetTime(int seconds)
        {
            time = new DateTime(0, 0, 0, 0, (int)Math.Floor(seconds / 60.0), seconds % 60);
        }
        public override void SetTime(DateTime time)
        {
            this.time = time;
        }

        public override string GetID()
        {
            return id;
        }

        public override void Reset()
        {
            this.rpm = 0;
            this.distance = 0;
            this.energy = 0;
            this.time = new DateTime(0, 0, 0, 0, 0, 0);
            this.power = 25;
            this.id = "SimBike";
        }
        protected override void StartEdit()
        {
            this.rpm = 0;
            this.distance = 0;
            this.energy = 0;
            this.time = new DateTime(0, 0, 0, 0, 0, 0);
            this.power = 25;
            this.id = "SimBike";
        }

        public override void GetVariables()
        {
            listener.OnDataReceived($"0|0|0|{this.rpm}|{this.power}|{this.distance}|{this.time}|0");
        }
    }
}
