using Core.Entities;
using Core.IRepositries;
using Service.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class PostService : BaseService, IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService()
        {
            _postRepository = GetRepository<Post>();
        }

        public List<Post> GetAllGridItems()
        {
            var posts = _postRepository.Get
                (
                    null,
                    ob => ob.OrderByDescending(p => p.CreateTime),
                    null,
                    null,
                    p => p.CreatorUser,
                    p => p.Category,
                    p => p.Status,
                    p => p.Ratings
                ).ToList();
            return posts;
        }

        public Post GetByID(int? ID)
        {
            var post = _postRepository.GetByID(ID);

            return post;
        }

        public bool IsSlugUnique(string slug, int? postID = null)
        {
            return !_postRepository.Exists(p => p.Slug == slug && (postID == null || p.ID == postID));
        }

        public int? Add(Post post)
        {
            _postRepository.Add(post);
            _postRepository.Complate();
            IsError = _postRepository.IsError;

            return post.ID;
        }

        public List<int?> AddRange(List<Post> posts)
        {
            _postRepository.AddRange(posts);
            _postRepository.Complate();
            IsError = _postRepository.IsError;

            return posts.Select(p => p.ID).ToList();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
            _postRepository.Complate();
            IsError = _postRepository.IsError;

        }

        public void Remove(Post post)
        {
            _postRepository.Remove(post);
            _postRepository.Complate();
            IsError = _postRepository.IsError;

        }

        public void RemoveRange(List<Post> posts)
        {
            _postRepository.RemoveRange(posts);
            _postRepository.Complate();
            IsError = _postRepository.IsError;

        }
    }
}
