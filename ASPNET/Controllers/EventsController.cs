using ASPNET.Models;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASPNET.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ASPNET.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsDbContext context;
        private readonly UserManager<User> userManager;

        public EventsController(EventsDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;

            //if (context.Users. == 0)
            //{
            //User u = new User()
            //{
            //Name = "Admin",
            //Email = "Admin@gmail.com",
            ///Password = "1234"
            //};
            //context.Users.Add(u);
            //context.SaveChanges();
            //}
        }

        public async Task<IActionResult> Index()
        {
            var events = context.Events.Include(x => x.Images).Include(e=>e.Owner).Include(e=>e.Place).ToList();

            EventsViewModel eventsViewModel = new EventsViewModel();
            eventsViewModel.Events = events;
            eventsViewModel.EventTypes = context.Genres.ToList();

            if (HttpContext.User.Identity == null) return BadRequest();
            var user = context.Users.Where(u => u.UserName == HttpContext.User.Identity.Name).Include(u => u.FavoriteEvents).First();//await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            ViewData["test"] = new SelectList(user.FavoriteEvents, nameof(Event.Id), nameof(Event.Id))
                                             .ToList()
                                             .Select(x => int.Parse(x.Value)).ToList();

            //ViewBag.FavoriteEvents = new SelectList(user.FavoriteEvents, nameof(Event.Id), nameof(Event.Id));
            return View(eventsViewModel);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0) return BadRequest();

            var _event = context.Events.Where(x => x.Id == id).Include(x => x.Images).First();

            if (_event == null) return NotFound();

            return View(_event);
        }

        public IActionResult Manage()
        {
            var events = context.Events.Include(e => e.Place).Include(e => e.Owner).ToList();

            return View(events);
        }

        public IActionResult Create()
        {
            var places = new SelectList(context.Places, nameof(Place.Id), nameof(Place.Name));
            ViewBag.PlaceTypeList = places;



            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event ev)
        {
            if (HttpContext.User.Identity == null) return BadRequest();
            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            
            ev.Owner = user;
            user.CreatedEvents.Add(ev);

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

            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Event was created successully!",
                Action = Models.Action.Create
            };

            var events = context.Events.Include(e => e.Place).Include(e => e.Owner).ToList();

            return View(nameof(Manage), events);


        }

        public IActionResult Edit(int id)
        {
            var ev = context.Events.Find(id);
            ViewBag.PlaceTypeList = new SelectList(context.Places, nameof(Place.Id), nameof(Place.Name));


            return View(nameof(Create), ev);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Event ev)
        {
            if (HttpContext.User.Identity == null) return BadRequest();
            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            ev.Owner = user;
            user.CreatedEvents.Add(ev);

            context.Events.Update(ev);
            context.SaveChanges();


            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Event was changed successully!",
                Action = Models.Action.Update
            };

            var events = context.Events.Include(e => e.Place).Include(e => e.Owner).ToList();

            return View(nameof(Manage), events);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var _event = context.Events.Where(x => x.Id == id).Include(x => x.Images).First();

            if (_event == null) return NotFound();

            context.Events.Remove(_event);
            context.SaveChanges();

            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Event was deleteed successully!",
                Action = Models.Action.Delete
            };

            var events = context.Events.Include(e => e.Place).Include(e => e.Owner).ToList();

            return View(nameof(Manage), events);
        }
    }
}
