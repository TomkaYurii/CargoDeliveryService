using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_ADO.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Drivers.DAL_ADO.Repositories
{
    public class ExpensesRepository : GenericRepository<Expenses>, IExpensesRepository
    {
        public ExpensesRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Expenses")
        {

        }
    }
}
