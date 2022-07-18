using Auction.Domain.Models;

namespace Auction.Application.Interfaces
{
    public interface ISettingService
    {
        Setting GetSetting();
        void UpdateSetting(Setting setting);
    }
}