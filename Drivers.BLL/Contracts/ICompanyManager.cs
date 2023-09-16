using Drivers.BLL.DTOs.Responses;

namespace Drivers.BLL.Contracts
{
    public interface ICompanyManager
    {
        Task<CompanyResponceDTO> GetCompanyById(int id);
    }
}
