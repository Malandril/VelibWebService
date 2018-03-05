using System.Runtime.Serialization;

namespace VelibClient
{
    [DataContract]
    public class Station
    {
        public int Number { get; set; }
        [DataMember] public string Name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        [DataMember] public string status { get; set; }
        public string contract_name { get; set; }
        public int bike_stands { get; set; }
        [DataMember] public int available_bike_stands { get; set; }
        [DataMember] public int available_bikes { get; set; }
        public long last_update { get; set; }

        public Station(int number, string name, string address, Position position)
        {
            this.Number = number;
            this.Name = name;
            this.address = address;
            this.position = position;
        }


        public class Position
        {
            public double lat { get; set; }
            public double lng { get; set; }

            public override string ToString()
            {
                return $"{nameof(lat)}: {lat}, {nameof(lng)}: {lng}";
            }

            public Position(double lat, double lng)
            {
                this.lat = lat;
                this.lng = lng;
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(Number)}: {Number}, {nameof(Name)}: {Name}, {nameof(address)}: {address}, {nameof(position)}: {position}";
        }
    }
}