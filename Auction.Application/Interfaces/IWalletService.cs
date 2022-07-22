using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.Application.Interfaces
{
    public interface IWalletService
    {
        List<Wallet> GetWalletUser(int userId);
        int BalanceUserWallet(int userId);
        void AddWallet(Wallet wallet);
        int ChargeWallet(int userId, int amount, string description);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);
        void UpdateWallet(WalletType walletType,WalletType type,int userId,int amount,string description);
    }
}