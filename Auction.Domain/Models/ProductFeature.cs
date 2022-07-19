using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class ProductFeature
    {
        [Key]
        public int ProductFeatureId { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FeatureName { get; set; }

        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FeatureValue { get; set; }


        #region Relations

        public Product Product { get; set; }

        #endregion
    }
}