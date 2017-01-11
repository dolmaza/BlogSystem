using Core.IRepositries;
using System;

namespace Service.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsError { get; set; }


        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IDictionaryRepository DictionaryRepository { get; }
        IAdvertisementRepository AdvertisementRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IPostRepository PostRepository { get; }
        IPostViewRepository PostViewRepository { get; }
        IPostRatingRepository PostRatingRepository { get; }

        int Complate();
    }
}
