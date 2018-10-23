using Remote_Healthcare_Client.DataHandling;
using System.Threading;

namespace Remote_Healthcare_Client.Bicycle
{
    class BikePoller
    {
        private bool alive = true;
        public BikePoller()
        {

        }

        public void Start()
        {
            while (alive)
            {
                Thread.Sleep(1000);
                SerialDataHandler.getInstance().RequestStatus();
            }
        }

        public void Stop()
        {
            alive = false;
        }
    }
}
