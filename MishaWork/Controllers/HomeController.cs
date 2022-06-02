using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MishaWork.Models;
using MishaWork.MyDbContext;

namespace MishaWork.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
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
            return RedirectToAction("Index");
        }
        public IActionResult LogOut()
        {
            UserUtilities.SetUser(null);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile,int id)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                db.Subjects.Where(s => s.Id == id).FirstOrDefault().Path = path;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
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
