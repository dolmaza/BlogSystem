namespace BlogSystem.Reusable
{
    public struct ControllerActionRouteNames
    {
        public struct Admin
        {
            public struct Categories
            {
                public const string CATEGORIES = "Categories";
                public const string TREE = "CategoriesTree";
                public const string TREE_ADD = "CategoriesAdd";
                public const string TREE_UPDATE = "CategoriesUpdate";
                public const string TREE_DELETE = "CategoriesDelete";
            }

            public struct Dictionaries
            {
                public const string DICTIONARIES = "Dictionaries";
                public const string TREE = "DictionariesTree";
                public const string TREE_ADD = "DictionariesAdd";
                public const string TREE_UPDATE = "DictionariesUpdate";
                public const string TREE_DELETE = "DictionariesDelete";
            }

            public struct Home
            {
                public const string DASHBOARD = "Dashboard";

            }

            public struct PostsManagement
            {
                #region Posts

                public const string POSTS = "Posts";
                public const string POSTS_GRID = "PostsGrid";
                public const string POSTS_ADD = "PostsAdd";
                public const string GRID_UPATE = "PostsUpdate";
                public const string POSTS_GRID_DELETE = "PostsGridDelete";

                #endregion

            }


            public struct UsersManagement
            {
                #region Users

                public const string USERS = "Users";
                public const string USERS_GRID = "UsersGrid";
                public const string USERS_GRID_AVATAR_UPDATE = "UsersAvatarUpdate";
                public const string USERS_GRID_ADD = "UsersAdd";
                public const string USERS_GRID_UPDATE = "UsersUpdate";
                public const string USERS_GRID_DELETE = "UsersDelete";

                #endregion

                #region Roles

                public const string ROLES = "Roles";
                public const string ROLES_GRID = "RolesGrid";
                public const string ROLES_GRID_ADD = "RolesAdd";
                public const string ROLES_GRID_UPDATE = "RolesUpdate";
                public const string ROLES_GRID_DELETE = "RolesDelete";

                #endregion

                #region Permissions

                public const string PERMISSIONS = "Permissions";
                public const string PERMISSIONS_TREE = "PermissionsGrid";
                public const string PERMISSIONS_TREE_ADD = "PermissionsAdd";
                public const string PERMISSIONS_TREE_UPDATE = "PermissionsUpdate";
                public const string PERMISSIONS_TREE_DELETE = "PermissionsDelete";

                #endregion

                #region Role_Permissions

                public const string ROLE_PERMISSIONS = "RolePermissions";
                public const string ROLE_PERMISSIONS_ROLES_GRID = "RolePermissionsRolesGrid";
                public const string ROLE_PERMISSIONS_PERMISSIONS_TREE = "RolePermissionsPermissionsTree";
                public const string GET_ROLE_PERMISSIONS = "GetRolePermissions";
                public const string ROLE_PERMISSIONS_UPDATE = "RolePermissionsUpdate";

                #endregion

            }
        }
    }
}