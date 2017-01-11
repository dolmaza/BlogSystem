using Core.Entities;
using Core.IRepositries;
using System.Data.Entity;

namespace Core.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context)
            : base(context)
        {
        }
    }
}
