using ASPNET.Helpers;
using ASPNET.Models;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Controllers
{
    public class PlacesController : Controller
    {
        private readonly EventsDbContext context;
        private readonly UserManager<User> userManager;

        public PlacesController(EventsDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
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
        public async Task<IActionResult> Create(Place p)
        {
            if (HttpContext.User.Identity == null) return BadRequest();
            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            p.Owner = user;
            user.CreatedPlaces.Add(p);

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

            context.Images.Add(img1);
            context.Images.Add(img2);
            context.Images.Add(img3);

            context.Places.Add(p);
            context.SaveChanges();

            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Place was created successully!",
                Action = Models.Action.Create
            };
            var places = context.Places.Include(p => p.PlaceTypes).Include(e => e.Owner).ToList();

            return View(nameof(Manage), places);
        }

        public IActionResult Edit(int id)
        {
            var p = context.Places.Find(id);

            return View(nameof(Create), p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Place p)
        {
            if (HttpContext.User.Identity == null) return BadRequest();
            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            p.Owner = user;
            user.CreatedPlaces.Add(p);

            context.Places.Update(p);
            context.SaveChanges();
            var places = context.Places.Include(p => p.PlaceTypes).Include(e => e.Owner).ToList();

            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Place was changed successully!",
                Action = Models.Action.Update
            };

            return View(nameof(Manage), places);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var place = context.Places.Where(p => p.Id == id).Include(p => p.Events).Include(p=>p.Images).First();

            if (place == null) return NotFound();

            context.Places.Remove(place);
            context.SaveChanges();
            var places = context.Places.Include(p => p.PlaceTypes).Include(e => e.Owner).ToList();
            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Place was delated successully!",
                Action = Models.Action.Delete
            };

            return View(nameof(Manage),places);
        }
    }
}
