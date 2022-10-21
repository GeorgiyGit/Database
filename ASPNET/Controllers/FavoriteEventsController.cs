using Database;
using Microsoft.AspNetCore.Mvc;
using ASPNET.Helpers;
using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Controllers
{
    public class FavoriteEventsController:Controller
    {
        private readonly EventsDbContext context;
        private readonly UserManager<User> userManager;

        public FavoriteEventsController(EventsDbContext context, UserManager<User> userManager,
                                        SignInManager<User> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Identity == null) return BadRequest();

            var user = context.Users.Where(u => u.UserName == HttpContext.User.Identity.Name).Include(u => u.FavoriteEvents).First();

            return View(user.FavoriteEvents);
        }
        public async Task<IActionResult> AddEvent(int id)
        {
            if (id < 0) return BadRequest();

            var ev = context.Events.Where(e => e.Id == id).FirstOrDefault();

            if (ev == null) return NotFound();

            //AddId(id);
            if (HttpContext.User.Identity == null) return BadRequest();

            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            user.FavoriteEvents.Add(ev);
            ev.FavoriteUsers.Add(user);
            context.SaveChanges();

            return RedirectToAction("Index", "Events");
        }

        private void AddId(int id)
        {
            var events = HttpContext.Session.Get<List<int>>(WebConstants.FAVORITE_EVENTS_LIST);
            if (events == null) events = new List<int>();

            events.Add(id);

            HttpContext.Session.Set(WebConstants.FAVORITE_EVENTS_LIST, events);
        }


        public async Task<IActionResult> RemoveEvent(int id)
        {
            if (id < 0) return BadRequest();

            var ev = context.Events.Where(e => e.Id == id).Include(e => e.FavoriteUsers).First();

            if (ev == null) return NotFound();

            if (HttpContext.User.Identity == null) return BadRequest();

            var user = context.Users.Where(u => u.UserName == HttpContext.User.Identity.Name).Include(u => u.FavoriteEvents).First();

            user.FavoriteEvents.Remove(ev);
            ev.FavoriteUsers.Remove(user);
            context.SaveChanges();

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
