using Database.Models;

namespace ASPNET.Models
{
    public class CreateModel
    {
        public User Owner { get; set; }
        public IEnumerable<EventType> AllEventTypes { get; set; }
        public IEnumerable<EventType> SelectedEventTypes { get; set; }
        public Event Event { get; set; }
        public bool IsEdit { get; set; }
    }
}
