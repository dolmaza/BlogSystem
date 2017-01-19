using Core.Entities;
using Service.IServices;
using Service.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class DictionaryService : BaseService, IDictionaryService
    {
        public List<Dictionary> GetAllTreeItems()
        {
            var dictionaries = UnitOfWork.DictionaryRepository.GetAll(orderBy: ob => ob.OrderBy(d => d.SortIndex)).ToList();

            return dictionaries;
        }

        public Dictionary GetByID(int? ID)
        {
            var dictionary = UnitOfWork.DictionaryRepository.GetByID(ID);

            return dictionary;
        }

        public List<SimpleKeyValueDropDownItem<int?, string>> GetAllDropDownPostStatusItems(int? selectedID = null)
        {
            var postStatus =
                UnitOfWork.DictionaryRepository.GetAllByCodeAndLevel(DictionaryCode.POSTSTATUS, 1)
                    .Select(p => new SimpleKeyValueDropDownItem<int?, string>
                    {
                        Key = p.ID,
                        Value = p.Caption,
                        IsSelected = p.ID == selectedID
                    })
                    .ToList();

            return postStatus;
        }

        public List<SimpleKeyValueDropDownItem<int?, string>> GetAllDropDownPostLanguageItems(int? selectedID = null)
        {
            var postLanguages =
                UnitOfWork.DictionaryRepository.GetAllByCodeAndLevel(DictionaryCode.POSTLANGUAGE, 1)
                    .Select(p => new SimpleKeyValueDropDownItem<int?, string>
                    {
                        Key = p.ID,
                        Value = p.Caption,
                        IsSelected = p.ID == selectedID
                    })
                    .ToList();

            return postLanguages;
        }

        public int? Add(Dictionary dictionary)
        {
            UnitOfWork.DictionaryRepository.Add(dictionary);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

            return dictionary.ID;
        }

        public List<int?> AddRange(List<Dictionary> dictionaries)
        {
            UnitOfWork.DictionaryRepository.AddRange(dictionaries);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

            return dictionaries.Select(u => u.ID).ToList();
        }

        public void Update(Dictionary dictionary)
        {
            UnitOfWork.DictionaryRepository.Update(dictionary);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

        }

        public void Remove(Dictionary dictionary)
        {
            UnitOfWork.DictionaryRepository.Remove(dictionary);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

        }

        public void RemoveRange(List<Dictionary> dictionaries)
        {
            UnitOfWork.DictionaryRepository.RemoveRange(dictionaries);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

        }
    }
}
