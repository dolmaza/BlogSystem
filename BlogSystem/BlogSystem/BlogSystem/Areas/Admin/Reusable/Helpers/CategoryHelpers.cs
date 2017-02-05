using BlogSystem.Admin.Models;
using BlogSystem.Reusable;
using Service.IServices;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Admin.Reusable.Helpers
{
    public class CategoryHelpers
    {
        public static CategoriesViewModel GeCategoriesViewModel(UrlHelper url, ICategoryService categoryService)
        {
            return new CategoriesViewModel
            {
                Tree = GetCategoriesTreeViewModel(url, categoryService)
            };
        }

        public static CategoriesViewModel.TreeViewModel GetCategoriesTreeViewModel(UrlHelper url, ICategoryService categoryService)
        {
            return new CategoriesViewModel.TreeViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Categories.TREE),
                AddNewUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Categories.TREE_ADD),
                UpdateUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Categories.TREE_UPDATE),
                DeleteUrl = url.RouteUrl(ControllerActionRouteNames.Admin.Categories.TREE_DELETE),
                TreeItems = categoryService.GetAllTreeItems().Select(c => new CategoriesViewModel.TreeViewModel.TreeItem
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