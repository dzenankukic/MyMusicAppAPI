using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicAppData
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SongUrl { get; set; }
        public string ArtistName { get; set; }
        public int Rating { get; set; }
        public bool isFavourite { get; set; }
        public DateTime EntredDAte { get; set; }
        public DateTime EditDate { get; set; }
        public int CategoryID { get; set; }
    }
}
