using AutoMapper;
using Drivers.BLL.DTOs.Responses;
using Drivers.BLL.Managers.Contracts;
using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_EF.UOW.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BLL.Managers
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ILogger<CompanyManager> _logger;
        private readonly IMapper _mapper;
        private IUnitOfWork _ADOuow;
        private IEFUnitOfWork _EFuow;

        public CompanyManager(ILogger<CompanyManager> logger,
            IMapper mapper,
            IUnitOfWork ado_unitofwork,
            IEFUnitOfWork eFUnitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _ADOuow = ado_unitofwork;
            _EFuow = eFUnitOfWork;
        }

        public async Task<CompanyResponceDTO> GetCompanyById(int id)
        {
            var company = await _EFuow.EFCompanyRepository.GetByIdAsync(id);
            if (company == null) { return null; }

            return _mapper.Map<CompanyResponceDTO>(company);
        }
    }
}
