using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IProductService _productService;

        public ProductImageController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            return View(_productService.GetImages(id));
        }

        public IActionResult Create(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductImageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductId = model.ProductId;
                return View(model);
            }

            if (!model.File.IsImage())
            {
                ModelState.AddModelError(nameof(model.File), "لطفا تصویر انتخاب کنید");
                ViewBag.ProductId = model.ProductId;
                return View(model);
            }
            _productService.AddImage(model);

            return RedirectToAction("Index", "ProductImage", new {id = model.ProductId});
        }


        public bool Delete(int id)
        {
            _productService.DeleteImage(id);
            return true;
        }

    }
}
