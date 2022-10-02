using ASPNET.Models;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var events = context.Events.Include(x => x.Images).ToList();

            EventsViewModel eventsViewModel = new EventsViewModel();
            eventsViewModel.Events = events;
            eventsViewModel.EventTypes = context.EventTypes.ToList();

            return View(eventsViewModel);
        }

        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var _event = context.Events.Where(x => x.Id == id).Include(x => x.Images).First();

            if (_event == null) return NotFound();

            return View(_event);
        }

        public IActionResult Manage()
        {
            var events = context.Events.ToList();

            return View(events);
        }

        public IActionResult Create()
        {
            var cm = new CreateModel();
            cm.AllEventTypes = context.EventTypes.ToList();
            cm.Owner = context.Users.First();
            return View(cm);
        }
        [HttpPost]
        public IActionResult Create(CreateModel cm)
        {
            var ev = cm.Event;
            cm.Owner = context.Users.First();
            //ev.Types = cm.SelectedEventTypes.ToList();
            ev.Owner = cm.Owner;
            cm.Owner.CreatedEvents.Add(ev);

            //if (!ModelState.IsValid) return View(ev);

            Image img1 = new Image()
            {
                Path = @"https://images.wallpaperscraft.ru/image/single/most_zdaniia_ogni_384679_1600x1200.jpg",
                Title = "First Image"
            };

            Image img2 = new Image()
            {
                Path = @"https://images.wallpaperscraft.ru/image/single/tserkov_ostrov_more_384743_1600x1200.jpg",
                Title = "Second Image"
            };

            Image img3 = new Image()
            {
                Path = @"https://images.wallpaperscraft.ru/image/single/gora_oblaka_les_384664_1600x1200.jpg",
                Title = "Third Image"
            };

            ev.Images.Add(img1);
            ev.Images.Add(img2);
            ev.Images.Add(img3);

            img1.Event = ev;
            img2.Event = ev;
            img3.Event = ev;

            context.Images.Add(img1);
            context.Images.Add(img2);
            context.Images.Add(img3);


            context.Events.Add(ev);
            context.SaveChanges();
            var events = context.Events.ToList();
            return View(nameof(Manage), events);
        }

        public IActionResult Edit(int id)
        {
            var ev = context.Events.Find(id);

            CreateModel cm = new CreateModel();

            cm.AllEventTypes = context.EventTypes.ToList();
            cm.Owner = context.Users.First();
            cm.Event = ev;
            cm.IsEdit = true;

            return View(nameof(Create), cm);
        }

        [HttpPost]
        public IActionResult Edit(CreateModel cm)
        {
            var ev = cm.Event;
            cm.Owner = context.Users.First();
            //ev.Types = cm.SelectedEventTypes.ToList();
            ev.Owner = cm.Owner;
            cm.Owner.CreatedEvents.Add(ev);

            //if (!ModelState.IsValid) return View(ev);

            context.Events.Update(ev);
            context.SaveChanges();
            var events = context.Events.ToList();
            return View(nameof(Manage), events);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var _event = context.Events.Where(x => x.Id == id).Include(x => x.Images).First();

            if (_event == null) return NotFound();

            context.Events.Remove(_event);
            context.SaveChanges();

            return RedirectToAction(nameof(Manage)); //View("Index");
        }
    }
}
