using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Healthcare_Client.Patient
{
    class Patient
    {
        public string name { get; set; }
        public List<PointOfTime> timeList { get; set; }

        public Patient()
        {
            timeList = new List<PointOfTime>();
        }

        public Patient(string patientName)
        {
            name = patientName;
            timeList = new List<PointOfTime>();
        }

        public void addPointOfTime(PointOfTime point)
        {
            timeList.Add(point);
        }

        public void removePointOfTime(PointOfTime point)
        {
            timeList.Remove(point);
        }
    }
}
