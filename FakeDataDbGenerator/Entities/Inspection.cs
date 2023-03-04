﻿using System;
using System.Collections.Generic;

namespace FakeDataDriverDbGenerator.Entities
{
    public partial class Inspection
    {
        public int InspectionId { get; set; }
        public DateTime InspectionDate { get; set; }
        public string? Description { get; set; }
        public bool Result { get; set; }
        public int? TruckId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Truck? Truck { get; set; }
    }
}
