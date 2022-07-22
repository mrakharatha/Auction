using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class OfferHistory
    {
        [Key]
        public int OfferHistoryId { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(1000, int.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;

        #region Relations

        public User User { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}