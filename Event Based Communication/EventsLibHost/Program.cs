using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EventsLibHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = new ServiceHost(typeof(EventsLib.CalcService));
                host.Open();
                Console.WriteLine("Service is Hosted as http://localhost:9011/CalcService");
                Console.WriteLine("Press  key to stop the service.");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception eX)
            {
                Console.WriteLine("There was en error while Hosting Service [" + eX.Message + "]");
                Console.WriteLine("Press  key to close.");
                Console.ReadLine();
            }
        }
    }
}
