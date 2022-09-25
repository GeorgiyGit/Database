using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
        public DateTime CreationTime { get; set; }
        public DateTime EventTime { get; set; }
        public ICollection<EventType> Types { get; set; }
        public int Price { get; set; }
        public User Owner { get; set; }

        public ICollection<User> LikedUsers { get; set; }
        public ICollection<User> FavoriteUsers { get; set; }


        public ICollection<Image> Images { get; set; }
        public Event()
        {
            Types = new HashSet<EventType>();
            Images = new HashSet<Image>();
            LikedUsers=new HashSet<User>();
            FavoriteUsers = new HashSet<User>();

            CreationTime = DateTime.Now;
        }
    }
}
