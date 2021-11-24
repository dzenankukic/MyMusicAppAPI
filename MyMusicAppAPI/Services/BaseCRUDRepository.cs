using AutoMapper;
using MyMusicAppAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Services
{
    public class BaseCRUDRepository<T, TSearch, TDatabase, TInsert, TUpdate> : IBaseCRUDRepository<T, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        private readonly AppDBContext _context = null;
        private readonly IMapper _mapper = null;

        public BaseCRUDRepository(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CREATE
        public virtual T Insert(TInsert model)
        {
            var entity = _mapper.Map<TDatabase>(model);
            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }

        //READ
        public virtual IEnumerable<T> Get(TSearch request)
        {
            var list = _context.Set<TDatabase>().ToList();
            return _mapper.Map<IEnumerable<T>>(list);
        }

        //READ BY ID
        public virtual T GetById(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            return _mapper.Map<T>(entity);
        }

        //UPDATE
        public virtual T Update(int id, TUpdate model)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _mapper.Map(model, entity);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);
            _mapper.Map(model, entity);
            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }

        //DELETE
        public virtual T Delete(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }
    }
}
