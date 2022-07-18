using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Domain.Interfaces
{
    public interface IUserRepository
    {
        bool IsEmailExist(string email);
        void AddUser(User user);
        User GetUser(int userId);
        User LoginUser(LoginViewModel login);
    }
}