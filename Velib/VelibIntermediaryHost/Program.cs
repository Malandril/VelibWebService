using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Velib;

namespace VelibIntermediaryHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(VelibIntermediary));
            Console.WriteLine("Starting soap service");
            Console.WriteLine("Press ENTER to stop the service");
            serviceHost.Open();
            Console.ReadLine();
            serviceHost.Close();
            Console.WriteLine("Stopping soap service");
        }
    }
}