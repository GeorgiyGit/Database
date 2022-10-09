using ASPNET.Models;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var events = context.Places.Include(x => x.Images).Include(e => e.Owner).ToList();

            PlacesViewModel placeViewModel = new PlacesViewModel();
            placeViewModel.Places = events;
            placeViewModel.PlaceTypes = context.Genres.ToList();

            return View(placeViewModel);
        }

        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var place = context.Places.Where(x => x.Id == id).Include(x => x.Images).Include(p=>p.PlaceTypes).First();

            if (place == null) return NotFound();

            return View(place);
        }

        public IActionResult Manage()
        {
            var places = context.Places.Include(p => p.PlaceTypes).Include(e => e.Owner).ToList();

            return View(places);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Place p)
        {
            p.Owner = context.Users.First();

            p.Owner.CreatedPlaces.Add(p);

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

            p.Images.Add(img1);
            p.Images.Add(img2);
            p.Images.Add(img3);

            img1.Place = p;
            img2.Place = p;
            img3.Place = p;

            context.Places.Add(p);
            context.SaveChanges();
            var events = context.Places.ToList();

            TempData["ToastrMessage"] = "Place was created sucessfully!";

            return View(nameof(Manage), events);
        }

        public IActionResult Edit(int id)
        {
            var p = context.Places.Find(id);

            return View(nameof(Create), p);
        }

        [HttpPost]
        public IActionResult Edit(Place p)
        {
            p.Owner = context.Users.First();
            p.Owner.CreatedPlaces.Add(p);

            //if (!ModelState.IsValid) return View(ev);

            context.Places.Update(p);
            context.SaveChanges();
            var places = context.Places.ToList();

            TempData["ToastrMessage"] = "Place was changed sucessfully!";

            return View(nameof(Manage), places);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var place = context.Places.Where(p => p.Id == id).Include(p => p.Events).First();

            if (place == null) return NotFound();

            context.Places.Remove(place);
            context.SaveChanges();

            TempData["ToastrMessage"] = "Place was deleted sucessfully!";

            return RedirectToAction(nameof(Manage)); //View("Index");
        }
    }
}
