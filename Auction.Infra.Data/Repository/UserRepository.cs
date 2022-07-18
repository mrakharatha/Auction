using System.Linq;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;
using Auction.Infra.Data.Context;

namespace Auction.Infra.Data.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User LoginUser(LoginViewModel login)
        {
            return _context.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
        }
    }
}