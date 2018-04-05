using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Velib
{
    public class VelibIntermediary : IVelibIntermediary
    {
        public const string ApiKey = "d7cafd31e65fdec0da9453cdbc233b905518e399";
        public static List<DateTime> DistantRequests = new List<DateTime>();
        public static List<DateTime> Connections = new List<DateTime>();

        public async Task<List<Station>> GetStations(string city)
        {
            Connections.Add(DateTime.Now);
            List<Station> stations =
                await Caching.GetObjectFromCache($"{city}Stations", 1, () => (RequestStations(city)));
            return stations;
        }

        private async Task<List<Station>> RequestStations(string city)
        {
            DistantRequests.Add(DateTime.Now);
            WebRequest webRequest =
                WebRequest.Create(
                    $"https://api.jcdecaux.com/vls/v1/stations?contract={city}&apiKey={ApiKey}");
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            var response = await webRequest.GetResponseAsync();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);

            reader.Close();
            response.Close();
            return stations;
        }

        public async Task<List<Contract>> GetContracts()
        {
            Connections.Add(DateTime.Now);
            var contracts = await Caching.GetObjectFromCache("contracts", 10, RequestContracts);
            return contracts;
        }

        private async Task<List<Contract>> RequestContracts()
        {
            DistantRequests.Add(DateTime.Now);
            WebRequest webRequest =
                WebRequest.Create(
                    $"https://api.jcdecaux.com/vls/v1/contracts?apiKey={ApiKey}");
            var responseAsync = await webRequest.GetResponseAsync();
            var response = new StreamReader(responseAsync.GetResponseStream()).ReadToEnd();
            Console.WriteLine(response);
            var contracts = JsonConvert.DeserializeObject<List<Contract>>(response);
            return contracts;
        }

    }
}