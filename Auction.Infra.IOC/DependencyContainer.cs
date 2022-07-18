using Auction.Application.Interfaces;
using Auction.Application.Services;
using Auction.Domain.Interfaces;
using Auction.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Infra.IOC
{
    public class DependencyContainer
    {
        //Dependency Injection 
        public static void RegisterServices(IServiceCollection service)
        {

            #region Application Layer

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IWalletService, WalletService>();


            #endregion

            #region Infra Data Layer

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IWalletRepository, WalletRepository>();


            #endregion
        }
    }
}
