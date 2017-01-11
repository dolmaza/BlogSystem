using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public int? ID { get; set; }
        public int? RoleID { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public string About { get; set; }
        public DateTime? CreateTime { get; set; }

        public Role Role { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<PostRating> PostRatings { get; set; }
        public ICollection<PostView> PostViews { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }

        public User()
        {
            Categories = new List<Category>();
            Posts = new List<Post>();
            PostViews = new List<PostView>();
            PostRatings = new List<PostRating>();
            Advertisements = new List<Advertisement>();
            CreateTime = DateTime.Now;
        }
    }
}
