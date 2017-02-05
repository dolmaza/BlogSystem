using BlogSystem.Admin.Reusable;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using Service.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BlogSystem.Admin.Models
{

    #region Users

    public class UsersViewModel
    {
        public UsersGridViewModel GridViewModel { get; set; }

        public class UsersGridViewModel : GridViewModelBase
        {
            public string AvatarUpdateUrl { get; set; }
            public List<UserGridItem> GridItems { get; set; }
            public List<SimpleKeyValueDropDownItem<int?, string>> Roles { get; set; }

            public GridViewSettings GetGridViewSettings(GridViewSettings settings, HtmlHelper html = null)
            {
                settings = GenerateGridViewDefaultSettings(settings);
                UserGridItem model;
                settings.Name = "UsersGrid";
                settings.KeyFieldName = nameof(model.ID);

                settings.CommandColumn.Visible = true;
                settings.CommandColumn.ShowDeleteButton = true;
                settings.CommandColumn.ShowEditButton = true;
                settings.CommandColumn.VisibleIndex = 0;
                settings.Settings.HorizontalScrollBarMode = ScrollBarMode.Auto;


                settings.CallbackRouteValues = ListUrl;
                settings.SettingsEditing.AddNewRowRouteValues = AddNewUrl;
                settings.SettingsEditing.UpdateRowRouteValues = UpdateUrl;
                settings.SettingsEditing.DeleteRowRouteValues = DeleteUrl;

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.AvatarBytes);
                    column.Caption = "Avatar";
                    column.Settings.ShowFilterRowMenu = DefaultBoolean.False;
                    column.Settings.AllowAutoFilter = DefaultBoolean.False;
                    column.Width = Unit.Pixel(100);
                    column.EditorProperties().BinaryImage(p =>
                    {
                        p.ImageHeight = 80;
                        p.ImageWidth = 80;
                        p.EnableServerResize = true;
                        p.ImageSizeMode = ImageSizeMode.FitProportional;
                        p.CallbackRouteValues = AvatarUpdateUrl;
                        p.EditingSettings.Enabled = true;
                        p.EditingSettings.UploadSettings.UploadValidationSettings.MaxFileSize = 4194304;
                    });
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Email);
                    column.Caption = "Email";
                    column.ColumnType = MVCxGridViewColumnType.TextBox;
                    column.Width = Unit.Pixel(150);

                    column.EditorProperties().TextBox(c =>
                    {
                        c.ValidationSettings.RequiredField.IsRequired = true;

                    });
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Password);
                    column.Caption = "Password";
                    column.ColumnType = MVCxGridViewColumnType.TextBox;
                    column.Width = Unit.Pixel(150);

                    column.SetDataItemTemplateContent(c =>
                    {
                        html?.ViewContext.Writer.Write("*****");
                    });

                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Firstname);
                    column.Caption = "Firstname";
                    column.ColumnType = MVCxGridViewColumnType.TextBox;
                    column.Width = Unit.Pixel(150);
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Lastname);
                    column.Caption = "Lastname";
                    column.ColumnType = MVCxGridViewColumnType.TextBox;
                    column.Width = Unit.Pixel(150);
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.IsActive); column.Caption = "Is Active"; column.Width = Unit.Pixel(100); column.ColumnType = MVCxGridViewColumnType.CheckBox;
                    column.EditorProperties().CheckBox(c =>
                    {
                        c.ClientInstanceName = "IsActiveCheckBox";
                        c.ClientSideEvents.Init = "function(s,e){ OnIsActiveCheckBoxInit(s,e); }";
                    });

                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.RoleID);
                    column.Caption = "Role";
                    column.ColumnType = MVCxGridViewColumnType.ComboBox;
                    column.Width = Unit.Pixel(150);
                    column.EditorProperties().ComboBox(c =>
                    {
                        c.DataSource = Roles;
                        c.ValueField = "Key";
                        c.TextField = "Value";
                        c.ValueType = typeof(int?);
                        c.ValidationSettings.RequiredField.IsRequired = true;
                    });


                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.About);
                    column.Caption = "About";
                    column.ColumnType = MVCxGridViewColumnType.TextBox;
                    column.Width = Unit.Pixel(250);
                });

                settings.Columns.Add(column => { column.SetEditItemTemplateContent(" "); });

                settings.CellEditorInitialize = (s, e) =>
                {
                    var editor = (ASPxEdit)e.Editor;
                    editor.ValidationSettings.Display = Display.Dynamic;
                };
                return settings;
            }

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

    #endregion

    #region Roles

    public class RolesViewModel
    {
        public RolesGridViewModel GridViewModel { get; set; }

        public class RolesGridViewModel : GridViewModelBase
        {
            public List<RoleGridItem> GridItems { get; set; }

            public GridViewSettings GetGridViewSettings(GridViewSettings settings, HtmlHelper html)
            {
                settings = GenerateGridViewDefaultSettings(settings);
                RoleGridItem model;

                settings.Name = "RoleGrid";
                settings.KeyFieldName = nameof(model.ID);

                settings.CommandColumn.Visible = true;
                settings.CommandColumn.ShowDeleteButton = true;
                settings.CommandColumn.ShowEditButton = true;
                settings.CommandColumn.VisibleIndex = 2;


                settings.CallbackRouteValues = ListUrl;
                settings.SettingsEditing.AddNewRowRouteValues = AddNewUrl;
                settings.SettingsEditing.UpdateRowRouteValues = UpdateUrl;
                settings.SettingsEditing.DeleteRowRouteValues = DeleteUrl;

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Caption);
                    column.Caption = "Caption";
                    column.ColumnType = MVCxGridViewColumnType.TextBox;
                    column.Width = Unit.Pixel(150);

                    column.EditorProperties().TextBox(c =>
                    {
                        c.ValidationSettings.RequiredField.IsRequired = true;

                    });
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Code);
                    column.Caption = "Code";
                    column.ColumnType = MVCxGridViewColumnType.SpinEdit;
                    column.Width = Unit.Pixel(150);

                    column.EditorProperties().SpinEdit(c =>
                    {
                        c.SpinButtons.ShowIncrementButtons = false;
                    });

                });

                settings.Columns.Add(column => { column.SetEditItemTemplateContent(" "); });

                settings.CellEditorInitialize = (s, e) =>
                {
                    var editor = (ASPxEdit)e.Editor;
                    editor.ValidationSettings.Display = Display.Dynamic;
                };

                return settings;
            }

            public class RoleGridItem
            {
                public int? ID { get; set; }
                public string Caption { get; set; }
                public int? Code { get; set; }
            }

        }
    }

    #endregion

    #region Permissions

    public class PermissionsViewModel
    {
        public PermissionsTreeViewModel TreeViewModel { get; set; }

        public class PermissionsTreeViewModel : TreeListViewModelBase
        {
            public List<PermissionTreeItem> TreeItems { get; set; }

            public TreeListSettings GeTreeListSettings(TreeListSettings settings, HtmlHelper html)
            {
                settings = GenerateTreeListDefaultSettings(settings);
                PermissionTreeItem model;
                settings.Name = "PermissionsTree";

                settings.KeyFieldName = nameof(model.ID);
                settings.ParentFieldName = nameof(model.ParentID);

                settings.CallbackRouteValues = ListUrl;
                settings.SettingsEditing.AddNewNodeRouteValues = AddNewUrl;
                settings.SettingsEditing.UpdateNodeRouteValues = UpdateUrl;
                settings.SettingsEditing.DeleteNodeRouteValues = DeleteUrl;

                settings.CommandColumn.Visible = true;
                settings.CommandColumn.NewButton.Visible = true;
                settings.CommandColumn.DeleteButton.Visible = true;
                settings.CommandColumn.EditButton.Visible = true;
                settings.CommandColumn.VisibleIndex = 0;
                settings.Settings.HorizontalScrollBarMode = ScrollBarMode.Auto;
                settings.SettingsBehavior.AutoExpandAllNodes = true;

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Caption);
                    column.Caption = "Caption";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(300);

                    column.EditorProperties().TextBox(c =>
                    {
                        c.ValidationSettings.RequiredField.IsRequired = true;

                    });
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Url);
                    column.Caption = "Url";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(300);

                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Code);
                    column.Caption = "Code";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(300);

                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.IconName);
                    column.Caption = "Icon";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(170);

                });


                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.IsMenuItem); column.Caption = "Is Menu Item"; column.Width = Unit.Pixel(150); column.ColumnType = MVCxTreeListColumnType.CheckBox;

                });


                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.SortIndex);
                    column.Caption = "Sort Index";
                    column.ColumnType = MVCxTreeListColumnType.SpinEdit;
                    column.Width = Unit.Pixel(130);

                    column.EditorProperties().SpinEdit(c =>
                    {
                        c.SpinButtons.ShowIncrementButtons = false;
                    });
                });

                settings.Columns.Add(column => { column.SetEditCellTemplateContent(" "); });

                settings.CellEditorInitialize = (s, e) =>
                {
                    var editor = (ASPxEdit)e.Editor;
                    editor.ValidationSettings.Display = Display.Dynamic;
                };
                return settings;
            }

            public class PermissionTreeItem
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public string Caption { get; set; }
                public string Url { get; set; }
                public string IconName { get; set; }
                public bool IsMenuItem { get; set; }
                public string Code { get; set; }
                public int? SortIndex { get; set; }
            }

        }

    }

    #endregion

    #region RolePermissions

    public class RolePermissionsViewModel
    {
        public RolePermissionsRolesGridViewModel RolesGridViewModel { get; set; }
        public RolePermissionsPermissionsTreeViewModel PermissionsTreeViewModel { get; set; }

        public string GetRolePermissionsUrl { get; set; }
        public string UpdateRolePermissionsUrl { get; set; }

        public class RolePermissionsRolesGridViewModel : GridViewModelBase
        {
            public List<RolePermissionsRoleGridItem> GridItems { get; set; }

            public GridViewSettings GetGridViewSettings(GridViewSettings settings, HtmlHelper html = null)
            {
                settings = GenerateGridViewDefaultSettings(settings);
                RolePermissionsRoleGridItem model;
                settings.Name = "RolesGrid";
                settings.KeyFieldName = nameof(model.ID);

                settings.CallbackRouteValues = ListUrl;
                settings.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
                settings.Settings.ShowFilterRowMenu = false;
                settings.Settings.ShowFilterRow = false;


                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Caption);
                    column.Caption = "Caption";
                    column.ColumnType = MVCxGridViewColumnType.TextBox;
                    column.Width = Unit.Pixel(150);

                });

                settings.ClientSideEvents.FocusedRowChanged = "function(s,e){ OnGridViewFocusedRowChanged(s, e); }";

                return settings;
            }

            public class RolePermissionsRoleGridItem
            {
                public int? ID { get; set; }
                public string Caption { get; set; }

            }

        }

        public class RolePermissionsPermissionsTreeViewModel : TreeListViewModelBase
        {
            public List<RolePermissionsPermissionTreeItem> TreeItems { get; set; }

            public TreeListSettings GeTreeListSettings(TreeListSettings settings, HtmlHelper html = null)
            {
                settings = GenerateTreeListDefaultSettings(settings);
                RolePermissionsPermissionTreeItem model;
                settings.Name = "PermissionsTree";

                settings.KeyFieldName = nameof(model.ID);
                settings.ParentFieldName = nameof(model.ParentID);

                settings.SettingsBehavior.AutoExpandAllNodes = true;
                settings.SettingsSelection.Enabled = true;

                settings.CallbackRouteValues = ListUrl;

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Caption);
                    column.Caption = "Caption";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(200);

                });

                return settings;
            }

            public class RolePermissionsPermissionTreeItem
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public string Caption { get; set; }
            }
        }

    }

    #endregion
}