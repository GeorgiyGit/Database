using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public DateTime CreationTime { get; set; }
        
        public ICollection<Comment> CreatedComments { get; set; }
        public ICollection<Comment> LikedComments { get; set; }
        public ICollection<Comment> DislikedComments { get; set; }

        public ICollection<Event> CreatedEvents { get;set; }
        public ICollection<Event> LikedEvents { get; set; }
        public ICollection<Event> FavoriteEvents { get; set; }

        public ICollection<Place> CreatedPlaces { get; set; }
        public ICollection<Place> LikedPlaces { get; set; }
        public ICollection<Place> FavoritePlaces { get; set; }

        public Image? Avatar { get; set; }
        public User()
        {
            CreatedComments = new HashSet<Comment>();
            LikedComments = new HashSet<Comment>();
            DislikedComments = new HashSet<Comment>();

            CreatedEvents = new HashSet<Event>();
            LikedEvents = new HashSet<Event>();
            FavoriteEvents = new HashSet<Event>();

            CreatedPlaces = new HashSet<Place>();
            LikedPlaces = new HashSet<Place>();
            FavoritePlaces = new HashSet<Place>();

            CreationTime = DateTime.Now;
        }

    }
}
