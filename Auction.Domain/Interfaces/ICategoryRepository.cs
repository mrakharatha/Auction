using System.Collections.Generic;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Auction.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<SelectListItem> GetCategory();
        List<Category> GetCategories();
    }
}