using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Remote_Healthcare;

namespace Remote_Healthcare
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static string _SERVER_IP = "145.49.33.3";

        [STAThread]
        static void Main()
        {
            // IP Address oof the server the application will connect to


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DoctorInput(_SERVER_IP));
        }
    }
}
