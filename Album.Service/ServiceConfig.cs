using Album.Service.IService;
using Album.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Album.Service
{
    public struct EndpointNames
    {
        public const string Album = nameof(Album);
    }

    public static class ServiceConfig
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAlbumService, AlbumService>();
            return services;
        }

    }

}