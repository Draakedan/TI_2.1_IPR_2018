using System;

namespace Remote_Healthcare_Client.Bicycle
{
    class BikeDataPackage
    {
        public string time;
        public string power;
        public string rpm;
        public string distance;
        public string energy;

        public BikeDataPackage(string time, string power, string rpm, string distance, string energy)
        {
            this.time = time;
            this.power = power;
            this.rpm = rpm;
            this.distance = Convert.ToString(Convert.ToDouble(distance) / 10);
            this.energy = Convert.ToString(Convert.ToDouble(energy) / 10);
        }

        public override string ToString()
        {
            return $"{time} seconds | {power} % | {rpm} rpm | {distance} km | {energy} J/s";
        }

        public static bool compare(BikeDataPackage pack1, BikeDataPackage pack2)
        {
            if(pack1.GetHashCode() == pack2.GetHashCode())
            {
                return true;
            }
            return false;
        }
    }
}
