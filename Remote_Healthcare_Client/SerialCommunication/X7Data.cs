using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Healthcare_Client.SerialCommunication
{
    class X7Data
    {
        private int Power { get; }
        private int Distance { get; }
        private DateTime Time { get; }
        private int Energy { get; }
        private int Rpm { get; }

        public X7Data(String rpm, String power, String distance, String time, String energy)
        {
            this.Power = int.Parse(power);
            this.Distance = int.Parse(distance);
            this.Time = DateTime.Parse(time);
            this.Energy = int.Parse(energy);
            this.Rpm = int.Parse(rpm);
        }

        public override string ToString()
        {
            //String Response = $"|{this.Distance}M|{this.Rpm}RPM|{this.Power}%|{this.Energy}J|{this.Time.ToString()}|";
            String Response = "true";
            return Response;
        }
    }
}
