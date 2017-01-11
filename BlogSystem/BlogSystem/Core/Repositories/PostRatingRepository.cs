using Core.Entities;
using Core.IRepositries;
using System.Data.Entity;

namespace Core.Repositories
{
    public class PostRatingRepository : Repository<PostRating>, IPostRatingRepository
    {
        public PostRatingRepository(DbContext context)
            : base(context)
        {
        }
    }
}
