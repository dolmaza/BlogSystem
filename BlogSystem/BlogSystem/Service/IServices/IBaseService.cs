using Core.Repositories;

namespace Service.IServices
{
    public interface IBaseService
    {
        Repository<TEntity> GetRepository<TEntity>() where TEntity : class;
        bool IsError { get; set; }

    }
}
