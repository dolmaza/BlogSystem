using Core.Entities;
using Service.Utilities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IDictionaryService : IBaseService
    {
        List<Dictionary> GetAllTreeItems();
        Dictionary GetByID(int? ID);
        List<SimpleKeyValueDropDownItem<int?, string>> GetAllDropDownPostStatusItems(int? selectedID = null);
        List<SimpleKeyValueDropDownItem<int?, string>> GetAllDropDownPostLanguageItems(int? selectedID = null);

        int? Add(Dictionary dictionary);
        List<int?> AddRange(List<Dictionary> dictionaries);

        void Update(Dictionary dictionary);

        void Remove(Dictionary dictionary);
        void RemoveRange(List<Dictionary> dictionaries);
    }
}
