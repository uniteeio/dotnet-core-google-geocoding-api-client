# A .NET Core 2 client for Google geocoding API

Nuget package can be found here : https://www.nuget.org/packages/Unitee.GoogleGeocoding.ApiClient

This package allow you to geocode a postal address via the Google geocoding API.

## Usage for a dotnet core mvc application

### Install package

dotnet add package Unitee.GoogleGeocoding.ApiClient


### Configuration

Add Google Api key in the root of your appsettings.json :

<pre>
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  <b>"GoogleGeocodingApi": {
    "ApiKey": "11111cd89cb4b2ecd77decd5d5fd778965403779d7f3ba1abba459901c4gg4d5d",
  }</b>
}
</pre>

Add GoogleGeocodingApiClient service in your Startup.cs file :
<pre>
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    <b>services.AddGoogleGeocodingApiClientService(Configuration); </b>
}
</pre>
        
### Service injection
Inject GoogleGeocodingApiClient service in your class (controller, ...) : 
<pre>
private readonly IGoogleGeocodingApiClient _googleGeocodingApiClient;

public ValuesController(IGoogleGeocodingApiClient googleGeocodingApiClient)
{
    _googleGeocodingApiClient = googleGeocodingApiClient;
}
</pre>

Use Geocode method in order to geocode a raw address :
```
[HttpGet]
public async Task<ActionResult<GeocodedAddress>> Get()
{
    return await _googleGeocodedApiClient.Geocode(
        "1 rue du Général Maurice Guillaudot 35000 Rennes"
     );
}
```
This will output :

```
{
    Address : "1 Rue du Général Maurice Guillaudot, 35000 Rennes, France",
    Street : "Rue du Général Maurice Guillaudot",
    StreetNumber : "1",
    City : "Rennes",
    Department : "Ille-et-Vilaine",
    DepartmentCode : "35",
    ZipCode : "35000",
    Country : "France",
    Lat : 48.115157,
    Lng : -1.67415 
}
```

