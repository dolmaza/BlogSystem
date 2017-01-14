using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using Core.Entities;
using DevExpress.Web.Mvc;
using Service.IServices;
using Service.Properties;
using Service.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class CategoriesController : BaseController
    {
        private static ICategoryService _categoryService;

        public CategoriesController()
        {
            _categoryService = new CategoryService();
        }

        [Route("categories", Name = "Categories")]
        public ActionResult Index()
        {
            var model = new CategoriesViewModel
            {
                TreeViewModel = GetTreeViewModel()
            };

            return View(model);
        }

        [Route("categories/tree", Name = "CategoriesTree")]
        public ActionResult CategoriesTree()
        {
            return PartialView("_CategoriesTree", GetTreeViewModel());
        }

        [Route("categories/add", Name = "CategoriesAdd")]
        public ActionResult CategoriesAdd([ModelBinder(typeof(DevExpressEditorsBinder))] CategoriesViewModel.CategoriesTreeViewModel.CategoryTreeItem model)
        {
            _categoryService.Add(new Category
            {
                ParentID = model.ParentID,
                Caption = model.Caption,
                Code = model.Code,
                SortIndex = model.SortIndex
            });

            if (_categoryService.IsError)
            {
                throw new Exception(Resources.Abort);
            }

            return PartialView("_CategoriesTree", GetTreeViewModel());
        }

        [Route("categories/update", Name = "CategoriesUpdate")]
        public ActionResult CategoriesUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] CategoriesViewModel.CategoriesTreeViewModel.CategoryTreeItem model)
        {
            var category = _categoryService.GetByID(model.ID);

            if (category == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                category.ParentID = model.ParentID;
                category.Caption = model.Caption;
                category.Code = model.Code;
                category.SortIndex = model.SortIndex;

                _categoryService.Update(category);

                if (_categoryService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }

            }

            return PartialView("_CategoriesTree", GetTreeViewModel());
        }

        [Route("categories/delete", Name = "CategoriesDelete")]
        public ActionResult CategoriesDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int? ID)
        {
            var category = _categoryService.GetByID(ID);

            if (category == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                _categoryService.Remove(category);

                if (_categoryService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }

            }

            return PartialView("_CategoriesTree", GetTreeViewModel());
        }

        private CategoriesViewModel.CategoriesTreeViewModel GetTreeViewModel()
        {
            return new CategoriesViewModel.CategoriesTreeViewModel
            {
                ListUrl = Url.RouteUrl("CategoriesTree"),
                AddNewUrl = Url.RouteUrl("CategoriesAdd"),
                UpdateUrl = Url.RouteUrl("CategoriesUpdate"),
                DeleteUrl = Url.RouteUrl("CategoriesDelete"),
                TreeItems = _categoryService.GetAllTreeItems().Select(c => new CategoriesViewModel.CategoriesTreeViewModel.CategoryTreeItem
                {
                    ID = c.ID,
                    ParentID = c.ParentID,
                    Caption = c.Caption,
                    Code = c.Code,
                    SortIndex = c.SortIndex
                }).ToList()
            };
        }
    }
}