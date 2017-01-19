using BlogSystem.Admin.Reusable;
using Service.Utilities;
using System.Collections.Generic;

namespace BlogSystem.Admin.Models
{
    public class UsersViewModel
    {
        public UsersGridViewModel GridViewModel { get; set; }

        public class UsersGridViewModel : GridViewModelBase
        {
            public string AvatarUpdateUrl { get; set; }
            public List<UserGridItem> GridItems { get; set; }
            public List<SimpleKeyValueDropDownItem<int?, string>> Roles { get; set; }

            public class UserGridItem
            {
                public int? ID { get; set; }
                public int? RoleID { get; set; }
                public byte[] AvatarBytes { get; set; }
                public string Email { get; set; }
                public string Password { get; set; }
                public string Firstname { get; set; }
                public string Lastname { get; set; }
                public bool IsActive { get; set; }
                public string About { get; set; }

            }

        }
    }

}