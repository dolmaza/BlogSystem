using Core.Entities;
using System.Collections.Generic;

namespace Core.IRepositries
{
    public interface IDictionaryRepository : IRepository<Dictionary>
    {
        List<Dictionary> GetAllByCodeAndLevel(int? code, int? level);
    }
}
