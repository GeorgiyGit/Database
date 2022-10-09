using Database;
using Microsoft.AspNetCore.Mvc;
using ASPNET.Helpers;
using Database.Models;

namespace ASPNET.Controllers
{
    public class FavoriteEventsController:Controller
    {
        private readonly EventsDbContext context;

        public FavoriteEventsController(EventsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var events = GetEvents();

            return View(events);
        }
        public IActionResult AddEvent(int id)
        {
            if (id < 0) return BadRequest();

            var ev = context.Events.Where(e => e.Id == id).FirstOrDefault();

            if (ev == null) return NotFound();

            AddId(id);

            return RedirectToAction("Index", "Events");
        }

        private void AddId(int id)
        {
            var events = HttpContext.Session.Get<List<int>>(WebConstants.FAVORITE_EVENTS_LIST);
            if (events == null) events = new List<int>();

            events.Add(id);

            HttpContext.Session.Set(WebConstants.FAVORITE_EVENTS_LIST, events);
        }


        public IActionResult RemoveEvent(int id)
        {
            if (id < 0) return BadRequest();

            var ev = context.Events.Find(id);

            if (ev == null) return NotFound();

            RemoveId(id);

            return RedirectToAction("Index", "Events", new { id = id });
        }
        private void RemoveId(int id)
        {
            var events = HttpContext.Session.Get<List<int>>(WebConstants.FAVORITE_EVENTS_LIST);

            if (events == null) return;

            events.Remove(id);

            HttpContext.Session.Set(WebConstants.FAVORITE_EVENTS_LIST, events);
        }

        private List<Event> GetEvents()
        {
            var events = HttpContext.Session.Get<List<int>>(WebConstants.FAVORITE_EVENTS_LIST);
            if (events == null) return new List<Event>();

            var eventsOrigin = events.Select(id => context.Events.Find(id)).ToList();

            if (eventsOrigin == null) return new List<Event>();

            return eventsOrigin;
        }
    }
}
