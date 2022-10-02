using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Event> Events { get; set; }
        public ICollection<Place> Places { get; set; }

        public int? ParentId { get; set; }
        public EventType? Parent { get; set; }
        public ICollection<EventType> SubEventTypes { get; }

        public EventType()
        {
            Events = new HashSet<Event>();
            SubEventTypes = new HashSet<EventType>();
            Places = new HashSet<Place>();
        }
    }
}
