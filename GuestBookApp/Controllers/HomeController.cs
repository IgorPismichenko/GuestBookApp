using GuestBookApp.Models;
using GuestBookApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GuestBookApp.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryMessages repo;
        IRepositoryUsers repoUs;

        public HomeController(IRepositoryMessages m, IRepositoryUsers u)
        {
            repo = m;
            repoUs = u;
        }

        public async Task<IActionResult> Index()
        {
            var model = await repo.GetMessagesList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Comment([Bind("Id")] Messages comm, string comment)
        {
            comm.Message = comment;
            comm.Date = DateTime.Today.ToString();
            string? login = HttpContext.Session.GetString("Login");
            var users = await repoUs.GetUsersList();
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    comm.UserId = user.Id;
                }
            }
            await repo.Create(comm);
            await repo.Save();
            var model = await repo.GetMessagesList();
            return View("Index", model);
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
