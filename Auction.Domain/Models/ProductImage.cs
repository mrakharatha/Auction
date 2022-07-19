using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ProductImageName { get; set; }

        #region Relations

        public Product Product { get; set; }

        #endregion

    }
}