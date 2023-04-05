using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace Drivers.DAL_EF.Repositories;

public class EFDriverRepository : EFGenericRepository<EFDriver>, IEFDriverRepository
{
    private ISortHelper<EFDriver> _sortHelper;
    public EFDriverRepository(DriversManagementContext databaseContext,
        ISortHelper<EFDriver> sortHelper)
        : base(databaseContext)
    {
        _sortHelper = sortHelper;
    }

    public async Task<PagedList<EFDriver>> GetPaginatedDriversAsync(DriverParameters driverParameters)
    {
        var drivers = await FindByCondition(d => d.Birthdate.Year >= driverParameters.MinYearOfBirth &&
                            d.Birthdate.Year <= driverParameters.MaxYearOfBirth);

        SearchByName(ref drivers, driverParameters.LastName);

        var sortedOwners = _sortHelper.ApplySort(drivers, driverParameters.OrderBy);

        return PagedList<EFDriver>.ToPagedList(drivers,
                driverParameters.PageNumber,
                driverParameters.PageSize);
    }
    //////////////////
    //ДОПОМІЖНІ МЕТОДИ
    //////////////////
    private void SearchByName(ref IQueryable<EFDriver> drivers, string LastName)
    {
        if (!drivers.Any() || string.IsNullOrWhiteSpace(LastName))
            return;
        drivers = drivers.Where(d => d.LastName.ToLower().Contains(LastName.Trim().ToLower()));
    }







    public override Task<EFDriver> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
