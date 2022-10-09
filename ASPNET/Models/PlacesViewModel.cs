using Database.Models;

namespace ASPNET.Models
{
    public class PlacesViewModel
    {
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Database.Models.Genre> PlaceTypes { get; set; }
    }
}
