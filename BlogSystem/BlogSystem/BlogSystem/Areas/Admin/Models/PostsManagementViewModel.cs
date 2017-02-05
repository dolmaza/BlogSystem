using BlogSystem.Admin.Reusable;
using Service.Utilities;
using System.Collections.Generic;

namespace BlogSystem.Admin.Models
{

    #region Posts

    public class PostsViewModel
    {
        public PostsGridViewModel GridViewModel { get; set; }
        public string PostsAddUrl { get; set; }

        public class PostsGridViewModel : GridViewModelBase
        {
            public List<PostGridItem> GridItems { get; set; }

            public class PostGridItem
            {
                public int? ID { get; set; }
                public string Slug { get; set; }
                public string Title { get; set; }
                public string Description { get; set; }
                public string CoverPhoto { get; set; }
                public string Status { get; set; }
                public string CreateTime { get; set; }


                public string CreatorName { get; set; }
                public string Avatar { get; set; }

                public string EditUrl { get; set; }
                public string DeleteUrl { get; set; }

            }
        }
    }

    public class PostsAddFormModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string CoverPhotoBase64 { get; set; }
        public int? CategoryID { get; set; }
        public int? LanguageID { get; set; }
        public int? StatusID { get; set; }

        public string PostsUrl { get; set; }
        public string SaveUrl { get; set; }

        public List<SimpleKeyValueDropDownItem<int?, string>> Statuses { get; set; }
        public List<SimpleKeyValueDropDownItem<int?, string>> Languages { get; set; }
        public List<TwoLevelDropDownItem> Categories { get; set; }

    }

    #endregion

}