using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Infra.Data.Context;

namespace Auction.Infra.Data.Repository
{
    public class SettingRepository: ISettingRepository
    {
        private readonly ApplicationContext _context;

        public SettingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Setting GetSetting()
        {
            return _context.Settings.Find(1);
        }

        public void UpdateSetting(Setting setting)
        {
            _context.Update(setting);
            _context.SaveChanges();
        }
    }
}