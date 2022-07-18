using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
