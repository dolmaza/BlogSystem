using BlogSystem.Admin.Models;
using BlogSystem.Reusable;
using BlogSystem.Reusable.Extentions;
using Service.IServices;
using Service.Utilities;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Admin.Reusable.Helpers
{
    public class PostsManagementHelpers
    {
        public static PostsViewModel GetPostsViewModel(UrlHelper url, IPostService postService, IDictionaryService dictionaryService, ICategoryService categoryService)
        {

            return new PostsViewModel
            {
                GridViewModel = GetPostsGridViewModel(url, postService, dictionaryService, categoryService),
                PostsAddUrl = url.RouteUrl(ControllerActionRouteNames.Admin.PostsManagement.POSTS_ADD)
            };
        }

        public static PostsViewModel.PostsGridViewModel GetPostsGridViewModel(UrlHelper url, IPostService postService, IDictionaryService dictionaryService, ICategoryService categoryService)
        {
            return new PostsViewModel.PostsGridViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.PostsManagement.POSTS_GRID),
                GridItems = postService.GetAllGridItems().Select(p => new PostsViewModel.PostsGridViewModel.PostGridItem
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
    }
}