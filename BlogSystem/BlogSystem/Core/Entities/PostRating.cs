using System;

namespace Core.Entities
{
    public class PostRating
    {
        public int? ID { get; set; }
        public int? PostID { get; set; }
        public int? UserID { get; set; }
        public int? Rating { get; set; }
        public DateTime? CreateTime { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }

        public PostRating()
        {
            CreateTime = DateTime.Now;
        }
    }
}
