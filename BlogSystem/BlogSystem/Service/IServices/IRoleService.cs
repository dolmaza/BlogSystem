using Core.Entities;
using Service.Utilities;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IRoleService : IBaseService
    {
        List<Role> GetAllGridItems();
        List<SimpleKeyValue<int?, string>> GetAllDropDownItems(int? selectedID = null);
        List<int?> GetRolePermissions(int? ID);
        Role GetByID(int? ID);

        int? Add(Role role);
        List<int?> AddRange(List<Role> roles);

        void Update(Role role);
        void UpdateRolePermissions(int? roleID, IEnumerable<int?> permissionIDs);

        void Remove(Role role);
        void RemoveRange(List<Role> roles);
    }
}
