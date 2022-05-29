using Microsoft.AspNetCore.Mvc;
using MishaWork.Models;
using MishaWork.MyDbContext;

namespace MishaWork.Controllers
{
    public class TeacherController : Controller
    {

        ApplicationDbContext db;
        public TeacherController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }
        public IActionResult Observe()
        {
            var users = db.Users.Where(u => u.IsAdmin != true).ToList();
            return View(users);
        }
        public IActionResult CheckWork(int id)
        {
            UserSubject userSubject = new UserSubject();
            userSubject.Subjects.AddRange(db.Subjects.Where(s => s.UserId == id).ToList());
            userSubject.user = db.GetUserById(id);
            return View(userSubject);
        }
        public IActionResult AddWorkToStudent()
        {
            return View("AddWorkView");
        }
        [HttpPost]
        public IActionResult AddWorkToStudent(Subject subject)
        {
            if(subject.Date == null || subject.TeacherComment == null) return RedirectToAction("Observe");
            db.Subjects.Add(subject);
            db.SaveChanges();
            return RedirectToAction("Observe");
        }
        public IActionResult Download(string path)
        {
            string file_type = "application/pdf";
            return PhysicalFile(path, file_type, "Student's work");
        }
    }
   
}
