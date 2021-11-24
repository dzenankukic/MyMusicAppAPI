using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicAppData.Requests.Song
{
    public class SongSearchRequest
    {
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public DateTime EntredDAte { get; set; }
    }
}
