using System.Collections.Generic;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Auction.Application.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        List<SelectListItem> GetCategory();
    }
}