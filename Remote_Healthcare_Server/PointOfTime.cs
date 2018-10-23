using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Healthcare_Server
{
    class PointOfTime
    {
        public DateTime time;
        public int power;
        public double distance;
        public int energy;
        public double speed;
        public int bikeTime;

        //public PointOfTime(int power, double distance, int energy, double speed, int bikeTime)
        //{
        //    this.time = DateTime.Now;
        //    this.power = power;
        //    this.distance = distance;
        //    this.energy = energy;
        //    this.speed = speed;
        //    this.bikeTime = bikeTime;
        //}
        public PointOfTime(int power, double distance, double energy, double speed, string bikeTime)
        {
            this.time = DateTime.Now;
            this.power = power;
            this.distance = distance;
            this.energy = (int)energy;
            this.speed = speed;
            if (bikeTime.Contains(":"))
            {
                string[] timeconverting = bikeTime.Split(':');
                this.bikeTime = (int.Parse(timeconverting[0]) * 60) + int.Parse(timeconverting[1]);
            }
            else
                this.bikeTime = int.Parse(bikeTime);
        }

        public override string ToString()
        {
            return $"Time of recording: {time}\r\nPower: {power} Watt\r\nDistance: {distance} Km\r\nEnergy: {energy} Kj\r\nSpeed: {speed} rpm\r\nRemaining bike time: {bikeTime} seconds\r\n";
        }
    }
}
