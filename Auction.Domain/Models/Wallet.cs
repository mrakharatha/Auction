using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public WalletType WalletType { get; set; }
        public WalletType Type { get; set; }

        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "شرح")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }

        [Display(Name = "تایید شده")]
        public bool IsPay { get; set; }

        [Display(Name = "تاریخ و ساعت")]
        public DateTime CreateDate { get; set; }=DateTime.Now;

        #region Relations

        public  User User { get; set; }

        #endregion
    }

    public enum WalletType
    {
        [Display(Name = "شارژ کیف پول")]
        Charge=1,



        Increase=2,
        Decrease = 3,
    }
}