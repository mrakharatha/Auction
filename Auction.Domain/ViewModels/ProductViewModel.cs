using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Auction.Domain.ViewModels
{
    public class ProductViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "نوع محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ProductType? ProductType { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? CategoryId { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductName { get; set; }
        [Display(Name = "عکس محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile File { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(1000, int.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public int Price { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EndDate { get; set; }

        [Display(Name = "ساعت شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string StartTime{ get; set; }

        [Display(Name = "ساعت پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EndTime { get; set; }
    }


    public class ProductEditViewModel
    {

        public int ProductId { get; set; }
        public int UserId { get; set; }
        [Display(Name = "نوع محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ProductType? ProductType { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? CategoryId { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductName { get; set; }
        [Display(Name = "عکس محصول")]
        public IFormFile File { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(1000, int.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public int Price { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EndDate { get; set; }

        [Display(Name = "ساعت شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string StartTime { get; set; }

        [Display(Name = "ساعت پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EndTime { get; set; }
    }

    public class ActivityViewModel
    {
        public int ActiveOffers { get; set; }
        public int WinningItems { get; set; }
        public int AuctionItems { get; set; }
    }
    public class ProductsExpireAuctionViewModel
    {
        public Product Product { get; set; }
        public OfferHistory OfferHistory { get; set; }
    }
    public class ProductDetailViewModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string FullName { get; set; }
        public int Price { get; set; }
        public int WholeOffer { get; set; }
        public int ActiveBidders { get; set; }
        public string EndDate { get; set; }
        public string  Description { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<OfferHistory> OfferHistories { get; set; }
        public string ProductType { get; set; }
    }
    public class ProductImageViewModel
    {
        public int ProductId { get; set; }
        [Display(Name = "عکس محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile File { get; set; }
    }
}