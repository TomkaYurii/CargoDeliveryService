using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_ADO.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Drivers.DAL_ADO.Repositories
{
    public class RepairRepository : GenericRepository<Repair>, IRepairRepository
    {
        public RepairRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Repairs")
        {

        }
    }
}
