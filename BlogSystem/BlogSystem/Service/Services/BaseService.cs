using Core.DB;
using Core.Repositories;
using Service.IServices;

namespace Service.Services
{
    public class BaseService : IBaseService
    {
        public bool IsError { get; set; }

        public Repository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(new DbCoreDataContext());
        }

    }
}
