using Microsoft.AspNetCore.Mvc;

namespace StudentsCoursesManager.Controllers
{
    public class StudentCourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
