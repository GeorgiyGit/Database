using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Route { get; set; }

        public int Rating { get; set; }
        public string? Site { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string GoogleMaps { get; set; }
        
        public User Owner { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<User> LikedUsers { get; set; }
        public ICollection<User> FavoriteUsers { get; set; }


        public ICollection<Event> Events { get; set; }
        public ICollection<Genre> PlaceTypes { get; set; }
        public ICollection<Image> Images { get; set; }

        public Place()
        {
            Comments = new HashSet<Comment>();
            LikedUsers = new HashSet<User>();
            FavoriteUsers = new HashSet<User>();
            Images = new HashSet<Image>();
        }

    }
}
