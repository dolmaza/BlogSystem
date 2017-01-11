using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Advertisement
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public int? StatusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string CoverPhoto { get; set; }
        public int? DaysCount { get; set; }
        public int? PostsCount { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreateTime { get; set; }

        public User User { get; set; }
        public Dictionary Status { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Post> Posts { get; set; }

        public Advertisement()
        {
            DaysCount = 0;
            PostsCount = 0;
            Categories = new List<Category>();
            Posts = new List<Post>();
            CreateTime = DateTime.Now;
        }
    }
}
