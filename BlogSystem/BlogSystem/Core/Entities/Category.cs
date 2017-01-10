using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Category
    {
        public int? ID { get; set; }
        public int? ParentID { get; set; }
        public string Caption { get; set; }
        public int? Code { get; set; }
        public int? SortIndex { get; set; }
        public DateTime? CreateTime { get; set; }

        public Category Parent { get; set; }
        public ICollection<Category> Childrens { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<User> Users { get; set; }

        public Category()
        {
            CreateTime = DateTime.Now;
            Childrens = new List<Category>();
            Posts = new List<Post>();
            Users = new List<User>();
        }

    }
}
