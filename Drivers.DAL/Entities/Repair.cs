using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public class Repair
    {
        public int RepairID { get; set; }
        public DateTime RepairDate { get; set; }
        public string Description { get; set; } = default!;
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int? TruckID { get; set; }
        public Truck? Truck { get; set; }
    }

}
