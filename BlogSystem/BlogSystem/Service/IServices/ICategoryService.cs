using Core.Entities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface ICategoryService : IBaseService
    {
        List<Category> GetAllTreeItems();
        Category GetByID(int? ID);

        int? Add(Category category);
        List<int?> AddRange(List<Category> categories);

        void Update(Category category);

        void Remove(Category category);
        void RemoveRange(List<Category> categories);
    }
}
