using Newtonsoft.Json;
using Remote_Healthcare_Client.Bicycle;

namespace Remote_Healthcare_Client.ServerConnection
{
    class ServerCommands
    {
        public static int BikeID = 0;

        public static string SendBikeData(string time, string rpm, string distance, string energy, string power)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "data",
                origin = BikeID,
                data = new
                {
                    time = time,
                    rpm = rpm,
                    distance = distance,
                    energy = energy,
                    power = power
                }
            });
        }
        public static string SendBikeData(BikeDataPackage package)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "data",
                origin = BikeID,
                data = new
                {
                    time = package.time,
                    rpm = package.rpm,
                    distance = package.distance,
                    energy = package.energy,
                    power = package.power
                }
            });
        }

        public static string ClientType()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "client/type",
                data = new
                {
                    type = "patient"
                }
            });
        }
    }
}
