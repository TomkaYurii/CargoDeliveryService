using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;

namespace Drivers.DAL_EF.UOW;

public class EFUnitOfWork : IEFUnitOfWork
{
    protected readonly DriversManagementContext databaseContext;

    public IEFDriverRepository EFDriverRepository { get; }

    public IEFCompanyRepository EFCompanyRepository { get; }

    public IEFExpenseRepository EFExpenseRepository { get; }

    public IEFInspectionRepository EFInspectionRepository { get; }

    public IEFPhotoRepository EFPhotoRepository { get; }

    public IEFRepairRepository EFPRepairRepository { get; }

    public IEFTruckRepository EFPTruckRepository { get; }

    public EFUnitOfWork(
        DriversManagementContext databaseContext,
        IEFDriverRepository eFDriverRepository,
        IEFCompanyRepository eFCompanyRepository,
        IEFExpenseRepository eFExpenseRepository,
        IEFInspectionRepository eFInspectionRepository,
        IEFPhotoRepository eFPhotoRepository,
        IEFRepairRepository eFRepairRepository,
        IEFTruckRepository eFTruckRepository)
    {
        this.databaseContext = databaseContext;
        this.EFDriverRepository = eFDriverRepository;
        this.EFCompanyRepository = eFCompanyRepository;
        this.EFExpenseRepository= eFExpenseRepository;
        this.EFPhotoRepository = eFPhotoRepository;
        this.EFInspectionRepository = eFInspectionRepository;
        this.EFPRepairRepository = eFRepairRepository;
        this.EFPTruckRepository = eFTruckRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}