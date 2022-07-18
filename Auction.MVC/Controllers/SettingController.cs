using Auction.Application.Interfaces;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.MVC.Controllers
{
    public class SettingController : Controller
    {
     private  readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            return View(_settingService.GetSetting());
        }

        [HttpPost]
        public IActionResult Index(Setting setting)
        {
            if (!ModelState.IsValid)
                return View(setting);

            _settingService.UpdateSetting(setting);
            TempData["Result"] = true;
            return RedirectToAction("Index", "Setting");
        }
    }
}
