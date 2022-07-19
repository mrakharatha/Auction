using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts(int userId);
    }
}