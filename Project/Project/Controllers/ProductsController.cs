using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
