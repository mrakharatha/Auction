using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }

        #region Relations

        public List<Product> Products { get; set; }

        #endregion
    }
}