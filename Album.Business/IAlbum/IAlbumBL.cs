using Album.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Business.IAlbum
{
    public interface IAlbumBL
    {
        Task<List<AlbumDto>> GetAlbums(CancellationToken cancellationToken);
        Task<bool> UpdateAlbum(AlbumDto albumDto, CancellationToken cancellationToken);
        Task<List<AlbumDto>> GetAlbumTrack(List<AlbumDto> albumIds, CancellationToken cancellationToken);
    }
}
