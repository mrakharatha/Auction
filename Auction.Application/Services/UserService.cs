using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsEmailExist(string email)
        {
           email= email.Trim().ToLower();
           return _userRepository.IsEmailExist(email);
        }

        public void SignUp(User user)
        {
            user.Avatar = Generator.Generator.GenerateAvatar();
            user.Password = SecurityHelper.GetSha256Hash(user.Password);
            user.Email = user.Email.Trim().ToLower();
            user.FullName = user.Email.Split("@")[0];
            AddUser(user);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public User LoginUser(LoginViewModel login)
        {
            login.Password = SecurityHelper.GetSha256Hash(login.Password);
            login.Email = login.Email.Trim().ToLower();
            return _userRepository.LoginUser(login);
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetUser(userId);
        }
    }
}