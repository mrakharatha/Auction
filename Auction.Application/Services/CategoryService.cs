using System.Collections.Generic;
using Auction.Application.Interfaces;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public List<SelectListItem> GetCategory()
        {
            var result = _categoryRepository.GetCategory();

            var items = new List<SelectListItem>()
            {
                new(){Value = null,Text = "لطفا انتخاب کنید"}
            };

            items.AddRange(result);
            return items;
        }
    }
}