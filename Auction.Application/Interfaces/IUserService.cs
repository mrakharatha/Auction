using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Application.Interfaces
{
    public interface IUserService
    {
        bool IsEmailExist(string email);
        void SignUp(User user);
        void AddUser(User user);
        User LoginUser(LoginViewModel login);
        User GetUser(int userId);
    }
}