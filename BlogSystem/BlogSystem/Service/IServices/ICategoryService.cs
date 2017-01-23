using Core.Entities;
using Service.Utilities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface ICategoryService : IBaseService
    {
        List<Category> GetAllTreeItems();
        List<TwoLevelDropDownItem> GetAllTwoLevelDropDownItems(int? isSelected = null);
        Category GetByID(int? ID);

        int? Add(Category category);
        List<int?> AddRange(List<Category> categories);

        void Update(Category category);

        void Remove(Category category);
        void RemoveRange(List<Category> categories);
    }
}
