using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Services
{
    public interface IBaseCRUDRepository<T, TSearch, TInsert, TUpdate>
    {
        T Insert(TInsert model);
        IEnumerable<T> Get(TSearch request);
        T GetById(int id);
        T Update(int id, TUpdate model);
        T Delete(int id);
    }
}
