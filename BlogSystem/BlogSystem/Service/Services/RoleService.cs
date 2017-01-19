using Core.Entities;
using Core.IRepositries;
using Service.IServices;
using Service.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Permission> _permissionRepository;

        public RoleService()
        {
            _roleRepository = GetRepository<Role>();
            _permissionRepository = GetRepository<Permission>();
        }

        public List<Role> GetAllGridItems()
        {
            var roles = _roleRepository.GetAll(orderBy: ob => ob.OrderByDescending(r => r.CreateTime)).ToList();

            return roles;
        }

        public List<SimpleKeyValueDropDownItem<int?, string>> GetAllDropDownItems(int? selectedID = null)
        {
            var roles = _roleRepository.GetAll(orderBy: ob => ob.OrderByDescending(r => r.CreateTime))
                .Select(r => new SimpleKeyValueDropDownItem<int?, string>
                {
                    Key = r.ID,
                    Value = r.Caption,
                    IsSelected = r.ID == selectedID
                }).ToList();

            return roles;
        }

        public List<int?> GetRolePermissions(int? ID)
        {
            var rolePermissions = _roleRepository.Get(filter: r => r.ID == ID, includes: r => r.Permissions)
                .FirstOrDefault()?.Permissions
                .Select(r => r.ID)
                .ToList();

            return rolePermissions;
        }

        public Role GetByID(int? ID)
        {
            var role = _roleRepository.GetByID(ID);

            return role;
        }

        public int? Add(Role role)
        {
            _roleRepository.Add(role);
            _roleRepository.Complate();
            IsError = _roleRepository.IsError;

            return role.ID;
        }

        public List<int?> AddRange(List<Role> roles)
        {
            _roleRepository.AddRange(roles);
            _roleRepository.Complate();
            IsError = _roleRepository.IsError;

            return roles.Select(u => u.ID).ToList();
        }

        public void Update(Role role)
        {
            _roleRepository.Update(role);
            _roleRepository.Complate();
            IsError = _roleRepository.IsError;

        }

        public void UpdateRolePermissions(int? roleID, IEnumerable<int?> permissionIDs)
        {
            var role = _roleRepository.GetOne(filter: r => r.ID == roleID, includes: r => r.Permissions);
            if (role == null || permissionIDs == null)
            {
                IsError = true;
            }
            else
            {
                var newPermissions = _permissionRepository.Get(filter: p => permissionIDs.Contains(p.ID ?? 0)).ToList();

                role.Permissions.Where(p => !newPermissions.Contains(p)).ToList().ForEach(permission =>
                {
                    role.Permissions.Remove(permission);
                });

                newPermissions.Where(p => !role.Permissions.Contains(p)).ToList().ForEach(permission =>
                {
                    role.Permissions.Add(permission);
                });
                _roleRepository.Update(role);
                _roleRepository.Complate();
                IsError = _roleRepository.IsError;

            }
        }

        public void Remove(Role role)
        {
            _roleRepository.Remove(role);
            _roleRepository.Complate();
            IsError = _roleRepository.IsError;

        }

        public void RemoveRange(List<Role> roles)
        {
            _roleRepository.RemoveRange(roles);
            _roleRepository.Complate();
            IsError = _roleRepository.IsError;

        }
    }
}
