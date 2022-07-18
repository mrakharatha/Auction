using Auction.Application.Interfaces;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;

namespace Auction.Application.Services
{
    public class SettingService: ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public Setting GetSetting()
        {
            return _settingRepository.GetSetting();
        }

        public void UpdateSetting(Setting setting)
        {
            _settingRepository.UpdateSetting(setting);
        }
    }
}