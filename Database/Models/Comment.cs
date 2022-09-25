using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public DateTime CreationTime { get; set; }
        public bool IsChanged { get; set; }

        public int? ParentId { get; set; }
        public Comment? Parent { get; set; }
        public ICollection<Comment> SubComments { get; } = new List<Comment>();

        public User Owner { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public ICollection<User> LikeUsers { get; set; }
        public ICollection<User> DislikeUsers { get; set; }
 
        public Comment()
        {
            LikeUsers = new HashSet<User>();
            DislikeUsers = new HashSet<User>();
            SubComments = new HashSet<Comment>();
            CreationTime = DateTime.Now;
        }
    }
}
