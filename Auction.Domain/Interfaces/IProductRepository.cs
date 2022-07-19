using System.Collections.Generic;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts(int userId);
        void AddProduct(Product product);
        Product GetProduct(int productId);
        ProductEditViewModel GetProductViewModel(int productId);
        void UpdateProduct(Product product);

    }
}