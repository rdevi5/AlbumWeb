using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Service.Model
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; } = String.Empty;
        public bool IsChecked { get; set; }              
        public string TrackName { get; set; } = String.Empty;
    }
}
