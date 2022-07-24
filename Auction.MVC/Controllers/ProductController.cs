using System;
using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Auction.Domain.Convertors;
using Auction.Domain.Models;
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

            if (!model.File.IsImage())
            {
                ModelState.AddModelError(nameof(model.File), "لطفا تصویر انتخاب کنید");
                GetData();
                return View(model);
            }

            if(model.StartDate.ToDateTime(model.StartTime)>=model.EndDate.ToDateTime(model.EndTime))
            {
                ModelState.AddModelError(nameof(model.EndDate),"تاریخ یا زمان اتمام از تاریخ شروع کوچکتر است");
                GetData();
                return View(model);
            }

            if (model.StartDate.ToDateTime(model.StartTime) <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(model.StartDate), "تاریخ یا زمان َروع از تاریخ جاری سیستم کوچکتر است");
                GetData();
                return View(model);
            }
            _productService.AddProduct(model);
            return RedirectToAction("Index", "Product");
        }

        public void GetData()
        {
            ViewData["Category"] = new SelectList(_categoryService.GetCategory(), "Value", "Text");
            ViewData["ProductType"] = new SelectList(_productService.GetProductType(), "Value", "Text");
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

            if (model.File != null && !model.File.IsImage())
            {
                ModelState.AddModelError(nameof(model.File), "لطفا تصویر انتخاب کنید");
                GetData();
                return View(model);
            }

            if (model.StartDate.ToDateTime(model.StartTime) >= model.EndDate.ToDateTime(model.EndTime))
            {
                ModelState.AddModelError(nameof(model.EndDate), "تاریخ یا زمان اتمام از تاریخ شروع کوچکتر است");
                GetData();
                return View(model);
            }

            if (model.StartDate.ToDateTime(model.StartTime) <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(model.StartDate), "تاریخ یا زمان َروع از تاریخ جاری سیستم کوچکتر است");
                GetData();
                return View(model);
            }

            _productService.UpdateProduct(model);
            return RedirectToAction("Index", "Product");
        }


        public IActionResult Search(int? categoryId = null, string filter = null)
        {
            return View(_productService.GetProducts(categoryId, filter, DateTime.Now));
        }


        public IActionResult Detail(int id)
        {
            ViewBag.ProductDetail = _productService.GetProductDetail(id);
            return View();
        }
        [HttpPost]
        public IActionResult Detail(OfferHistory offerHistory)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductDetail = _productService.GetProductDetail(offerHistory.ProductId);
                return View(offerHistory);
            }

            var result = _productService.CheckPrice(offerHistory.ProductId, offerHistory.UserId, offerHistory.Price);

            if (result.IsSucceed)
            {
                TempData["Status"] = true;
                _productService.AddOfferHistory(offerHistory);
            }
            else
                TempData["Result"] = result.Message;

            return RedirectToAction("Detail", new { id = offerHistory.ProductId });
        }

        public bool Delete(int id)
        {
            _productService.DeleteProduct(id, User.GetUserId());
            return true;
        }

        public IActionResult Auction()
        {
            _productService.CalculateAuction(User.GetUserId());
            return View(_productService.GetAuctionExpire(User.GetUserId()));
        }

        public IActionResult Winner()
        {
            return View(_productService.GetWinner(User.GetUserId()));
        }

        public IActionResult ShippingStatus(int id)
        {
            _productService.UpdateShipping(id);

            return RedirectToAction("Auction", "Product");
        }
        public IActionResult ReceiveStatus(int id)
        {
            _productService.UpdateReceive(id);

            return RedirectToAction("Winner", "Product");
        }
    }
}
