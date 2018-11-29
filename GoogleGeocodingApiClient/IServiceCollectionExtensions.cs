using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace GoogleGeocodingApiClient
{
    public static class IServiceCollectionExtensions
    {
        private const string Identifier = "GoogleGeocodingApi";
        
        public static IServiceCollection AddGoogleGeocodingApiClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<GoogleGeocodingApiClientOptions>(configuration.GetSection(Identifier));
            services.TryAddTransient<IGoogleGeocodingApiClient>((sp) =>
            {
                var options = sp.GetService<IOptions<GoogleGeocodingApiClientOptions>>().Value;
                return new GoogleGeocodingApiClient(options);
            });

            return services;
        }
    }
}