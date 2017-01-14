using System.Collections.Generic;
using BlogSystem.Admin.Reusable;

namespace BlogSystem.Admin.Models
{
    public class RolePermissionsViewModel
    {
        public RolePermissionsRolesGridViewModel RolesGridViewModel { get; set; }
        public RolePermissionsPermissionsTreeViewModel PermissionsTreeViewModel { get; set; }

        public string GetRolePermissionsUrl { get; set; }
        public string UpdateRolePermissionsUrl { get; set; }

        public class RolePermissionsRolesGridViewModel : GridViewModelBase
        {
            public List<RolePermissionsRoleGridItem> GridItems { get; set; }

            public class RolePermissionsRoleGridItem
            {
                public int? ID { get; set; }
                public string Caption { get; set; }

            }

        }

        public class RolePermissionsPermissionsTreeViewModel : TreeListViewModelBase
        {
            public List<RolePermissionsPermissionTreeItem> TreeItems { get; set; }

            public class RolePermissionsPermissionTreeItem
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public string Caption { get; set; }
            }
        }

    }


}