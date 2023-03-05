using Drivers.BLL.DTOs.Responces;
using Drivers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BLL.Contracts
{
    public interface IDriversManager
    {
        Task<IEnumerable<ShortDriverResponceDTO>> GetListOfAllDrivers();
        Task<FullDriverResponceDTO> GetFullInfoAboutDriver(int id);
    }
}
