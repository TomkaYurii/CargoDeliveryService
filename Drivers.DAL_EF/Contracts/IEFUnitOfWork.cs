namespace Drivers.DAL_EF.Contracts;

public interface IEFUnitOfWork
{
    IEFDriverRepository EFDriverRepository { get; }
    IEFCompanyRepository EFCompanyRepository { get; }
    IEFExpenseRepository EFExpenseRepository { get; }
    IEFInspectionRepository EFInspectionRepository { get; }
    IEFPhotoRepository EFPhotoRepository { get; }
    IEFRepairRepository EFPRepairRepository { get; }
    IEFTruckRepository EFPTruckRepository { get; }
    Task SaveChangesAsync();
}
