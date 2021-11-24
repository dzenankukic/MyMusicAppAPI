using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyMusicAppAPI.Database;
using MyMusicAppData.Requests.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _context;
        public AuthController(AppDBContext context)
        {
            _context = context;
        }
        //private static string GenerateSalt()
        //{
        //    var buf = new byte[16];
        //    (new RNGCryptoServiceProvider()).GetBytes(buf);
        //    return Convert.ToBase64String(buf);
        //}
        //private static string GenerateHash(string salt, string password)
        //{
        //    byte[] src = Convert.FromBase64String(salt);
        //    byte[] bytes = Encoding.Unicode.GetBytes(password);
        //    byte[] dst = new byte[src.Length + bytes.Length];

        //    System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        //    System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

        //    HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        //    byte[] inArray = algorithm.ComputeHash(dst);
        //    return Convert.ToBase64String(inArray);
        //}
        [HttpPost,Route("login")]
        public IActionResult Login([FromBody] UserLoginRequest User)
        {
            if (User == null || User.Username == "" || User.Password == "")
                return BadRequest("Inavlid request!");
            /*provjera passworda*/
            //User user = new User { 
            //    Username = User.Username,
            //    PasswordSalt = GenerateSalt()
            //};
            //user.PasswordHash = GenerateHash(user.PasswordSalt, User.Password);
            User user = _context.User.FirstOrDefault(x => x.Username == User.Username);
            if(user == null)
                return BadRequest("Inavlid request!");
            var model = _context.User.FirstOrDefault(x => x.PasswordHash == user.PasswordHash );
            if (model != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
            );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
                    }
            return Unauthorized();
        }
    
    }
}
