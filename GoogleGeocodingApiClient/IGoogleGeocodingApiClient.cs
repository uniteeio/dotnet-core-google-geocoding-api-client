using System.Threading.Tasks;
using GoogleGeocodingApiClient.Models;

namespace GoogleGeocodingApiClient
{
    public interface IGoogleGeocodingApiClient
    {
        Task<GeocodedAddress> Geocode(string address);
    }
}