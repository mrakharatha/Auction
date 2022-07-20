using System;
using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Auction.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Auction.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProducts(User.GetUserId()));
        }


        public IActionResult Create()
        {
            GetData();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(model);
            }

            if(!model.File.IsImage())
            {
                ModelState.AddModelError(nameof(model.File),"لطفا تصویر انتخاب کنید");
                GetData();
                return View(model);
            }
            _productService.AddProduct(model);
            return RedirectToAction("Index", "Product");
        }

        public void GetData()
        {
            ViewData["Category"] = new SelectList(_categoryService.GetCategory(), "Value", "Text");
        }

        public IActionResult Edit(int id)
        {
            GetData();
            return View(_productService.GetProductViewModel(id));
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return View(model);
            }

            if (model.File!=null&&!model.File.IsImage())
            {
                ModelState.AddModelError(nameof(model.File), "لطفا تصویر انتخاب کنید");
                GetData();
                return View(model);
            }
            _productService.UpdateProduct(model);
            return RedirectToAction("Index", "Product");
        }


        public IActionResult Search(int? categoryId=null,string filter =null)
        {
            return View(_productService.GetProducts(categoryId,filter,DateTime.Now));
        }


        public IActionResult Detail(int id)
        {
            return View(_productService.GetProductDetail(id));
        }

        public bool Delete(int id)
        {
            _productService.DeleteProduct(id, User.GetUserId());
            return true;
        }

    }
}
