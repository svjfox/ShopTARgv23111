namespace ShopTARgv23.Models.AccuWeathers
{
    public class CityModel
    {

        public string Key { get; set; }

        public string LocalizedName { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string TimeZone { get; set; }

        public string GeoPosition { get; set; }
        public CityModel() { }
        public CityModel(string key, string localizedName, int rank, string name, string description, string country, string region, string timeZone, string geoPosition)
        {
            Key = key;
            LocalizedName = localizedName;
            Rank = rank;
            Name = name;
            Description = description;
            Country = country;
            Region = region;
            TimeZone = timeZone;
            GeoPosition = geoPosition;
        }
    }
}
