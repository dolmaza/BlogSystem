using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Dictionary
    {
        public int? ID { get; set; }
        public int? ParentID { get; set; }
        public string Caption { get; set; }
        public string CaptionKa { get; set; }
        public string CaptionRus { get; set; }
        public string StringCode { get; set; }
        public int? IntCode { get; set; }
        public decimal? DecimalValue { get; set; }
        public int? Level { get; set; }
        public string Hierarchy { get; set; }
        public int? Code { get; set; }
        public int? SortIndex { get; set; }
        public DateTime? CreateTime { get; set; }

        public Dictionary Parent { get; set; }

        public ICollection<Dictionary> Childrens { get; set; }
        public ICollection<Post> PostTypes { get; set; }
        public ICollection<Post> PostLanguages { get; set; }
        public ICollection<Post> PostStatuses { get; set; }
        public ICollection<Advertisement> AdvertisementStatuses { get; set; }

        public Dictionary()
        {
            Childrens = new List<Dictionary>();
            PostTypes = new List<Post>();
            PostLanguages = new List<Post>();
            PostStatuses = new List<Post>();
            AdvertisementStatuses = new List<Advertisement>();
            CreateTime = DateTime.Now;
        }
    }
}
