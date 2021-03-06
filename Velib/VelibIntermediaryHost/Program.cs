﻿using System;
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
            var serviceEvent = new ServiceHost(typeof(VelibSubscriber));
            var monitoring = new ServiceHost(typeof(Monitoring));
            Console.WriteLine("Starting soap service");
            Console.WriteLine("Press ENTER to stop the service");
            serviceHost.Open();
            serviceEvent.Open();
            monitoring.Open();
            Console.ReadLine();
            monitoring.Close();
            serviceEvent.Close();
            serviceHost.Close();
            Console.WriteLine("Stopping soap service");
        }
    }
}