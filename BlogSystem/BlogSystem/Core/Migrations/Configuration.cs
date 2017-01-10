namespace Core.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.DB.DbCoreDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Core.DB.DbCoreDataContext context)
        {
            //context.Users.AddOrUpdate(new User
            //{
            //    Email = "admin",
            //    Password = "912EC803B2CE49E4A541068D495AB570",
            //    Firstname = "admin",
            //    Lastname = "admin",
            //    IsActive = true,
            //    CreateTime = DateTime.Now,
            //    Role = new Role
            //    {
            //        Caption = "Admin",
            //        Code = 1,
            //        CreateTime = DateTime.Now,
            //        Permissions = new List<Permission>
            //        {
            //            new Permission
            //            {
            //                Caption = "Dashboard",
            //                Url = "/admin",
            //                Code = Guid.NewGuid().ToString(),
            //                IsMenuItem = true,
            //                IconName = "fa fa-dashboard",
            //                CreateTime = DateTime.Now,
            //                SortIndex = 1
            //            },

            //            new Permission
            //            {
            //                Caption = "System",
            //                Url = "",
            //                Code = Guid.NewGuid().ToString(),
            //                IsMenuItem = true,
            //                IconName = "fa fa-wrench",
            //                CreateTime = DateTime.Now,
            //                SortIndex = 3,
            //                Childrens = new List<Permission>
            //                {
            //                    new Permission
            //                    {
            //                        Caption = "Dictionaries",
            //                        Url = "/admin/dictionaries",
            //                        Code = Guid.NewGuid().ToString(),
            //                        IsMenuItem = true,
            //                        IconName = "fa fa-circle-o",
            //                        CreateTime = DateTime.Now,
            //                        SortIndex = 1,
            //                        Childrens = new List<Permission>
            //                        {
            //                            new Permission
            //                            {
            //                                Caption = "Dictionaries Tree",
            //                                Url = "/admin/dictionaries/tree",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Dictionaries Add",
            //                                Url = "/admin/dictionaries/add",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Dictionaries Update",
            //                                Url = "/admin/dictionaries/update",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Dictionaries Delete",
            //                                Url = "/admin/dictionaries/delete",
            //                                Code = Guid.NewGuid().ToString()
            //                            }
            //                        }
            //                    }
            //                }
            //            },

            //            new Permission
            //            {
            //                Caption = "Users Managemant",
            //                Code = Guid.NewGuid().ToString(),
            //                IsMenuItem = true,
            //                IconName = "fa fa-users",
            //                CreateTime = DateTime.Now,
            //                SortIndex = 4,
            //                Childrens = new List<Permission>
            //                {
            //                    new Permission
            //                    {
            //                        Caption = "Users",
            //                        Url = "/admin/users",
            //                        Code = Guid.NewGuid().ToString(),
            //                        IsMenuItem = true,
            //                        IconName = "fa fa-circle-o",
            //                        CreateTime = DateTime.Now,
            //                        SortIndex = 1,
            //                        Childrens = new List<Permission>
            //                        {
            //                            new Permission
            //                            {
            //                                Caption = "Users Grid",
            //                                Url = "/admin/users/grid",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Users Add",
            //                                Url = "/admin/users/add",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Users Update",
            //                                Url = "/admin/users/update",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Users Delete",
            //                                Url = "/admin/users/delete",
            //                                Code = Guid.NewGuid().ToString()
            //                            }
            //                        }
            //                    },

            //                    new Permission
            //                    {
            //                        Caption = "Roles",
            //                        Url = "/admin/roles",
            //                        Code = Guid.NewGuid().ToString(),
            //                        IsMenuItem = true,
            //                        IconName = "fa fa-circle-o",
            //                        CreateTime = DateTime.Now,
            //                        SortIndex = 1,
            //                        Childrens = new List<Permission>
            //                        {
            //                            new Permission
            //                            {
            //                                Caption = "Roles Grid",
            //                                Url = "/admin/roles/grid",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Roles Add",
            //                                Url = "/admin/roles/add",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Roles Update",
            //                                Url = "/admin/roles/update",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Roles Delete",
            //                                Url = "/admin/roles/delete",
            //                                Code = Guid.NewGuid().ToString()
            //                            }
            //                        }
            //                    },

            //                    new Permission
            //                    {
            //                        Caption = "Permissions",
            //                        Url = "/admin/permissions",
            //                        Code = Guid.NewGuid().ToString(),
            //                        IsMenuItem = true,
            //                        IconName = "fa fa-circle-o",
            //                        CreateTime = DateTime.Now,
            //                        SortIndex = 1,
            //                        Childrens = new List<Permission>
            //                        {
            //                            new Permission
            //                            {
            //                                Caption = "Permissions Grid",
            //                                Url = "/admin/permissions/tree",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Permissions Add",
            //                                Url = "/admin/permissions/add",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Permissions Update",
            //                                Url = "/admin/permissions/update",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Permissions Delete",
            //                                Url = "/admin/permissions/delete",
            //                                Code = Guid.NewGuid().ToString()
            //                            }
            //                        }
            //                    },

            //                    new Permission
            //                    {
            //                        Caption = "Role Permissions",
            //                        Url = "/admin/role-permissions",
            //                        Code = Guid.NewGuid().ToString(),
            //                        IsMenuItem = true,
            //                        IconName = "fa fa-circle-o",
            //                        CreateTime = DateTime.Now,
            //                        SortIndex = 1,
            //                        Childrens = new List<Permission>
            //                        {
            //                            new Permission
            //                            {
            //                                Caption = "Roles Grid",
            //                                Url = "/admin/role-permissions/roles/grid",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Permissions tree",
            //                                Url = "/admin/role-permissions/permissions/tree",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Role Permissions Get",
            //                                Url = "/admin/role-permissions/get-role-permissions",
            //                                Code = Guid.NewGuid().ToString()
            //                            },
            //                            new Permission
            //                            {
            //                                Caption = "Role Permissions Updatee",
            //                                Url = "/admin/role-permissions/update",
            //                                Code = Guid.NewGuid().ToString()
            //                            }
            //                        }
            //                    }

            //                }
            //            }
            //        }
            //    }
            //});
        }
    }
}

