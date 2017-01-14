using Core.Entities;
using Service.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public List<Category> GetAllTreeItems()
        {
            var categories = UnitOfWork.CategoryRepository.GetAll(orderBy: ob => ob.OrderBy(c => c.SortIndex)).ToList();

            return categories;
        }

        public Category GetByID(int? ID)
        {
            var category = UnitOfWork.CategoryRepository.GetByID(ID);

            return category;
        }

        public int? Add(Category category)
        {
            UnitOfWork.CategoryRepository.Add(category);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

            return category.ID;
        }

        public List<int?> AddRange(List<Category> categories)
        {
            UnitOfWork.CategoryRepository.AddRange(categories);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

            return categories.Select(c => c.ID).ToList();
        }

        public void Update(Category category)
        {
            UnitOfWork.CategoryRepository.Update(category);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

        }

        public void Remove(Category category)
        {
            UnitOfWork.CategoryRepository.Remove(category);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;
        }

        public void RemoveRange(List<Category> categories)
        {
            UnitOfWork.CategoryRepository.RemoveRange(categories);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;
        }
    }
}
