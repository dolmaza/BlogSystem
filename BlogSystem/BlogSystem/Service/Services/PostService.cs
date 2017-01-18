using Core.Entities;
using Service.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class PostService : BaseService, IPostService
    {
        public List<Post> GetAllGridItems()
        {
            var posts = UnitOfWork.PostRepository.Get
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
            var post = UnitOfWork.PostRepository.GetByID(ID);

            return post;
        }

        public int? Add(Post post)
        {
            UnitOfWork.PostRepository.Add(post);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

            return post.ID;
        }

        public List<int?> AddRange(List<Post> posts)
        {
            UnitOfWork.PostRepository.AddRange(posts);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

            return posts.Select(p => p.ID).ToList();
        }

        public void Update(Post post)
        {
            UnitOfWork.PostRepository.Update(post);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

        }

        public void Remove(Post post)
        {
            UnitOfWork.PostRepository.Remove(post);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

        }

        public void RemoveRange(List<Post> posts)
        {
            UnitOfWork.PostRepository.RemoveRange(posts);
            UnitOfWork.Complate();
            IsError = UnitOfWork.IsError;

        }
    }
}
