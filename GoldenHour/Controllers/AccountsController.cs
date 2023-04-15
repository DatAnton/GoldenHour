using Microsoft.AspNetCore.Mvc;

namespace GoldenHour.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
