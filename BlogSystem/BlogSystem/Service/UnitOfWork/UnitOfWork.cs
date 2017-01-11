using Core.DB;
using Core.IRepositries;
using Core.Repositories;
using System;

namespace Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork
    {
        private readonly DbCoreDataContext _context;
        private bool _disposed = false;

        public bool IsError { get; set; }

        public IUserRepository UserRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public IPermissionRepository PermissionRepository { get; private set; }
        public IDictionaryRepository DictionaryRepository { get; private set; }
        public IAdvertisementRepository AdvertisementRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IPostRepository PostRepository { get; private set; }
        public IPostViewRepository PostViewRepository { get; private set; }
        public IPostRatingRepository PostRatingRepository { get; private set; }

        public UnitOfWork(DbCoreDataContext context)
        {
            _context = context;
            DictionaryRepository = new DictionaryRepository(_context);
            UserRepository = new UserRepository(_context);
            RoleRepository = new RoleRepository(_context);
            PermissionRepository = new PermissionRepository(_context);
            AdvertisementRepository = new AdvertisementRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            PostRepository = new PostRepository(_context);
            PostViewRepository = new PostViewRepository(_context);
            PostRatingRepository = new PostRatingRepository(_context);

        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public int Complate()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                IsError = true;
                return -1;
            }

        }
    }
}
