using Album.Business.Album;
using Album.Business.IAlbum;
using Album.Business.Mapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Album.Business
{
    public static class BusinessConfig
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services)
        {            
            services.AddScoped<IAlbumBL, AlbumBL>();
            AddMapperConfiguration(services);
            return services;
        }

        private static void AddMapperConfiguration(IServiceCollection services)
        {
            var mapperconfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new AlbumProfile());
            });
            services.AddSingleton<IMapper>(o => mapperconfig.CreateMapper());
        }

    }
}