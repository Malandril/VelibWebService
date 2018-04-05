using System;
using ClientEvent.EventService;

namespace ClientEvent
{
    public class VelibEventImpl : EventService.IVelibSubscriberCallback
    {

        public void StationChanged(Station station)
        {
            Console.WriteLine($"Station changed {station.Name} {station.available_bikes} {station.available_bike_stands}");
        }
    }
}