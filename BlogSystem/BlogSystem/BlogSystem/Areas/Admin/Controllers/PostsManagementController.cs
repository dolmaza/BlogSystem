using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using BlogSystem.Admin.Reusable.Helpers;
using BlogSystem.Reusable;
using BlogSystem.Reusable.Extentions;
using Core.Entities;
using Service.IServices;
using Service.Properties;
using Service.Services;
using Service.Utilities;
using Service.Validation;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class PostsManagementController : BaseController
    {
        #region Properties

        private static IPostService _postService;
        private static IDictionaryService _dictionaryService;
        private static ICategoryService _categoryService;

        #endregion

        public PostsManagementController()
        {
            _postService = new PostService();
            _dictionaryService = new DictionaryService();
            _categoryService = new CategoryService();
        }

        #region Posts

        [Route("posts", Name = ControllerActionRouteNames.Admin.PostsManagement.POSTS)]
        public ActionResult Posts()
        {
            return View(ViewNames.Admin.PostsManagement.POSTS, PostsManagementHelpers.GetPostsViewModel(Url, _postService, _dictionaryService, _categoryService));
        }

        [Route("posts/grid", Name = ControllerActionRouteNames.Admin.PostsManagement.POSTS_GRID)]
        public ActionResult PostsGrid()
        {
            return PartialView(ViewNames.Admin.PostsManagement.POSTS_GRID, PostsManagementHelpers.GetPostsGridViewModel(Url, _postService, _dictionaryService, _categoryService));
        }

        [Route("posts/add", Name = ControllerActionRouteNames.Admin.PostsManagement.POSTS_ADD)]
        public ActionResult PostsAdd()
        {
            var model = new PostsAddFormModel
            {
                PostsUrl = Url.RouteUrl(ControllerActionRouteNames.Admin.PostsManagement.POSTS),
                Statuses = _dictionaryService.GetAllDropDownPostStatusItems(),
                Languages = _dictionaryService.GetAllDropDownPostLanguageItems(),
                Categories = _categoryService.GetAllTwoLevelDropDownItems(),

                SaveUrl = Url.RouteUrl(ControllerActionRouteNames.Admin.PostsManagement.POSTS_ADD)

            };

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Route("posts/add")]
        public ActionResult PostsAdd(PostsAddFormModel model)
        {
            var ajaxResponse = new AjaxResponse();
            var errors = Validation.ValidatePostCreateForm(model.Title, model.Slug, model.CoverPhotoBase64, model.CategoryID, model.Description);

            if (errors.Count == 0)
            {
                _postService.Add(new Post
                {
                    Title = model.Title,
                    Slug = model.Slug,
                    CategoryID = model.CategoryID,
                    LanguageID = model.LanguageID,
                    CreatorUserID = UserItem.ID,
                    Description = model.Description,

                });

                if (_postService.IsError)
                {
                    ajaxResponse.Data = new
                    {
                        Message = Resources.Abort
                    };
                }
                else
                {
                    ajaxResponse.IsSuccess = true;
                    ajaxResponse.Data = new
                    {
                        Message = Resources.Success
                    };
                }
            }
            else
            {
                ajaxResponse.Data = new
                {
                    ErrorsJson = errors.ToJson()
                };
            }

            return Json(ajaxResponse);
        }

        #endregion

    }
}