using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;

        public DashboardController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetActivity(User.GetUserId()));
        }
    }
}
