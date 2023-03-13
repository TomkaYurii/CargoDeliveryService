using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace Drivers.DAL_EF.Repositories;

public class EFDriverRepository : EFGenericRepository<EFDriver>, IEFDriverRepository
{
    public EFDriverRepository(DriversManagementContext databaseContext)
        : base(databaseContext)
    {
    }






    public async Task<PagedList<EFDriver>> GetPaginerDrivers(DriverParameters driverParameters)
    {
        return PagedList<EFDriver>.ToPagedList(FindAll(),
                driverParameters.PageNumber,
                driverParameters.PageSize);
    }








    public override Task<EFDriver> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
