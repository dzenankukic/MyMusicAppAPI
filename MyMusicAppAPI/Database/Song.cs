using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Database
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SongUrl { get; set; }
        public string ArtistName { get; set; }
        public int Rating { get; set; }
        public bool isFavourite { get; set; }
        public DateTime EntredDAte { get; set; }
        public DateTime EditDate { get; set; }
        public int CategoryID { get; set; }        
        public virtual Category Category { get; set; }
    }
}
