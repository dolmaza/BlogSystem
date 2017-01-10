using System;

namespace Core.Entities
{
    public class PostView
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public int? PostID { get; set; }
        public string IpAddress { get; set; }
        public int? Count { get; set; }
        public DateTime? CreateTime { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }

        public PostView()
        {
            Count = 0;
            CreateTime = new DateTime();
        }

    }
}
