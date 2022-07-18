using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.Domain.Interfaces
{
    public interface IWalletRepository
    {
        List<Wallet> GetWalletUser(int userId);
        int BalanceUserWallet(int userId);
        void AddWallet(Wallet wallet);
        void UpdateWallet(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);

    }
}