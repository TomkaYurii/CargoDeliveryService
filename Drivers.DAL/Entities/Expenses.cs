using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public class Expenses
    {
        public int ExpensesID { get; set; }
        public decimal DriverPayment { get; set; }
        public decimal FuelCost { get; set; }
        public decimal MaintenanceCost { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public int DriverID { get; set; }
        public int TruckID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
