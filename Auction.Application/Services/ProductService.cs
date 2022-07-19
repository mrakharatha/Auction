using System.Collections.Generic;
using Auction.Application.Interfaces;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;

namespace Auction.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts(int userId)
        {
            return _productRepository.GetProducts(userId);
        }
    }
}