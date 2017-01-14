using Core.Entities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IPermissionService : IBaseService
    {
        List<Permission> GetAllTreeItems();
        List<Permission> GetAllMenuItems();
        Permission GetByID(int? ID);

        int? Add(Permission permission);
        List<int?> AddRange(List<Permission> permissions);

        void Update(Permission permission);

        void Remove(Permission permission);
        void RemoveRange(List<Permission> permissions);
    }
}
