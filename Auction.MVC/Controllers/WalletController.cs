using System;
using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Auction.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ChargeWalletViewModel charge)
        {
            if (!ModelState.IsValid)
                return View(charge);

            int walletId = _walletService.ChargeWallet(User.GetUserId(), charge.Amount, "شارژ حساب");

            #region Online Payment

            var location = new Uri($"{Request.Scheme}://{Request.Host}");

            var url = location.AbsoluteUri + $"OnlinePayment/{walletId}";

            var payment = new ZarinpalSandbox.Payment(charge.Amount);

            var res = payment.PaymentRequest("شارژ کیف پول", url, "superadmin@gmail.com", "09903565177");

            if (res.Result.Status == 100)
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            
            #endregion

            TempData["Result"] = false;
            return View(charge);
        }



        [Route("OnlinePayment/{id}")]
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var wallet = _walletService.GetWalletByWalletId(id);
                var payment = new ZarinpalSandbox.Payment(wallet.Amount);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    TempData["Result"] = true;
                    wallet.IsPay = true;
                    _walletService.UpdateWallet(wallet);
                }
                else
                    TempData["Result"] = false;
            }
            else
                TempData["Result"] = false;

            return RedirectToAction("Index","Wallet");
        }



    }
}
