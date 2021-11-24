using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusicAppAPI.Services;
using MyMusicAppData.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] UserUpsertRequest request)
        {
            try
            {
                return Ok(_repository.Insert(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery] UserSearchRequest request)
        {
            try
            {
                return Ok(_repository.Get(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //[HttpGet]
        //[Route("username")]
        //public IActionResult GetByUsername([FromQuery] UserLoginRequest request)
        //{
        //    try
        //    {
        //        return Ok(_repository.GetByUsername(request));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult Update(int id, [FromBody] UserUpsertRequest request)
        {
            try
            {
                return Ok(_repository.Update(id, request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_repository.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public IActionResult Login([FromBody] UserLoginRequest request)
        //{
        //    try
        //    {
        //        return Ok(_repository.Login(request));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}

        //[HttpPost]
        //[Route("register")]
        //public IActionResult Register([FromBody] UserUpsertRequest request)
        //{
        //    try
        //    {
        //        return Ok(_repository.Register(request));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}
    }
}
