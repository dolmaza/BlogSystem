using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Post
    {
        public int? ID { get; set; }
        public int? CreatorUserID { get; set; }
        public int? CategoryID { get; set; }
        public int? TypeID { get; set; }
        public int? LanguageID { get; set; }
        public int? StatusID { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? CreateTime { get; set; }

        public User CreatorUser { get; set; }
        public Category Category { get; set; }
        public Dictionary Type { get; set; }
        public Dictionary Language { get; set; }
        public Dictionary Status { get; set; }

        public ICollection<PostRating> Ratings { get; set; }
        public ICollection<PostView> Views { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }

        public Post()
        {
            Views = new List<PostView>();
            Ratings = new List<PostRating>();
            Advertisements = new List<Advertisement>();
            CreateTime = DateTime.Now;
        }
    }
}
