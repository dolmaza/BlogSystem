using Core.Entities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IDictionaryService : IBaseService
    {
        IEnumerable<Dictionary> GetAllTreeItems();
        Dictionary GetByID(int? ID);

        int? Add(Dictionary dictionary);
        IEnumerable<int?> AddRange(List<Dictionary> dictionaries);

        void Update(Dictionary dictionary);

        void Remove(Dictionary dictionary);
        void RemoveRange(List<Dictionary> dictionaries);
    }
}
