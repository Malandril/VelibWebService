using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            var inst = new InstanceContext(new VelibEventImpl());
            var velibSubscriberClient = new EventService.VelibSubscriberClient(inst);
            Console.WriteLine("input station name");
            var stationName = Console.ReadLine();
            Console.WriteLine("input city name");
            var cityName = Console.ReadLine();

            velibSubscriberClient.SubscribeStationChanged(stationName, cityName, 5);
            Console.ReadLine();
        }
    }
}