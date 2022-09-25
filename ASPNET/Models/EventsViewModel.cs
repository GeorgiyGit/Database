using Database.Models;

namespace ASPNET.Models
{
    public class EventsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<EventType> EventTypes { get; set; }
    }
}
