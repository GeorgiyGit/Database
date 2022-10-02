using ASPNET.Models;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Controllers
{
    public class PlacesController : Controller
    {
        private readonly EventsDbContext context;

        public PlacesController(EventsDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            var events = context.Places.ToList();

            return View(events);
        }

        public IActionResult Create()
        {
            var cp = new CreatePlace();
            cp.AllPlaceTypes = context.EventTypes.ToList();
            cp.Owner = context.Users.First();
            return View(cp);
        }
        [HttpPost]
        public IActionResult Create(CreatePlace cp)
        {
            var pl = cp.Place;
            cp.Owner = context.Users.First();
            //ev.Types = cm.SelectedEventTypes.ToList();
            pl.Owner = cp.Owner;
            cp.Owner.CreatedPlaces.Add(pl);

            //if (!ModelState.IsValid) return View(ev);

            context.Places.Add(pl);
            context.SaveChanges();
            var events = context.Places.ToList();
            return View(nameof(Manage), events);
        }

        public IActionResult Edit(int id)
        {
            var pl = context.Places.Find(id);

            CreatePlace cp = new CreatePlace();

            cp.AllPlaceTypes = context.EventTypes.ToList();
            cp.Owner = context.Users.First();
            cp.Place = pl;
            cp.IsEdit = true;

            return View(nameof(Create), cp);
        }

        [HttpPost]
        public IActionResult Edit(CreatePlace cp)
        {
            var pl = cp.Place;
            cp.Owner = context.Users.First();
            //ev.Types = cm.SelectedEventTypes.ToList();
            cp.Owner = cp.Owner;
            cp.Owner.CreatedPlaces.Add(pl);

            //if (!ModelState.IsValid) return View(ev);

            context.Places.Update(pl);
            context.SaveChanges();
            var places = context.Places.ToList();
            return View(nameof(Manage), places);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var place = context.Places.Find(id);

            if (place == null) return NotFound();

            context.Places.Remove(place);
            context.SaveChanges();

            return RedirectToAction(nameof(Manage)); //View("Index");
        }
    }
}
