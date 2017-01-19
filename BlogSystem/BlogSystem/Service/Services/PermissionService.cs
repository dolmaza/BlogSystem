using Core.Entities;
using Core.IRepositries;
using Service.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class PermissionService : BaseService, IPermissionService
    {
        private readonly IRepository<Permission> _permissionRepository;

        public PermissionService()
        {
            _permissionRepository = GetRepository<Permission>();
        }

        public List<Permission> GetAllTreeItems()
        {
            var permissions = _permissionRepository.GetAll(orderBy: ob => ob.OrderBy(p => p.SortIndex)).ToList();
            return permissions;
        }

        public List<Permission> GetAllMenuItems()
        {
            var permissions = _permissionRepository.Get
                (
                    filter: p => p.IsMenuItem,
                    orderBy: ob => ob.OrderBy(p => p.SortIndex)
                ).ToList();
            return permissions;
        }

        public Permission GetByID(int? ID)
        {
            var permission = _permissionRepository.GetByID(ID);

            return permission;
        }

        public int? Add(Permission permission)
        {
            _permissionRepository.Add(permission);
            _permissionRepository.Complate();
            IsError = _permissionRepository.IsError;

            return permission.ID;
        }

        public List<int?> AddRange(List<Permission> permissions)
        {
            _permissionRepository.AddRange(permissions);
            _permissionRepository.Complate();
            IsError = _permissionRepository.IsError;

            return permissions.Select(u => u.ID).ToList();
        }

        public void Update(Permission permission)
        {
            _permissionRepository.Update(permission);
            _permissionRepository.Complate();
            IsError = _permissionRepository.IsError;

        }

        public void Remove(Permission permission)
        {
            _permissionRepository.Remove(permission);
            _permissionRepository.Complate();
            IsError = _permissionRepository.IsError;

        }

        public void RemoveRange(List<Permission> permissions)
        {
            _permissionRepository.RemoveRange(permissions);
            _permissionRepository.Complate();
            IsError = _permissionRepository.IsError;

        }
    }
}
