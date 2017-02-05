using BlogSystem.Admin.Reusable;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BlogSystem.Admin.Models
{
    public class DictionariesViewModel
    {
        public DictionariesTreeViewModel TreeViewModel { get; set; }

        public class DictionariesTreeViewModel : TreeListViewModelBase
        {
            public List<DictionaryTreeItem> TreeItems { get; set; }

            public TreeListSettings GeTreeListSettings(TreeListSettings settings, HtmlHelper html = null)
            {
                settings = GenerateTreeListDefaultSettings(settings);
                DictionaryTreeItem model;
                settings.Name = "DictionariesTree";

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
                settings.CommandColumn.VisibleIndex = 0;
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
                    column.FieldName = nameof(model.CaptionKa);
                    column.Caption = "Caption Ka.";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(150);

                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.CaptionRus);
                    column.Caption = "Caption Rus.";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(150);

                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.StringCode);
                    column.Caption = "String Code";
                    column.ColumnType = MVCxTreeListColumnType.TextBox;
                    column.Width = Unit.Pixel(200);

                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.IntCode);
                    column.Caption = "Int Code";
                    column.ColumnType = MVCxTreeListColumnType.SpinEdit;
                    column.Width = Unit.Pixel(100);

                    column.EditorProperties().SpinEdit(c =>
                    {
                        c.SpinButtons.Visible = false;
                        c.SpinButtons.ShowIncrementButtons = false;
                        c.AllowMouseWheel = false;
                    });
                });

                settings.Columns.Add(column =>
                {
                    column.FieldName = nameof(model.DecimalValue);
                    column.Caption = "Decimal Value";
                    column.ColumnType = MVCxTreeListColumnType.SpinEdit;
                    column.Width = Unit.Pixel(130);

                    column.EditorProperties().SpinEdit(c =>
                    {
                        c.SpinButtons.Visible = false;
                        c.AllowMouseWheel = false;
                        c.SpinButtons.ShowIncrementButtons = false;
                        //c.DisplayFormatString = "";
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
                        c.SpinButtons.ShowIncrementButtons = false;
                        c.AllowMouseWheel = false;
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

            public class DictionaryTreeItem
            {
                public int? ID { get; set; }
                public int? ParentID { get; set; }
                public string Caption { get; set; }
                public string CaptionKa { get; set; }
                public string CaptionRus { get; set; }
                public string StringCode { get; set; }
                public int? IntCode { get; set; }
                public decimal? DecimalValue { get; set; }
                public int? Code { get; set; }
                public int? SortIndex { get; set; }
            }
        }

    }




}