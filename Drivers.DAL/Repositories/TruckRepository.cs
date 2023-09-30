using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_ADO.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Drivers.DAL_ADO.Repositories
{
    public class TruckRepository : GenericRepository<Truck>, ITruckRepository
    {
        public TruckRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Trucks")
        {

        }
    }
}
