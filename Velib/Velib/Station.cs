using System.Runtime.Serialization;

namespace Velib
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

        protected bool Equals(Station other)
        {
            return Number == other.Number && string.Equals(Name, other.Name) && string.Equals(address, other.address) &&
                   string.Equals(status, other.status) && bike_stands == other.bike_stands &&
                   available_bike_stands == other.available_bike_stands && available_bikes == other.available_bikes;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Station) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Number;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (address != null ? address.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (status != null ? status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ bike_stands;
                hashCode = (hashCode * 397) ^ available_bike_stands;
                hashCode = (hashCode * 397) ^ available_bikes;
                return hashCode;
            }
        }
    }
}