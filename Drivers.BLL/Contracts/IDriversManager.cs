using Drivers.BLL.DTOs.Requests;
using Drivers.BLL.DTOs.Responses;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;

namespace Drivers.BLL.Contracts
{
    public interface IDriversManager
    {
        Task<IEnumerable<ShortDriverResponceDTO>> GetListOfAllDrivers();
        Task<FullDriverResponceDTO> GetFullInfoAboutDriver(int id);
        Task<PagedList<EFDriver>> GetPaginatedDrivers(DriverParameters driverParameters);
        Task<EFDriver> AddDriverToSystemAsync(MiniDriverReqDTO driverDTO, CancellationToken cancellationToken);
    }
}
