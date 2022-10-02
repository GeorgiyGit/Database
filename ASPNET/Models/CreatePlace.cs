using Database.Models;

namespace ASPNET.Models
{
    public class CreatePlace
    {
        public User Owner { get; set; }
        public IEnumerable<EventType> AllPlaceTypes { get; set; }
        public IEnumerable<EventType> SelectedPlaceTypes { get; set; }
        public Place Place { get; set; }
        public bool IsEdit { get; set; }
    }
}
