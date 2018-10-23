using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Remote_Healthcare.DataHandling;

namespace Remote_Healthcare.Bicycle
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
