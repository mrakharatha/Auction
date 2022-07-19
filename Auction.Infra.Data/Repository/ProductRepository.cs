using System.Collections.Generic;
using System.Linq;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
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
    }
}