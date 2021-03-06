using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MishaWork.Models;
using MishaWork.MyDbContext;

namespace MishaWork.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Calendar(int date)
        {
            if (date <= 0)
                date = 12;
            if (date > 12)
                date = 1;
            var fuckingDate = new DateTime(2022, date, 1);
            return View("calendar",new Date(fuckingDate));
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(User user)
        {
            User temp = db.IsUserExists(user);
            if (temp != null)
                UserUtilities.SetUser(temp);
            return View("Index");
        }
        public IActionResult LogOut()
        {
            UserUtilities.SetUser(null);
            return View("Index");
        }
        [HttpPost]
        public IActionResult AddFile(IFormFile uploadedFile)
        {
            if(uploadedFile == null) return View("Index");
            var us = UserUtilities.GetUser();
            var sub = db.Subjects.Where(subject => subject.UserId == us.Id).FirstOrDefault();
            sub.Path = uploadedFile.FileName;
            db.SaveChanges();
            return View("Index");
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            UserUtilities.SetUser(user);
            return RedirectToAction("Index");
        }
    }
}
