using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Threading;
using Newtonsoft.Json;

namespace Velib
{
    public class VelibSubscriber : IVelibSubscriber
    {
        static List<Timer> timers = new List<Timer>();

        public void SubscribeStationChanged(string stationName, string cityName, int timeInSeconds)
        {
            IVelibEvent subscriber = OperationContext.Current.GetCallbackChannel<IVelibEvent>();
            timers.Add(new Timer(_ => Callback(subscriber, stationName, cityName), subscriber, 0,
                timeInSeconds * 1000));
        }

        private void Callback(IVelibEvent subscriber, string stationName, string cityName)
        {
            WebRequest webRequest =
                WebRequest.Create(
                    $"https://api.jcdecaux.com/vls/v1/stations?contract={cityName}&apiKey={VelibIntermediary.ApiKey}");
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            var response = webRequest.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);
            reader.Close();
            response.Close();
            subscriber.StationChanged(stations.Find(station => station.Name == stationName));
            Console.WriteLine("LOLOLOLOLOLOL");
        }
    }
}