using Database.Models;

namespace ASPNET.Models
{
    public class EventsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Database.Models.Genre> EventTypes { get; set; }
    }
}
