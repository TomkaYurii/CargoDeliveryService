using Drivers.DAL_EF.Data;

namespace Reservoom.DbContexts
{
    public interface IDriversManagementDbContextFactory
    {
        DriversManagementContext CreateDbContext();
    }
}