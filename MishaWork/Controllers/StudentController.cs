using Microsoft.AspNetCore.Mvc;
using MishaWork.Models;
using MishaWork.MyDbContext;

namespace MishaWork.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db;
        public StudentController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult OpenCalendar()
        {

            return View("Calendar",new Date(DateTime.Now));
        }
        public IActionResult OpenWorkPage(DateTime tempDate)
        {
            var subjects = db.Subjects.Where(s => s.UserId == UserUtilities.GetUser().Id && s.Date.Day == tempDate.Month && s.Date.Month == tempDate.Day).ToList();
            return View("WorkPage",subjects);
        }

    }
}
