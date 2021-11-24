using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusicAppAPI.Services;
using MyMusicAppData;
using MyMusicAppData.Requests.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SongController : BaseCRUDController<MyMusicAppData.Song, SongSearchRequest, SongUpsertRequest, SongUpsertRequest>
    {
        public SongController(IBaseCRUDRepository<Song, SongSearchRequest, SongUpsertRequest, SongUpsertRequest> repository) : base(repository)
        {

        }
    }
}
