using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusicAppAPI.Services;
using MyMusicAppData;
using MyMusicAppData.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyMusicAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : BaseCRUDController<MyMusicAppData.Category, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryController(IBaseCRUDRepository<Category , CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest> repository) : base(repository)
        {

        }
    }
}
