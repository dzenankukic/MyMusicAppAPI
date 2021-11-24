using AutoMapper;
using MyMusicAppAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Mapper
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<User, MyMusicAppData.User>().ReverseMap();
            CreateMap<User, MyMusicAppData.Requests.User.UserUpsertRequest>().ReverseMap();
            CreateMap<MyMusicAppData.User, MyMusicAppData.Requests.User.UserUpsertRequest>().ReverseMap();

            CreateMap<Song, MyMusicAppData.Song> ().ReverseMap();
            CreateMap<Song, MyMusicAppData.Requests.Song.SongUpsertRequest>().ReverseMap();
            CreateMap<MyMusicAppData.Song, MyMusicAppData.Requests.Song.SongSearchRequest>().ReverseMap();

            CreateMap<Category, MyMusicAppData.Category>().ReverseMap();
            CreateMap<Category, MyMusicAppData.Requests.Category.CategoryUpsertRequest>().ReverseMap();
            CreateMap<MyMusicAppData.Category, MyMusicAppData.Requests.Song.SongSearchRequest>().ReverseMap();
        }
    }
}
