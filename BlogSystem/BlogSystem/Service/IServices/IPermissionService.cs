using Core.Entities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IPermissionService : IBaseService
    {
        IEnumerable<Permission> GetAllTreeItems();
        IEnumerable<Permission> GetAllMenuItems();
        Permission GetByID(int? ID);

        int? Add(Permission permission);
        IEnumerable<int?> AddRange(List<Permission> permissions);

        void Update(Permission permission);

        void Remove(Permission permission);
        void RemoveRange(List<Permission> permissions);
    }
}
