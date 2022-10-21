using Database.Models;

namespace ASPNET.Models
{
    public class EventsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public List<Database.Models.Genre> EventTypes { get; set; }
    }
}
