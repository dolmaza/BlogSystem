using Core.Entities;
using Core.IRepositries;
using Service.IServices;
using Service.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class DictionaryService : BaseService, IDictionaryService
    {
        private readonly IRepository<Dictionary> _dictionaryRepository;

        public DictionaryService()
        {
            _dictionaryRepository = GetRepository<Dictionary>();
        }

        public List<Dictionary> GetAllTreeItems()
        {
            var dictionaries = _dictionaryRepository.GetAll(orderBy: ob => ob.OrderBy(d => d.SortIndex)).ToList();

            return dictionaries;
        }

        public Dictionary GetByID(int? ID)
        {
            var dictionary = _dictionaryRepository.GetByID(ID);

            return dictionary;
        }

        public List<SimpleKeyValueDropDownItem<int?, string>> GetAllDropDownPostStatusItems(int? selectedID = null)
        {
            var postStatus =
                _dictionaryRepository.Get(d => d.Code == DictionaryCode.POSTSTATUS && d.Level == 1, od => od.OrderBy(d => d.SortIndex))
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
                _dictionaryRepository.Get(d => d.Code == DictionaryCode.POSTLANGUAGE && d.Level == 1, od => od.OrderBy(d => d.SortIndex))
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
            _dictionaryRepository.Add(dictionary);
            _dictionaryRepository.Complate();
            IsError = _dictionaryRepository.IsError;

            return dictionary.ID;
        }

        public List<int?> AddRange(List<Dictionary> dictionaries)
        {
            _dictionaryRepository.AddRange(dictionaries);
            _dictionaryRepository.Complate();
            IsError = _dictionaryRepository.IsError;

            return dictionaries.Select(u => u.ID).ToList();
        }

        public void Update(Dictionary dictionary)
        {
            _dictionaryRepository.Update(dictionary);
            _dictionaryRepository.Complate();
            IsError = _dictionaryRepository.IsError;

        }

        public void Remove(Dictionary dictionary)
        {
            _dictionaryRepository.Remove(dictionary);
            _dictionaryRepository.Complate();
            IsError = _dictionaryRepository.IsError;

        }

        public void RemoveRange(List<Dictionary> dictionaries)
        {
            _dictionaryRepository.RemoveRange(dictionaries);
            _dictionaryRepository.Complate();
            IsError = _dictionaryRepository.IsError;

        }
    }
}
