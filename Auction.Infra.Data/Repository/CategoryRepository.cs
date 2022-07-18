using System.Collections.Generic;
using System.Linq;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Infra.Data.Context;

namespace Auction.Infra.Data.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}