using Core.Entities;
using Core.IRepositries;
using System.Data.Entity;

namespace Core.Repositories
{
    public class PostViewRepository : Repository<PostView>, IPostViewRepository
    {
        public PostViewRepository(DbContext context)
            : base(context)
        {
        }
    }
}
