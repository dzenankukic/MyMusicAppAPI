using AutoMapper;
using MyMusicAppAPI.Database;
using MyMusicAppData.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Services
{
    public class CategoryRepository : BaseCRUDRepository<MyMusicAppData.Category, CategorySearchRequest, Category, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(AppDBContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IEnumerable<MyMusicAppData.Category> Get(CategorySearchRequest request)
        {
            var query = _context.Category.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.Contains(request.Name));
            }

            return _mapper.Map<IEnumerable<MyMusicAppData.Category>>(query.ToList());
        }
    }
}
