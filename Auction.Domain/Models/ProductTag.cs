using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class ProductTag
    {
        [Key]
        public int ProductTagId { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string TagName { get; set; }

        #region Relations

        public Product Product { get; set; }

        #endregion
    }
}