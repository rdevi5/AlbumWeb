using Microsoft.AspNetCore.Mvc;
using Album.Business.IAlbum;
using System.Diagnostics;
using Album.Business.Model;

namespace AlbumWeb.Controllers
{
    public class AlbumController : Controller
    {        
        private readonly IAlbumBL albumBL;

        public AlbumController(IAlbumBL albumBL)
        {            
            this.albumBL = albumBL;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {                                
            return View(await albumBL.GetAlbums(cancellationToken));
        }
        public IActionResult UpdateAlbum(int albumid, string title)
        {
            var data = new AlbumDto();
            data.AlbumName = title;
            data.AlbumId = albumid;
            return View("Update", data);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitAlbum(AlbumDto albumDto, CancellationToken cancellationToken)
        {            
            var result = await albumBL.UpdateAlbum(albumDto, cancellationToken);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View("Update", albumDto);
        }
        public async Task<IActionResult> TracksAlbum(List<AlbumDto> albums, CancellationToken cancellationToken)
        {            
            var AlbumIds = (from a in albums where a.IsChecked == true select new AlbumDto() { AlbumId = a.AlbumId }).ToList();

            var result = await albumBL.GetAlbumTrack(AlbumIds, cancellationToken);
            if (result != null)
            {
                return View("Tracks", result);
            }
            return base.View("Tracks", new AlbumDto());
        }

    }
}
