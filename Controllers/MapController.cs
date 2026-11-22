using Microsoft.AspNetCore.Mvc;

namespace LaGilap.Controllers
{
    public class MapController : Controller
    {
        public IActionResult LagoonMap()
        {
            return View();
        }
    }
}
