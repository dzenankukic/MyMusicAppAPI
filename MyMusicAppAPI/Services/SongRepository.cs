using AutoMapper;
using MyMusicAppAPI.Database;
using MyMusicAppData.Requests.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Services
{
    public class SongRepository : BaseCRUDRepository<MyMusicAppData.Song, SongSearchRequest,Song, SongUpsertRequest, SongUpsertRequest>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public SongRepository(AppDBContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IEnumerable<MyMusicAppData.Song> Get(SongSearchRequest request)
        {
            var query = _context.Song.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.Contains(request.Name));
            }

            if (!string.IsNullOrWhiteSpace(request?.ArtistName))
            {
                query = query.Where(x => x.ArtistName.Contains(request.ArtistName));
            }

            //if (!string.IsNullOrWhiteSpace(request?.EntredDAte.ToString()))
            //{
            //    query = query.Where(x => x.EntredDAte.ToString().Contains(request.EntredDAte.ToString()));
            //}

            return _mapper.Map<IEnumerable<MyMusicAppData.Song>>(query.ToList());
        }
    }
}
