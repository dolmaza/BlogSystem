using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using BlogSystem.Admin.Reusable.Helpers;
using BlogSystem.Reusable;
using Core.Entities;
using DevExpress.Web.Mvc;
using Service.IServices;
using Service.Properties;
using Service.Services;
using System;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class DictionariesController : BaseController
    {
        private static IDictionaryService _dictionaryService;

        public DictionariesController()
        {
            _dictionaryService = new DictionaryService();
        }

        [Route("dictionaries", Name = ControllerActionRouteNames.Admin.Dictionaries.DICTIONARIES)]
        public ActionResult Dictionaries()
        {
            return View(ViewNames.Admin.Dictionaries.DICTIONARIES, DictionaryHelpers.GetDictionariesViewModel(Url, _dictionaryService));
        }

        [Route("dictionaries/tree", Name = ControllerActionRouteNames.Admin.Dictionaries.TREE)]
        public ActionResult DictionaryTree()
        {
            return PartialView(ViewNames.Admin.Dictionaries.DICTIONARIES_TREE, DictionaryHelpers.GetDictionariesTreeViewModel(Url, _dictionaryService));
        }

        [Route("dictionaries/add", Name = ControllerActionRouteNames.Admin.Dictionaries.TREE_ADD)]
        public ActionResult DictioanriesAdd([ModelBinder(typeof(DevExpressEditorsBinder))] DictionariesViewModel.DictionariesTreeViewModel.DictionaryTreeItem model)
        {
            _dictionaryService.Add(new Dictionary
            {
                ID = model.ID,
                ParentID = model.ParentID,
                Caption = model.Caption,
                CaptionKa = model.CaptionKa,
                CaptionRus = model.CaptionRus,
                StringCode = model.StringCode,
                IntCode = model.IntCode,
                DecimalValue = model.DecimalValue,
                Code = model.Code,
                SortIndex = model.SortIndex
            });

            if (_dictionaryService.IsError)
            {
                throw new Exception(Resources.Abort);
            }

            return PartialView(ViewNames.Admin.Dictionaries.DICTIONARIES_TREE, DictionaryHelpers.GetDictionariesTreeViewModel(Url, _dictionaryService));
        }

        [Route("dictionaries/update", Name = ControllerActionRouteNames.Admin.Dictionaries.TREE_UPDATE)]
        public ActionResult DictioanriesUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DictionariesViewModel.DictionariesTreeViewModel.DictionaryTreeItem model)
        {
            var dictionary = _dictionaryService.GetByID(model.ID);

            if (dictionary == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                dictionary.ParentID = model.ParentID;
                dictionary.Caption = model.Caption;
                dictionary.CaptionKa = model.CaptionKa;
                dictionary.CaptionRus = model.CaptionRus;
                dictionary.StringCode = model.StringCode;
                dictionary.IntCode = model.IntCode;
                dictionary.DecimalValue = model.DecimalValue;
                dictionary.Code = model.Code;
                dictionary.SortIndex = model.SortIndex;

                _dictionaryService.Update(dictionary);

                if (_dictionaryService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }
            }

            return PartialView(ViewNames.Admin.Dictionaries.DICTIONARIES_TREE, DictionaryHelpers.GetDictionariesTreeViewModel(Url, _dictionaryService));
        }

        [Route("dictionaries/delete", Name = ControllerActionRouteNames.Admin.Dictionaries.TREE_DELETE)]
        public ActionResult DictionarisDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int? ID)
        {
            var dictionary = _dictionaryService.GetByID(ID);

            if (dictionary == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                _dictionaryService.Remove(dictionary);

                if (_dictionaryService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }

            }

            return PartialView(ViewNames.Admin.Dictionaries.DICTIONARIES_TREE, DictionaryHelpers.GetDictionariesTreeViewModel(Url, _dictionaryService));
        }

    }
}