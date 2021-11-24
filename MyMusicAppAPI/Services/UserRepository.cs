using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyMusicAppAPI.Database;
using MyMusicAppData.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MyMusicAppAPI.Services
{
    public class UserRepository: IUserRepository
    {
        private AppDBContext _context;
        private IMapper _mapper;

        public UserRepository(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        private static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public MyMusicAppData.User Authenticate(string username, string password)
        {
            var user = _context.User.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, password);
                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<MyMusicAppData.User>(user);
                }
            }
            return null;
        }

   


        public MyMusicAppData.User Register(UserUpsertRequest request)
        {
            var entity = _mapper.Map<MyMusicAppAPI.Database.User>(request);


            if (request.Password != request.PasswordConfirm)
            {
                throw new Exception("Password and password confirm are not same!");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.User.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<MyMusicAppData.User >(entity);
        }

        public MyMusicAppData.User Insert(UserUpsertRequest model)
        {
            MyMusicAppAPI.Database.User user = _mapper.Map<MyMusicAppAPI.Database.User>(model);

            _context.Add(user);

            if (model.Password != model.PasswordConfirm)
            {
                throw new Exception("Password and password confirm are not same!");
            }

            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordSalt, model.Password);
            _context.SaveChanges();

            return _mapper.Map<MyMusicAppData.User >(user);
        }

        public IEnumerable<MyMusicAppData.User> Get(UserSearchRequest request)
        {
            var query = _context.User.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(request?.LastName))
            {
                query = query.Where(x => x.LastName.Contains(request.LastName));
            }

            if (!string.IsNullOrWhiteSpace(request?.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            return _mapper.Map<IEnumerable<MyMusicAppData.User >>(query).ToList();
        }

        public MyMusicAppData.User GetById(int id)
        {
            return _mapper.Map<MyMusicAppData.User >(_context.User.Find(id));
        }

        public MyMusicAppData.User Update(int id, UserUpsertRequest model)
        {
            var entity = _context.User.Find(id);
            if (!string.IsNullOrEmpty(model.Password))
            {
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, model.Password);
            }

            _mapper.Map(model, entity);
            _context.User.Attach(entity);
            _context.User.Update(entity);
            _context.SaveChanges();

            return _mapper.Map<MyMusicAppData.User >(entity);
        }

        public MyMusicAppData.User Delete(int id)
        {
            MyMusicAppAPI.Database.User user = _context.User.Find(id);

            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }

            return _mapper.Map<MyMusicAppData.User >(user);
        }

        public MyMusicAppData.User GetByUsername(UserLoginRequest request)
        {
            return _mapper.Map<MyMusicAppData.User >(_context.User.FirstOrDefault(u => u.Username == request.Username));
        }

        public IEnumerable<MyMusicAppData.User > GetClients()
        {
            throw new NotImplementedException();
        }

        public MyMusicAppData.User Login(UserLoginRequest request)
        {
            var entity = _context.User.FirstOrDefault(x => x.Username == request.Username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.PasswordSalt, request.Password);

            if (hash != entity.PasswordHash)
            {
                return null;
            }

            return _mapper.Map<MyMusicAppData.User>(entity);

        }
    }
}
