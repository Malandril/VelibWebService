using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VelibClient;

namespace Velib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VelibIntermediary" in both code and config file together.
    public class VelibIntermediary : IVelibIntermediary
    {
        public string GetData(int value)
        {
            return $"You entered : {value}";
        }


        public async Task<List<Station>> GetStations(string city)
        {
            WebRequest webRequest =
                WebRequest.Create(
                    $"https://api.jcdecaux.com/vls/v1/stations?contract={city}&apiKey=d7cafd31e65fdec0da9453cdbc233b905518e399");
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            var response = await webRequest.GetResponseAsync();
            Console.WriteLine(((HttpWebResponse) response).StatusDescription);

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);

            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            return stations;
        }

        public async Task<List<Contract>> GetContracts()
        {
            WebRequest webRequest =
                WebRequest.Create(
                    $"https://api.jcdecaux.com/vls/v1/contracts?apiKey=d7cafd31e65fdec0da9453cdbc233b905518e399");
            var responseAsync = await webRequest.GetResponseAsync();
            var response = new StreamReader(responseAsync.GetResponseStream()).ReadToEnd();
            Console.WriteLine(response);
            var contracts = JsonConvert.DeserializeObject<List<Contract>>(response);
            return contracts;
        }
    }
}