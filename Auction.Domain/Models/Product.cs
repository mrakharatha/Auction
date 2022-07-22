using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int UserId { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? CategoryId { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductName { get; set; }
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(1000, int.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

     
        public bool IsFinish { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime EndDate { get; set; }

        public DateTime CreateDate { get; set; }=DateTime.Now;
        public DateTime? DeleteDate { get; set; }

        #region Relations

        public User User { get; set; }
        public Category Category { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductTag> ProductTags { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<OfferHistory> OfferHistories { get; set; }
        public List<Auction> Auctions { get; set; }
        #endregion
    }
}