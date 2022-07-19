using System.Collections.Generic;
using System.Linq;
using Auction.Domain.Convertors;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;
using Auction.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts(int userId)
        {
            return _context.Products
                .Where(x =>
                    x.UserId == userId&&
                    !x.IsFinish)
                .Include(x=> x.Category)
                .OrderBy(x => x.ProductId)
                .ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.Find(productId);
        }

        public ProductEditViewModel GetProductViewModel(int productId)
        {
           return _context.Products
                .Where(x => x.ProductId == productId)
                .Select(x => new ProductEditViewModel()
                {
                    EndDate = x.EndDate.ToShamsi(),
                    StartDate = x.StartDate.ToShamsi(),
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    EndTime = x.EndDate.ToString("HH:mm"),
                    StartTime = x.StartDate.ToString("HH:mm"),
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UserId = x.UserId
                })
                .SingleOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}