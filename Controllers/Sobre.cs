using Microsoft.AspNetCore.Mvc;

namespace PKX.Controllers
{
    public class Sobre : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
