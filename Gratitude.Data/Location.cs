namespace Gratitude.Data
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitde { get; set; }

        public Location() { }

        public Location(double latitude, double longitude) { Latitude = latitude; Longitde = longitude; }


    }
}