using Auction.Application.Interfaces;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class ProductTagController : Controller
    {
        private readonly IProductService _productService;

        public ProductTagController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            return View(_productService.GetTags(id));
        }

        public IActionResult Create(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductTag tag)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductId = tag.ProductId;
                return View(tag);
            }

            _productService.AddTag(tag);

            return RedirectToAction("Index", "ProductTag", new {id = tag.ProductId});
        }


        public bool Delete(int id)
        {
            _productService.DeleteTag(id);
            return true;
        }

    }
}
