using ASPNET.Helpers;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Controllers
{
    public class UserControll : Controller
    {
        private readonly EventsDbContext context;

        public UserControll(EventsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.Get<int>(WebConstants.USER);

            if (userId == null) RedirectToAction("Index", "Events");

            var user = context.Users.Find(userId);

            if (user == null) RedirectToAction("Index", "Events");

            return View(user);
        }

        public IActionResult LogIn(User user)
        {
            if (user.Id < 0) return BadRequest();
            
            var u = context.Users.Find(user.Id);

            if (u == null) return NotFound();

            if (u.Password != u.Password) return NotFound();

            //HttpContext.User.


            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

    }
}
