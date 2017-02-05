using BlogSystem.Admin.Models;
using BlogSystem.Reusable;
using Service.IServices;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Admin.Reusable.Helpers
{
    public class DictionaryHelpers
    {
        public static DictionariesViewModel GetDictionariesViewModel(UrlHelper url, IDictionaryService dictionaryService)
        {
            return new DictionariesViewModel
            {
                TreeViewModel = GetDictionariesTreeViewModel(url, dictionaryService)
            };
        }

        public static DictionariesViewModel.DictionariesTreeViewModel GetDictionariesTreeViewModel(UrlHelper url, IDictionaryService dictionaryService)
        {
            return new DictionariesViewModel.DictionariesTreeViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Dictionaries.TREE),
                AddNewUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Dictionaries.TREE_ADD),
                UpdateUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Dictionaries.TREE_UPDATE),
                DeleteUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Dictionaries.TREE_DELETE),
                TreeItems = dictionaryService.GetAllTreeItems().Select(d => new DictionariesViewModel.DictionariesTreeViewModel.DictionaryTreeItem
                {
                    ID = d.ID,
                    ParentID = d.ParentID,
                    Caption = d.Caption,
                    CaptionKa = d.CaptionKa,
                    CaptionRus = d.CaptionRus,
                    StringCode = d.StringCode,
                    IntCode = d.IntCode,
                    DecimalValue = d.DecimalValue,
                    Code = d.Code,
                    SortIndex = d.SortIndex
                }).ToList()
            };
        }
    }
}