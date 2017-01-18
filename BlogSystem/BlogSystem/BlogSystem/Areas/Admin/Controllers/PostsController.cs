using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class PostsController : BaseController
    {
        [Route("posts", Name = "Posts")]
        public ActionResult Index()
        {
            var model = new PostsViewModel
            {
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

            };
        }
    }
}