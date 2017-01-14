using BlogSystem.Admin.Reusable;
using System.Collections.Generic;

namespace BlogSystem.Admin.Models
{
    public class CategoriesViewModel
    {
        public CategoriesTreeViewModel TreeViewModel { get; set; }

        public class CategoriesTreeViewModel : TreeListViewModelBase
        {
            public List<CategoryTreeItem> TreeItems { get; set; }

            public class CategoryTreeItem
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