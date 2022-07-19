using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProducts(User.GetUserId()));
        }


        public IActionResult Create()
        {
            return View();
        }
    }
}
