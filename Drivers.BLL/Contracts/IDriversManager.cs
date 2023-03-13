using Drivers.BLL.DTOs.Responces;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;

namespace Drivers.BLL.Contracts
{
    public interface IDriversManager
    {
        Task<IEnumerable<ShortDriverResponceDTO>> GetListOfAllDrivers();
        Task<FullDriverResponceDTO> GetFullInfoAboutDriver(int id);


        Task<PagedList<EFDriver>> GetPaginatedDrivers(QueryStringParameters queryStringParameters);
    }
}
