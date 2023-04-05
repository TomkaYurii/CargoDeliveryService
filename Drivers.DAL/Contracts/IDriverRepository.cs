using Drivers.DAL_ADO.Entities;

namespace Drivers.DAL_ADO.Contracts
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<IEnumerable<Driver>> GetAllDrivers();
        Task<Driver> GetDriversInfo();
        Task<IEnumerable<Driver>> GetTop5DriversByRating();
    }
}
