using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts(int userId);

    }
}