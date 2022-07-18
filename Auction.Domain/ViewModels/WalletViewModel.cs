using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.ViewModels
{
    public class ChargeWalletViewModel
    {
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [Range(1000, int.MaxValue, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]

        public int Amount { get; set; }
    }
}