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
    public class CategoriesController : BaseController
    {
        private static ICategoryService _categoryService;

        public CategoriesController()
        {
            _categoryService = new CategoryService();
        }

        [Route("categories", Name = ControllerActionRouteNames.Admin.Categories.CATEGORIES)]
        public ActionResult Categories()
        {
            return View(ViewNames.Admin.Categories.CATEGORIES, CategoryHelpers.GeCategoriesViewModel(Url, _categoryService));
        }

        [Route("categories/tree", Name = ControllerActionRouteNames.Admin.Categories.TREE)]
        public ActionResult CategoriesTree()
        {
            return PartialView(ViewNames.Admin.Categories.CATEGORIES_TREE, CategoryHelpers.GetCategoriesTreeViewModel(Url, _categoryService));
        }

        [Route("categories/add", Name = ControllerActionRouteNames.Admin.Categories.TREE_ADD)]
        public ActionResult CategoriesAdd([ModelBinder(typeof(DevExpressEditorsBinder))] CategoriesViewModel.TreeViewModel.TreeItem model)
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

            return PartialView(ViewNames.Admin.Categories.CATEGORIES_TREE, CategoryHelpers.GetCategoriesTreeViewModel(Url, _categoryService));
        }

        [Route("categories/update", Name = ControllerActionRouteNames.Admin.Categories.TREE_UPDATE)]
        public ActionResult CategoriesUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] CategoriesViewModel.TreeViewModel.TreeItem model)
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

            return PartialView(ViewNames.Admin.Categories.CATEGORIES_TREE, CategoryHelpers.GetCategoriesTreeViewModel(Url, _categoryService));
        }

        [Route("categories/delete", Name = ControllerActionRouteNames.Admin.Categories.TREE_DELETE)]
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

            return PartialView(ViewNames.Admin.Categories.CATEGORIES_TREE, CategoryHelpers.GetCategoriesTreeViewModel(Url, _categoryService));
        }

    }
}