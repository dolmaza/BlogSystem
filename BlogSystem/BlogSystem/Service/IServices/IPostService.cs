using Core.Entities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IPostService : IBaseService
    {
        List<Post> GetAllGridItems();
        Post GetByID(int? ID);

        int? Add(Post post);
        List<int?> AddRange(List<Post> posts);

        void Update(Post post);

        void Remove(Post post);
        void RemoveRange(List<Post> posts);
    }
}
