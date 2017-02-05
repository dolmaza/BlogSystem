using BlogSystem.Admin.Reusable;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HtmlHelper = System.Web.Mvc.HtmlHelper;

namespace BlogSystem.Admin.Models
{
    public class CategoriesViewModel
    {
        public TreeViewModel Tree { get; set; }

        public class TreeViewModel : TreeListViewModelBase
        {
            public List<TreeItem> TreeItems { get; set; }

            public TreeListSettings GetTreeListSettings(TreeListSettings settings, HtmlHelper html = null)
            {
                settings = GenerateTreeListDefaultSettings(settings);
                TreeItem model;
                settings.Name = "CategoriesTree";

                settings.KeyFieldName = nameof(model.ID);
                settings.ParentFieldName = nameof(model.ParentID);

                settings.CallbackRouteValues = ListUrl;
                settings.SettingsEditing.AddNewNodeRouteValues = AddNewUrl;
                settings.SettingsEditing.UpdateNodeRouteValues = UpdateUrl;
                settings.SettingsEditing.DeleteNodeRouteValues = DeleteUrl;

                settings.Settings.HorizontalScrollBarMode = ScrollBarMode.Auto;

                settings.CommandColumn.Visible = true;
                settings.CommandColumn.NewButton.Visible = true;
                settings.CommandColumn.DeleteButton.Visible = true;
                settings.CommandColumn.EditButton.Visible = true;
                settings.CommandColumn.VisibleIndex = 3;
                settings.SettingsBehavior.AutoExpandAllNodes = true;

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Caption);
                    column.Caption = "Caption";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(250);

                    column.EditorProperties().TextBox(c =>
                    {
                        c.ValidationSettings.RequiredField.IsRequired = true;

                    });
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.Code);
                    column.Caption = "Code";
                    column.ColumnType = MVCxTreeListColumnType.SpinEdit;
                    column.Width = Unit.Pixel(100);

                    column.EditorProperties().SpinEdit(c =>
                    {
                        c.SpinButtons.Visible = false;
                        c.AllowMouseWheel = false;
                        c.SpinButtons.ShowIncrementButtons = false;
                        c.ValidationSettings.RequiredField.IsRequired = true;
                    });
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.SortIndex);
                    column.Caption = "Sort Index";
                    column.ColumnType = MVCxTreeListColumnType.SpinEdit;
                    column.Width = Unit.Pixel(100);

                    column.EditorProperties().SpinEdit(c =>
                    {
                        c.SpinButtons.Visible = false;
                        c.AllowMouseWheel = false;
                        c.SpinButtons.ShowIncrementButtons = false;
                        c.ValidationSettings.RequiredField.IsRequired = true;
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

            public class TreeItem
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public string Caption { get; set; }
                public int? Code { get; set; }
                public int? SortIndex { get; set; }

            }
        }
    }
}