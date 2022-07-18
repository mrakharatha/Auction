using System.Collections.Generic;
using System.Linq;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Infra.Data.Context;

namespace Auction.Infra.Data.Repository
{
    public class WalletRepository: IWalletRepository
    {
        private readonly ApplicationContext _context;

        public WalletRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Wallet> GetWalletUser(int userId)
        {
            return _context.Wallets
                .Where(w => w.IsPay && w.UserId == userId)
                .OrderByDescending(x=> x.CreateDate)
                .Take(50).ToList();
        }

        public int BalanceUserWallet(int userId)
        {
            var increase = _context.Wallets
                .Where(w => w.UserId == userId && w.Type == WalletType.Increase && w.IsPay)
                .Sum(w => w.Amount);

            var decrease = _context.Wallets
                .Where(w => w.UserId == userId && w.Type == WalletType.Decrease && w.IsPay)
                .Sum(w => w.Amount);

            return (increase- decrease);
        }

        public void AddWallet(Wallet wallet)
        {
            _context.Add(wallet);
            _context.SaveChanges();
        }

        public void UpdateWallet(Wallet wallet)
        {
            _context.Update(wallet);
            _context.SaveChanges();
        }

        public Wallet GetWalletByWalletId(int walletId)
        {
            return _context.Wallets.Find(walletId);
        }
    }
}