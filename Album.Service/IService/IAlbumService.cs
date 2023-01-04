using Album.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Service.IService
{
    public interface IAlbumService
    {
        Task<List<AlbumModel>> GetAlbums(CancellationToken cancellationToken);
        Task<bool> UpdateAlbum(AlbumModel albumDto, CancellationToken cancellationToken);
        Task<List<AlbumModel>> GetAlbumTrack(List<AlbumModel> albumIds, CancellationToken cancellationToken);
    }
}
