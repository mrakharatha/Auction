using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Auction.Infra.Data.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetCategory()
        {
            return _context.Categories
                .Select(x => new SelectListItem()
                {
                    Text =x.CategoryName,
                    Value = x.CategoryId.ToString()
                })
                .ToList();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}