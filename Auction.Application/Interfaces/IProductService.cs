using System.Collections.Generic;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts(int userId);
        void AddProduct(ProductViewModel model);
        void AddProduct(Product product);

        Product GetProduct(int productId);
        ProductEditViewModel GetProductViewModel(int productId);
        void UpdateProduct(ProductEditViewModel model);
        void UpdateProduct(Product product);
        void DeleteProduct(int id, int userId);
    }
}