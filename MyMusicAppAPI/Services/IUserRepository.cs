using MyMusicAppAPI.Database;
using MyMusicAppData.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Services
{
    public interface IUserRepository
    {
        IEnumerable<MyMusicAppData.User> Get(UserSearchRequest search);
        MyMusicAppData.User GetById(int id);
        MyMusicAppData.User Insert(UserUpsertRequest request);
        MyMusicAppData.User Update(int id, UserUpsertRequest request);
        MyMusicAppData.User Delete(int id);
        MyMusicAppData.User Login(UserLoginRequest request);
        MyMusicAppData.User Register(UserUpsertRequest request);
        MyMusicAppData.User Authenticate(string username, string password);
        MyMusicAppData.User GetByUsername(UserLoginRequest request);
    
    }
}
