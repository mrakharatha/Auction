using Auction.Application.Interfaces;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class ProductFeatureController : Controller
    {
        private readonly IProductService _productService;

        public ProductFeatureController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            return View(_productService.GetFeatures(id));
        }

        public IActionResult Create(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductFeature feature)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductId = feature.ProductId;
                return View(feature);
            }

            _productService.AddFeature(feature);

            return RedirectToAction("Index", "ProductFeature", new {id = feature.ProductId});
        }


        public bool Delete(int id)
        {
            _productService.DeleteFeature(id);
            return true;
        }

    }
}
