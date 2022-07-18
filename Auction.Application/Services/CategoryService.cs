using System.Collections.Generic;
using Auction.Application.Interfaces;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;

namespace Auction.Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
    }
}