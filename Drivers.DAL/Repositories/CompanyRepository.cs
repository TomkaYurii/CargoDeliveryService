using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_ADO.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Drivers.DAL_ADO.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Companies")
        {

        }
    }
}
