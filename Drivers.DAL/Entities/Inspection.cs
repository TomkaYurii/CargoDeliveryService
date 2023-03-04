﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Entities
{
    public class Inspection
    {
        public int InspectionID { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Description { get; set; } = default!;
        public bool Result { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int TruckID { get; set; }
        public Truck Truck { get; set; }
    }

}
