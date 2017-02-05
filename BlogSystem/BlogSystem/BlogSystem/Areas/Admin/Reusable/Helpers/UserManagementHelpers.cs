using BlogSystem.Admin.Models;
using BlogSystem.Reusable;
using Service.IServices;
using Service.Utilities;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Admin.Reusable.Helpers
{
    public class UserManagementHelpers
    {
        #region Users

        public static string GetAvatarUniqueName()
        {
            return $"Avatar_{Guid.NewGuid().ToString().Substring(0, 8)}.png";
        }

        public static void SaveAvatar(byte[] avatarBytes, string avatarName, string oldAvatarName = null)
        {
            DeleteAvatar(oldAvatarName);

            if (avatarBytes != null && !string.IsNullOrWhiteSpace(avatarName))
            {
                Image image = null;
                var ms = new MemoryStream(avatarBytes);
                image = Image.FromStream(ms);

                image.Save($"{AppSettings.UploadFolderPhysicalPath}{avatarName}");
                ms.Dispose();
                image.Dispose();
            }
        }

        public static void DeleteAvatar(string avatarName)
        {
            if (!string.IsNullOrWhiteSpace(avatarName))
            {
                var oldAvatarPath = $"{AppSettings.UploadFolderPhysicalPath}{avatarName}";
                if (File.Exists(oldAvatarPath))
                {
                    File.Delete(oldAvatarPath);
                }
            }
        }

        public static UsersViewModel GetUsersViewModel(UrlHelper url, IUserService userService, IRoleService roleService)
        {
            return new UsersViewModel
            {
                GridViewModel = GetUsersGridViewModel(url, userService, roleService)
            };
        }

        public static UsersViewModel.UsersGridViewModel GetUsersGridViewModel(UrlHelper url, IUserService userService, IRoleService roleService)
        {
            return new UsersViewModel.UsersGridViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID),
                AddNewUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_ADD),
                UpdateUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_UPDATE),
                DeleteUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_DELETE),
                AvatarUpdateUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_AVATAR_UPDATE),
                GridItems = userService.GetAllGridItems().Select(u => new UsersViewModel.UsersGridViewModel.UserGridItem
                {
                    ID = u.ID,
                    AvatarBytes = string.IsNullOrWhiteSpace(u.Avatar) ? Utilities.ConvertImageToByteArray(AppSettings.DefaultAvatarPhysicalPath) : Utilities.ConvertImageToByteArray($"{AppSettings.UploadFolderPhysicalPath}{u.Avatar}"),
                    Email = u.Email,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    IsActive = u.IsActive,
                    RoleID = u.RoleID,
                    About = u.About,
                }).ToList(),

                Roles = roleService.GetAllDropDownItems().ToList()
            };
        }

        #endregion

        #region Roles

        public static RolesViewModel GetRolesViewModel(UrlHelper url, IRoleService roleService)
        {
            return new RolesViewModel
            {
                GridViewModel = GetRolesGridViewModel(url, roleService)
            };
        }

        public static RolesViewModel.RolesGridViewModel GetRolesGridViewModel(UrlHelper url, IRoleService roleService)
        {
            return new RolesViewModel.RolesGridViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID),
                AddNewUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID_ADD),
                UpdateUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID_UPDATE),
                DeleteUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID_DELETE),
                GridItems = roleService.GetAllGridItems().Select(r => new RolesViewModel.RolesGridViewModel.RoleGridItem
                {
                    ID = r.ID,
                    Caption = r.Caption,
                    Code = r.Code
                }).ToList()
            };
        }

        #endregion

        #region Permissions

        public static PermissionsViewModel GetPermissionsViewModel(UrlHelper url, IPermissionService permissionService)
        {
            return new PermissionsViewModel
            {
                TreeViewModel = GetPermissionsTreeViewModel(url, permissionService)
            };
        }

        public static PermissionsViewModel.PermissionsTreeViewModel GetPermissionsTreeViewModel(UrlHelper url, IPermissionService permissionService)
        {
            return new PermissionsViewModel.PermissionsTreeViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE),
                AddNewUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE_ADD),
                UpdateUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE_UPDATE),
                DeleteUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE_DELETE),
                TreeItems = permissionService.GetAllTreeItems().Select(p => new PermissionsViewModel.PermissionsTreeViewModel.PermissionTreeItem
                {
                    ID = p.ID,
                    ParentID = p.ParentID,
                    Caption = p.Caption,
                    Url = p.Url,
                    Code = p.Code,
                    IconName = p.IconName,
                    IsMenuItem = p.IsMenuItem,
                    SortIndex = p.SortIndex
                }).ToList()
            };
        }

        #endregion

        #region RolePermissions

        public static RolePermissionsViewModel GetRolePermissionsViewModel(UrlHelper url, IRoleService roleService, IPermissionService permissionService)
        {
            return new RolePermissionsViewModel
            {
                RolesGridViewModel = GetRolePermissionsRolesGridViewModel(url, roleService),
                PermissionsTreeViewModel = GetRolePermissionsPermissionsTreeViewModel(url, permissionService),

                GetRolePermissionsUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.GET_ROLE_PERMISSIONS),
                UpdateRolePermissionsUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.ROLE_PERMISSIONS_UPDATE)
            };
        }

        public static RolePermissionsViewModel.RolePermissionsRolesGridViewModel GetRolePermissionsRolesGridViewModel(UrlHelper url, IRoleService roleService)
        {
            return new RolePermissionsViewModel.RolePermissionsRolesGridViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.ROLE_PERMISSIONS_ROLES_GRID),
                GridItems = roleService.GetAllGridItems().Select(r => new RolePermissionsViewModel.RolePermissionsRolesGridViewModel.RolePermissionsRoleGridItem
                {
                    ID = r.ID,
                    Caption = r.Caption
                }).ToList()
            };
        }

        public static RolePermissionsViewModel.RolePermissionsPermissionsTreeViewModel GetRolePermissionsPermissionsTreeViewModel(UrlHelper url, IPermissionService permissionService)
        {
            return new RolePermissionsViewModel.RolePermissionsPermissionsTreeViewModel
            {
                ListUrl = url.RouteUrl(ControllerActionRouteNames.Admin.UsersManagement.ROLE_PERMISSIONS_PERMISSIONS_TREE),
                TreeItems = permissionService.GetAllTreeItems().Select(p => new RolePermissionsViewModel.RolePermissionsPermissionsTreeViewModel.RolePermissionsPermissionTreeItem
                {
                    ID = p.ID,
                    ParentID = p.ParentID,
                    Caption = p.Caption
                }).ToList()
            };
        }

        #endregion

    }
}