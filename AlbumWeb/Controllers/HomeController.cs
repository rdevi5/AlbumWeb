using Album.Business.IAlbum;
using Album.Business.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlbumWeb.Controllers
{
    public class HomeController : Controller
    {        
        private readonly IAlbumBL albumBL;
        public HomeController(IAlbumBL albumBL)
        {            
            this.albumBL = albumBL;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {                       
            return View(await albumBL.GetAlbums(cancellationToken));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new AlbumWeb.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}