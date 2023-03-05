using Drivers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BLL.DTOs.Responces
{
    public class FullDriverResponceDTO
    {
        public Driver? drv { get; set; }
        public Company? cmp { get; set; }
        public Expenses? eps { get; set; }
        public Inspection? exp { get; set; }
        public Photo? pht { get; set; }
        public Repair? rpr { get; set; }
        public Truck? trk { get; set; }
    }
}
