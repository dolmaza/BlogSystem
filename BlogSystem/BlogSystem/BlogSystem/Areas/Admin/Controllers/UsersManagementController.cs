using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using BlogSystem.Admin.Reusable.Helpers;
using BlogSystem.Reusable;
using BlogSystem.Reusable.Extentions;
using Core.Entities;
using DevExpress.Web.Mvc;
using Service.IServices;
using Service.Properties;
using Service.Services;
using Service.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class UsersManagementController : BaseController
    {
        #region Properties

        private static IUserService _userService;
        private static IRoleService _roleService;
        private static IPermissionService _permissionService;


        #endregion

        public UsersManagementController()
        {
            _userService = new UserService();
            _roleService = new RoleService();
            _permissionService = new PermissionService();
        }


        #region Users

        [Route("users", Name = ControllerActionRouteNames.Admin.UsersManagement.USERS)]
        public ActionResult Users()
        {
            return View(ViewNames.Admin.UserManagement.USERS, UserManagementHelpers.GetUsersViewModel(Url, _userService, _roleService));
        }

        [Route("users/grid", Name = ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID)]
        public ActionResult UserGrid()
        {
            return PartialView(ViewNames.Admin.UserManagement.USERS_GRID, UserManagementHelpers.GetUsersGridViewModel(Url, _userService, _roleService));
        }

        [Route("users/avatar/update", Name = ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_AVATAR_UPDATE)]
        public ActionResult BinaryImageColumnAvatarUpdate()
        {
            return BinaryImageEditExtension.GetCallbackResult();
        }

        [Route("users/add", Name = ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_ADD)]
        public ActionResult UsersAdd([ModelBinder(typeof(DevExpressEditorsBinder))] UsersViewModel.UsersGridViewModel.UserGridItem model)
        {
            if (_userService.IsUserEmailNotUnique(model.Email))
            {
                throw new Exception(Resources.ValidationEmailUnique);
            }
            else
            {
                var avatarName = model.AvatarBytes == null ? null : UserManagementHelpers.GetAvatarUniqueName();

                _userService.Add(new User
                {
                    Avatar = avatarName,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Password = model.Password?.ToMD5(),
                    IsActive = model.IsActive,
                    RoleID = model.RoleID,
                    About = model.About,
                });

                if (_userService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }
                else
                {
                    UserManagementHelpers.SaveAvatar(model.AvatarBytes, avatarName);
                }
            }

            return PartialView(ViewNames.Admin.UserManagement.USERS_GRID, UserManagementHelpers.GetUsersGridViewModel(Url, _userService, _roleService));
        }

        [Route("users/update", Name = ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_UPDATE)]
        public ActionResult UsersUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] UsersViewModel.UsersGridViewModel.UserGridItem model)
        {
            var user = _userService.GetByID(model.ID);

            if (user == null)
            {
                throw new Exception(Resources.Abort);
            }
            else if (_userService.IsUserEmailNotUnique(model.Email, user.ID))
            {
                throw new Exception(Resources.ValidationEmailUnique);
            }
            else
            {
                var avatarName = model.AvatarBytes == null ? null : UserManagementHelpers.GetAvatarUniqueName();
                var oldAvatarName = user.Avatar;

                user.ID = model.ID;
                user.Avatar = string.IsNullOrWhiteSpace(avatarName) ? user.Avatar : avatarName;
                user.Email = model.Email;
                user.Password = model.Password?.ToMD5() ?? user.Password;
                user.Firstname = model.Firstname;
                user.Lastname = model.Lastname;
                user.IsActive = model.IsActive;
                user.RoleID = model.RoleID;
                user.About = model.About;

                _userService.Update(user);

                if (_userService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }
                else
                {
                    UserManagementHelpers.SaveAvatar(model.AvatarBytes, avatarName, oldAvatarName);
                }
            }



            return PartialView(ViewNames.Admin.UserManagement.USERS_GRID, UserManagementHelpers.GetUsersGridViewModel(Url, _userService, _roleService));
        }

        [Route("users/delete", Name = ControllerActionRouteNames.Admin.UsersManagement.USERS_GRID_DELETE)]
        public ActionResult UsersDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int? ID)
        {
            var user = _userService.GetByID(ID);

            if (user == null)
            {
                throw new Exception(Resources.Abort);
            }

            UserManagementHelpers.DeleteAvatar(user.Avatar);


            _userService.Remove(user);

            if (_userService.IsError)
            {
                throw new Exception(Resources.Abort);
            }

            return PartialView(ViewNames.Admin.UserManagement.USERS_GRID, UserManagementHelpers.GetUsersGridViewModel(Url, _userService, _roleService));
        }

        #endregion

        #region Roles

        [Route("roles", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLES)]
        public ActionResult Roles()
        {
            return View(ViewNames.Admin.UserManagement.ROLES, UserManagementHelpers.GetRolesViewModel(Url, _roleService));
        }

        [Route("roles/grid", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID)]
        public ActionResult RoleGrid()
        {
            return PartialView(ViewNames.Admin.UserManagement.ROLES_GRID, UserManagementHelpers.GetRolesGridViewModel(Url, _roleService));
        }

        [Route("roles/add", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID_ADD)]
        public ActionResult RolesAdd([ModelBinder(typeof(DevExpressEditorsBinder))] RolesViewModel.RolesGridViewModel.RoleGridItem model)
        {
            _roleService.Add(new Role
            {
                ID = model.ID,
                Caption = model.Caption,
                Code = model.Code
            });

            if (_roleService.IsError)
            {
                throw new Exception(Resources.Abort);
            }

            return PartialView(ViewNames.Admin.UserManagement.ROLES_GRID, UserManagementHelpers.GetRolesGridViewModel(Url, _roleService));
        }

        [Route("roles/update", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID_UPDATE)]
        public ActionResult RolesUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] RolesViewModel.RolesGridViewModel.RoleGridItem model)
        {
            var role = _roleService.GetByID(model.ID);

            if (role == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                role.Caption = model.Caption;
                role.Code = model.Code;

                _roleService.Update(role);

                if (_roleService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }
            }

            return PartialView(ViewNames.Admin.UserManagement.ROLES_GRID, UserManagementHelpers.GetRolesGridViewModel(Url, _roleService));
        }

        [Route("roles/delete", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLES_GRID_DELETE)]
        public ActionResult RolesDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int? ID)
        {
            var role = _roleService.GetByID(ID);
            if (role == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                _roleService.Remove(role);

                if (_roleService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }
            }

            return PartialView(ViewNames.Admin.UserManagement.ROLES_GRID, UserManagementHelpers.GetRolesGridViewModel(Url, _roleService));
        }


        #endregion

        #region Permissions


        [Route("permissions", Name = ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS)]
        public ActionResult Permissions()
        {
            return View(ViewNames.Admin.UserManagement.PERMISSIONS, UserManagementHelpers.GetPermissionsViewModel(Url, _permissionService));
        }

        [Route("permissions/tree", Name = ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE)]
        public ActionResult PermissionTree()
        {
            return PartialView(ViewNames.Admin.UserManagement.PERMISSIONS_TREE, UserManagementHelpers.GetPermissionsTreeViewModel(Url, _permissionService));
        }

        [Route("permissions/add", Name = ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE_ADD)]
        public ActionResult PemissionsAdd([ModelBinder(typeof(DevExpressEditorsBinder))] PermissionsViewModel.PermissionsTreeViewModel.PermissionTreeItem model)
        {
            _permissionService.Add(new Permission
            {
                ID = model.ID,
                ParentID = model.ParentID,
                Caption = model.Caption,
                Url = model.Url,
                Code = model.Code ?? Guid.NewGuid().ToString(),
                IsMenuItem = model.IsMenuItem,
                IconName = model.IconName,
                SortIndex = model.SortIndex
            });

            if (_permissionService.IsError)
            {
                throw new Exception(Resources.Abort);
            }

            return PartialView(ViewNames.Admin.UserManagement.PERMISSIONS_TREE, UserManagementHelpers.GetPermissionsTreeViewModel(Url, _permissionService));
        }

        [Route("permissions/update", Name = ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE_UPDATE)]
        public ActionResult PemissionsUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] PermissionsViewModel.PermissionsTreeViewModel.PermissionTreeItem model)
        {
            var permission = _permissionService.GetByID(model.ID);
            if (permission == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                permission.ParentID = model.ParentID;
                permission.Caption = model.Caption;
                permission.Url = model.Url;
                permission.Code = model.Code ?? Guid.NewGuid().ToString();
                permission.IsMenuItem = model.IsMenuItem;
                permission.IconName = model.IconName;
                permission.SortIndex = model.SortIndex;

                _permissionService.Update(permission);

                if (_permissionService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }
            }

            return PartialView(ViewNames.Admin.UserManagement.PERMISSIONS_TREE, UserManagementHelpers.GetPermissionsTreeViewModel(Url, _permissionService));
        }

        [Route("permissions/delete", Name = ControllerActionRouteNames.Admin.UsersManagement.PERMISSIONS_TREE_DELETE)]
        public ActionResult PermissionsDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int? ID)
        {
            var permission = _permissionService.GetByID(ID);

            if (permission == null)
            {
                throw new Exception(Resources.Abort);
            }
            else
            {
                _permissionService.Remove(permission);

                if (_permissionService.IsError)
                {
                    throw new Exception(Resources.Abort);
                }
            }


            return PartialView(ViewNames.Admin.UserManagement.PERMISSIONS_TREE, UserManagementHelpers.GetPermissionsTreeViewModel(Url, _permissionService));
        }

        #endregion

        #region RolePermissions

        [Route("role-permissions", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLE_PERMISSIONS)]
        public ActionResult RolePermissions()
        {
            return View(ViewNames.Admin.UserManagement.ROLE_PERMISSIONS, UserManagementHelpers.GetRolePermissionsViewModel(Url, _roleService, _permissionService));
        }

        [Route("role-permissions/roles/grid", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLE_PERMISSIONS_ROLES_GRID)]
        public ActionResult RolesGrid()
        {
            return PartialView(ViewNames.Admin.UserManagement.ROLE_PERMISSIONS_ROLES_GRID, UserManagementHelpers.GetRolePermissionsRolesGridViewModel(Url, _roleService));
        }

        [Route("role-permissions/permissions/tree", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLE_PERMISSIONS_PERMISSIONS_TREE)]
        public ActionResult PermissionsTree()
        {
            return PartialView(ViewNames.Admin.UserManagement.ROLE_PERMISSIONS_PERMISSIONS_TREE, UserManagementHelpers.GetRolePermissionsPermissionsTreeViewModel(Url, _permissionService));
        }

        [Route("role-permissions/get-role-permissions", Name = ControllerActionRouteNames.Admin.UsersManagement.GET_ROLE_PERMISSIONS)]
        public ActionResult GetRolePermissions(int? ID)
        {
            var ajaxResponse = new AjaxResponse();

            var permissions = _roleService.GetRolePermissions(ID);

            ajaxResponse.IsSuccess = true;
            ajaxResponse.Data = new
            {
                Permissions = permissions.ToJson()
            };

            return Json(ajaxResponse);
        }

        [HttpPost]
        [Route("role-permissions/update", Name = ControllerActionRouteNames.Admin.UsersManagement.ROLE_PERMISSIONS_UPDATE)]
        public ActionResult RolePermissionsUpdate(int? roleID, List<int?> permissions)
        {
            var ajaxResponse = new AjaxResponse();

            _roleService.UpdateRolePermissions(roleID, permissions);

            if (_roleService.IsError)
            {
                ajaxResponse.Data = new
                {
                    Message = Resources.Abort
                };
            }
            else
            {
                ajaxResponse.IsSuccess = true;
                ajaxResponse.Data = new
                {
                    Message = Resources.Success
                };
            }

            return Json(ajaxResponse);
        }

        #endregion
    }
}