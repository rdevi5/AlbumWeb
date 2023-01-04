using Album.Business.Model;
using Album.Service.Model;
using AutoMapper;

namespace Album.Business.Mapper
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<AlbumDto, AlbumModel>().ReverseMap();
        }
    }
}
