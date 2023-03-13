using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;

namespace Drivers.DAL_EF.UOW;

public class EFUnitOfWork : IEFUnitOfWork
{
    protected readonly DriversManagementContext databaseContext;

    public IEFDriverRepository EFDriverRepository { get; }

    public EFUnitOfWork(
        DriversManagementContext databaseContext,
        IEFDriverRepository EFDriverRepository)
    {
        this.databaseContext = databaseContext;
        this.EFDriverRepository = EFDriverRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}