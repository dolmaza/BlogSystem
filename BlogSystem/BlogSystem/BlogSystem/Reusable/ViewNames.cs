namespace BlogSystem.Reusable
{
    public struct ViewNames
    {
        public struct Admin
        {
            public struct Categories
            {
                public const string CATEGORIES = "~/Areas/Admin/Views/Categories/Categories.cshtml";
                public const string CATEGORIES_TREE = "~/Areas/Admin/Views/Categories/CategoriesTree.cshtml";

            }

            public struct Dictionaries
            {
                public const string DICTIONARIES = "~/Areas/Admin/Views/Dictionaries/Dictionaries.cshtml";
                public const string DICTIONARIES_TREE = "~/Areas/Admin/Views/Dictionaries/DictionariesTree.cshtml";

            }

            public struct PostsManagement
            {
                #region Posts

                public const string POSTS = "~/Areas/Admin/Views/PostsManagement/Posts.cshtml";
                public const string POSTS_GRID = "~/Areas/Admin/Views/PostsManagement/PostsGrid.cshtml";

                #endregion

            }

            public struct UserManagement
            {
                #region Users

                public const string USERS = "~/Areas/Admin/Views/UsersManagement/Users/Users.cshtml";
                public const string USERS_GRID = "~/Areas/Admin/Views/UsersManagement/Users/UsersGrid.cshtml";

                #endregion

                #region Roles

                public const string ROLES = "~/Areas/Admin/Views/UsersManagement/Roles/Roles.cshtml";
                public const string ROLES_GRID = "~/Areas/Admin/Views/UsersManagement/Roles/RolesGrid.cshtml";

                #endregion

                #region Permissions

                public const string PERMISSIONS = "~/Areas/Admin/Views/UsersManagement/Permissions/Permissions.cshtml";
                public const string PERMISSIONS_TREE = "~/Areas/Admin/Views/UsersManagement/Permissions/PermissionsTree.cshtml";


                #endregion


                #region RolePermissions

                public const string ROLE_PERMISSIONS = "~/Areas/Admin/Views/UsersManagement/RolePermissions/RolePermissions.cshtml";
                public const string ROLE_PERMISSIONS_PERMISSIONS_TREE = "~/Areas/Admin/Views/UsersManagement/RolePermissions/PermissionsTree.cshtml";
                public const string ROLE_PERMISSIONS_ROLES_GRID = "~/Areas/Admin/Views/UsersManagement/RolePermissions/RolesGrid.cshtml";


                #endregion

            }
        }

    }
}