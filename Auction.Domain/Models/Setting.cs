using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        [Display(Name = "درصد کمیسیون")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(0, 100, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public int CommissionPercentage { get; set; }  
        
        [Display(Name = "پله رشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(0, 100, ErrorMessage = " مقدار  {0} بین {1} تا {2}.")]
        public int GrowthLadder { get; set; }
    }
}