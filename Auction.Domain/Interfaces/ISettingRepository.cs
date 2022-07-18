using Auction.Domain.Models;

namespace Auction.Domain.Interfaces
{
    public interface ISettingRepository
    {
        Setting GetSetting();
        void UpdateSetting(Setting setting);
    }
}