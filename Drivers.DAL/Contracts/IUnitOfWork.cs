namespace Drivers.DAL_ADO.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDriverRepository _driverRepository { get; }
        ICompanyRepository _companyRepository { get; }
        IExpensesRepository _expensesRepository { get; }
        IInspectionRepository _inspectionRepository { get; }
        IPhotoRepository _photoRepository { get; }
        IRepairRepository _repairRepository { get; }
        ITruckRepository _truckRepository { get; }

        void Commit();
        void Dispose();
    }
}
