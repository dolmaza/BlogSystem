using Core.Entities;
using Core.IRepositries;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Repositories
{
    public class DictionaryRepository : Repository<Dictionary>, IDictionaryRepository
    {
        public DictionaryRepository(DbContext context)
            : base(context)
        {
        }

        public List<Dictionary> GetAllByCodeAndLevel(int? code, int? level)
        {
            return Get(d => d.Code == code && d.Level == level, od => od.OrderBy(d => d.SortIndex)).ToList();
        }
    }
}
