namespace GoogleGeocodingApiClient.Models
{
    public class GeocodedAddress
    {
        public string Address { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string DepartmentCode { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}