using Microsoft.AspNetCore.Mvc;

namespace Ecommers.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
