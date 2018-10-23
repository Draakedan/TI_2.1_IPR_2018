using Remote_Healthcare_Client.DataHandling;
using Remote_Healthcare_Client.ServerConnection;
using System;

namespace Remote_Healthcare_Client
{
    class Program
    {
        static int _BIKE_MODE = 1; // 0 = realbike, 1 = simbike
        static string _SERVER_IP = "145.49.33.3";

        static void Main(string[] args)
        {
            // The IP Address of the Server to connect to


            Console.WriteLine("---  Setting up VR ---");
            VRHandler.getInstance().SetupScene(400, 400);
            Console.WriteLine("---  VR scene loaded succesfully   ---");
            Console.WriteLine("");
            Console.WriteLine("---  Setting up Bicycle   ---");
            SerialDataHandler.getInstance().InitializeBike(_BIKE_MODE);
            VRHandler.getInstance().StartBikePoller();
            Console.WriteLine("---  Bicycle setup succesful ---");
            Console.WriteLine("");
            Console.WriteLine("---  Connecting to Remote-Healthcare server  ---");
            //Connection con = new Connection("145.49.2.246", 6666);
            Connection con = new Connection(_SERVER_IP, 6666);
            Console.WriteLine("---  Connected sucesfully to Remote-Healthcare server  ---");
            Console.ReadLine();
        }
    }
}
