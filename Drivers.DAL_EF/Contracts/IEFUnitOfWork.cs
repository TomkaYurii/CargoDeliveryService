namespace Drivers.DAL_EF.Contracts;

public interface IEFUnitOfWork
{
    IEFDriverRepository EFDriverRepository { get; }
    Task SaveChangesAsync();
}
