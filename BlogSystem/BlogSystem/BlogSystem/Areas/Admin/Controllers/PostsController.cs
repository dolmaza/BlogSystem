using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using BlogSystem.Reusable.Extentions;
using Service.IServices;
using Service.Services;
using Service.Utilities;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class PostsController : BaseController
    {
        private static IPostService _postService;
        private static IDictionaryService _dictionaryService;

        public PostsController()
        {
            _postService = new PostService();
            _dictionaryService = new DictionaryService();
        }

        #region Grid

        [Route("posts", Name = "Posts")]
        public ActionResult Index()
        {
            var model = new PostsViewModel
            {
                PostsAddUrl = Url.RouteUrl("PostsAdd"),
                GridViewModel = GetPostsGridViewModel()
            };

            return View(model);
        }

        [Route("posts/grid", Name = "PostsGrid")]
        public ActionResult PostsGrid()
        {
            return PartialView("_PostsGrid", GetPostsGridViewModel());
        }

        private PostsViewModel.PostsGridViewModel GetPostsGridViewModel()
        {
            return new PostsViewModel.PostsGridViewModel
            {
                ListUrl = Url.RouteUrl("PostsGrid"),
                GridItems = _postService.GetAllGridItems().Select(p => new PostsViewModel.PostsGridViewModel.PostGridItem
                {
                    ID = p.ID,
                    Title = p.Title,
                    Slug = p.Slug,
                    Description = p.Description.StripHtml().Shorten(50),
                    Status = p.Status.Caption,
                    CoverPhoto = $"{AppSettings.UploadFolderHttpPath}{p.CoverPhoto}",
                    CreateTime = p.CreateTime.ToString(),
                    CreatorName = $"{p.CreatorUser.Firstname} {p.CreatorUser.Lastname}",
                    Avatar = string.IsNullOrWhiteSpace(p.CreatorUser.Avatar) ? $"{AppSettings.DefaultAvatarHttpPath}" : $"{AppSettings.UploadFolderHttpPath}{p.CreatorUser.Avatar}"
                }).ToList()
            };
        }

        #endregion

        #region Form

        [Route("posts/add", Name = "PostsAdd")]
        public ActionResult PostsAdd()
        {
            var model = new PostsAddFormModel
            {
                PostsUrl = Url.RouteUrl("Posts"),
                Statuses = _dictionaryService.GetAllDropDownPostStatusItems(),
                Languages = _dictionaryService.GetAllDropDownPostLanguageItems()
            };
            return View(model);
        }


        #endregion
    }
}