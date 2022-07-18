#nullable enable
using System.Collections.Generic;
using System.Security.Claims;
using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
      private  readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("SignUp")]
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _userService.SignUp(user);

            TempData["Result"] = true;
            return RedirectToAction("SignIn");
        }

        [Route("SignIn")]
        public IActionResult SignIn(string? returnUrl = null)
        {
            if (returnUrl != null)
                ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [Route("SignIn")]
        public ActionResult SignIn(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var user = _userService.LoginUser(login);
            if (user != null)
            {
              
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.FullName),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);

                    if (login.ReturnUrl.HasValue() && Url.IsLocalUrl(login.ReturnUrl))
                        return Redirect(login.ReturnUrl);

                    return RedirectToAction("Index", "Dashboard");
            }


            ModelState.AddModelError(nameof(login.Email), "کاربری با مشخصات وارد شده یافت نشد");
            return View(login);
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn", "Account");
        }
        public bool IsEmailExist(string email)
        {
            var isEmailExist = _userService.IsEmailExist(email);
            return !isEmailExist;
        }
    }
}
