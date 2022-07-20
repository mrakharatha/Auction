using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.Domain.ViewModels
{
    public class AuctionViewModel
    {
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}