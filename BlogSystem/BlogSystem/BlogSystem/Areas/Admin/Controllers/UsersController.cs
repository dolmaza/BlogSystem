using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using BlogSystem.Admin.Reusable.Helpers;
using BlogSystem.Reusable.Extentions;
using Core.Entities;
using DevExpress.Web.Mvc;
using Service.IServices;
using Service.Properties;
using Service.Services;
using Service.Utilities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private static IUserService _userService;
        private static IRoleService _roleService;

        public UsersController()
        {
            _userService = new UserService();
            _roleService = new RoleService();
        }

        [Route("users", Name = "Users")]
        public ActionResult Index()
        {
            var model = new UsersViewModel
            {
                GridViewModel = GetGridViewModel()
            };

            return View(model);
        }

        [Route("users/grid", Name = "UsersGrid")]
        public ActionResult UserGrid()
        {
            return PartialView("_UsersGrid", GetGridViewModel());
        }

        [Route("users/avatar/update", Name = "UsersAvatarUpdate")]
        public ActionResult BinaryImageColumnAvatarUpdate()
        {
            return BinaryImageEditExtension.GetCallbackResult();
        }

        [Route("users/add", Name = "UsersAdd")]
        public ActionResult UsersAdd([ModelBinder(typeof(DevExpressEditorsBinder))] UsersViewModel.UsersGridViewModel.UserGridItem model)
        {
            if (_userService.IsUserEmailNotUnique(model.Email))
            {
                throw new Exception(Resources.ValidationEmailUnique);
            }
            else
            {
                var avatarName = model.AvatarBytes == null ? null : UserHelper.GetAvatarUniqueName();

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
                    UserHelper.SaveAvatar(model.AvatarBytes, avatarName);
                }
            }

            return PartialView("_UsersGrid", GetGridViewModel());
        }

        [Route("users/update", Name = "UsersUpdate")]
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
                var avatarName = model.AvatarBytes == null ? null : UserHelper.GetAvatarUniqueName();
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
                    UserHelper.SaveAvatar(model.AvatarBytes, avatarName, oldAvatarName);
                }
            }



            return PartialView("_UsersGrid", GetGridViewModel());
        }

        [Route("users/delete", Name = "UsersDelete")]
        public ActionResult UsersDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int? ID)
        {
            var user = _userService.GetByID(ID);

            if (user == null)
            {
                throw new Exception(Resources.Abort);
            }

            UserHelper.DeleteAvatar(user.Avatar);


            _userService.Remove(user);

            if (_userService.IsError)
            {
                throw new Exception(Resources.Abort);
            }

            return PartialView("_UsersGrid", GetGridViewModel());
        }

        private UsersViewModel.UsersGridViewModel GetGridViewModel()
        {

            return new UsersViewModel.UsersGridViewModel
            {
                ListUrl = Url.RouteUrl("UsersGrid"),
                AddNewUrl = Url.RouteUrl("UsersAdd"),
                UpdateUrl = Url.RouteUrl("UsersUpdate"),
                DeleteUrl = Url.RouteUrl("UsersDelete"),
                AvatarUpdateUrl = Url.RouteUrl("UsersAvatarUpdate"),
                GridItems = _userService.GetAllGridItems().Select(u => new UsersViewModel.UsersGridViewModel.UserGridItem
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

                Roles = _roleService.GetAllDropDownItems().ToList()
            };
        }
    }
}