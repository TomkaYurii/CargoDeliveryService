using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_ADO.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Drivers.DAL_ADO.Repositories
{
    public class InspectionRepository : GenericRepository<Inspection>, IInspectionRepository
    {
        public InspectionRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Inspections")
        {

        }
    }
}
