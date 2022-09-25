using ASPNET.Data;
using ASPNET.Models;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsDbContext context;

        public EventsController(EventsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var events = context.Events.ToList();

            EventsViewModel eventsViewModel = new EventsViewModel();
            eventsViewModel.Events = events;
            eventsViewModel.EventTypes = context.EventTypes.ToList();

            return View(eventsViewModel);
        }

        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var _event = context.Events.Find(id);

            if (_event == null) return NotFound();

            return View(_event);
        }

        public IActionResult Manage()
        {
            var events = context.Events.ToList();

            return View(events);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var _event = context.Events.Find(id);

            if (_event == null) return NotFound();

            context.Events.Remove(_event);
            context.SaveChanges();

            return RedirectToAction(nameof(Manage)); //View("Index");
        }
    }
}
