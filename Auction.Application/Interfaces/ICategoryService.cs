using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.Application.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}