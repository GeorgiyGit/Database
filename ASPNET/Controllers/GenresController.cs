using ASPNET.Helpers;
using ASPNET.Models;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Controllers
{
    public class GenresController : Controller
    {
        private readonly EventsDbContext context;

        public GenresController(EventsDbContext context)
        {
            this.context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manage()
        {
            var genres = context.Genres.Include(e => e.Parent).Include(e => e.SubEventTypes).ToList();

            return View(genres);
        }
        public IActionResult Create()
        {
            var genres = new SelectList(context.Genres, nameof(Genre.Id), nameof(Genre.Name));
            ViewBag.TypeList = genres;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Genre g)
        {
            context.Genres.Add(g);
            context.SaveChanges();
            var genres = context.Genres.ToList();

            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Type was created successully!",
                Action = Models.Action.Create
            };

            return View(nameof(Manage), genres);
        }

        public IActionResult Edit(int id)
        {
            var genres = new SelectList(context.Genres, nameof(Genre.Id), nameof(Genre.Name));
            ViewBag.TypeList = genres;

            var g = context.Genres.Find(id);

            return View(nameof(Create), g);
        }

        [HttpPost]
        public IActionResult Edit(Genre g)
        {
            context.Genres.Update(g);
            context.SaveChanges();
            var genres = context.Genres.ToList();

            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Type was changed successully!",
                Action = Models.Action.Update
            };

            return View(nameof(Manage), genres);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var genre = context.Genres.Find(id);

            if (genre == null) return NotFound();

            context.Genres.Remove(genre);
            context.SaveChanges();

            TempData[WebConstants.TOASTR_MESSAGE] = new Toster()
            {
                Text = "Type was delated successully!",
                Action = Models.Action.Delete
            };

            return RedirectToAction(nameof(Manage)); //View("Index");
        }
    }
}
