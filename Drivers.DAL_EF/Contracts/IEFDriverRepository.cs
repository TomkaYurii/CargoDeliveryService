using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;

namespace Drivers.DAL_EF.Contracts;

public interface IEFDriverRepository : IEFGenericRepository<EFDriver>
{
    Task<PagedList<EFDriver>> GetPaginatedDriversAsync(DriverParameters driverParameters);
}