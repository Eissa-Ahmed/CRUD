using Microsoft.AspNetCore.Mvc;

namespace CRUD.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
