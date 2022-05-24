using Microsoft.AspNetCore.Mvc;

namespace SDS.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
