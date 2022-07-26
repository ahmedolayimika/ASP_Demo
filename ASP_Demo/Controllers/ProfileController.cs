using Microsoft.AspNetCore.Mvc;

namespace ASP_Demo.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
