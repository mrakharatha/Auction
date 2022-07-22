using System;
using System.Collections.Generic;
using Auction.Application.Interfaces;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;

namespace Auction.Application.Services
{
    public class WalletService: IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public List<Wallet> GetWalletUser(int userId)
        {
            return _walletRepository.GetWalletUser(userId);
        }

        public int BalanceUserWallet(int userId)
        {
            return _walletRepository.BalanceUserWallet(userId);
        }

        public void AddWallet(Wallet wallet)
        {
            _walletRepository.AddWallet(wallet);
        }

        public int ChargeWallet(int userId, int amount, string description)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                Description = description,
                IsPay = false,
                Type =WalletType.Increase,
                WalletType = WalletType.Charge,
                UserId = userId,

            };
            AddWallet(wallet);
            return wallet.WalletId;
        }

        public Wallet GetWalletByWalletId(int walletId)
        {
            return _walletRepository.GetWalletByWalletId(walletId);
        }

        public void UpdateWallet(Wallet wallet)
        {
            _walletRepository.UpdateWallet(wallet);
        }

        public void UpdateWallet(WalletType walletType, WalletType type, int userId, int amount, string description)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                Description = description,
                IsPay = true,
                Type = type,
                WalletType = walletType,
                UserId = userId,
            };
            AddWallet(wallet);
        }
    }
}