using Core.Entities;
using Core.IRepositries;
using Service.IServices;
using Service.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = GetRepository<Category>();
        }

        public List<Category> GetAllTreeItems()
        {
            var categories = _categoryRepository.GetAll(orderBy: ob => ob.OrderBy(c => c.SortIndex)).ToList();

            return categories;
        }

        public List<TwoLevelDropDownItem> GetAllTwoLevelDropDownItems(int? isSelected = null)
        {
            var categories = _categoryRepository.Get
                (
                    filter: c => c.ParentID == null,
                    orderBy: ob => ob.OrderBy(c => c.SortIndex),
                    includes: c => c.Childrens
                ).Select(c => new TwoLevelDropDownItem
                {
                    Caption = c.Caption,
                    SecondLevelItems = c.Childrens.Select(cc => new SimpleKeyValueDropDownItem<int?, string>
                    {
                        Key = cc.ID,
                        Value = cc.Caption,
                        IsSelected = cc.ID == isSelected
                    }).ToList()
                }).ToList();

            return categories;
        }

        public Category GetByID(int? ID)
        {
            var category = _categoryRepository.GetByID(ID);

            return category;
        }

        public int? Add(Category category)
        {
            _categoryRepository.Add(category);
            _categoryRepository.Complate();
            IsError = _categoryRepository.IsError;

            return category.ID;
        }

        public List<int?> AddRange(List<Category> categories)
        {
            _categoryRepository.AddRange(categories);
            _categoryRepository.Complate();
            IsError = _categoryRepository.IsError;

            return categories.Select(c => c.ID).ToList();
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
            _categoryRepository.Complate();
            IsError = _categoryRepository.IsError;

        }

        public void Remove(Category category)
        {
            _categoryRepository.Remove(category);
            _categoryRepository.Complate();
            IsError = _categoryRepository.IsError;
        }

        public void RemoveRange(List<Category> categories)
        {
            _categoryRepository.RemoveRange(categories);
            _categoryRepository.Complate();
            IsError = _categoryRepository.IsError;
        }
    }
}
