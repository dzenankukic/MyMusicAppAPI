using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusicAppAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : ControllerBase
    {
        private readonly IBaseCRUDRepository<T, TSearch, TInsert, TUpdate> _repository = null;
        public BaseCRUDController(IBaseCRUDRepository<T, TSearch, TInsert, TUpdate> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] TInsert request)
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
        public IActionResult Get([FromQuery] TSearch request)
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

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody] TUpdate request)
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
    }
}
