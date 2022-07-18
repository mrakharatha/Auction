using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}