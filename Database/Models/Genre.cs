using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Event> Events { get; set; }
        public ICollection<Place> Places { get; set; }

        public int? ParentId { get; set; }
        public Genre? Parent { get; set; }
        public ICollection<Genre> SubEventTypes { get; }

        public Genre()
        {
            Events = new HashSet<Event>();
            SubEventTypes = new HashSet<Genre>();
            Places = new HashSet<Place>();
        }
    }
}
