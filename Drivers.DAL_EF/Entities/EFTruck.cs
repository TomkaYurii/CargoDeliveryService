﻿using System;
using System.Collections.Generic;

namespace Drivers.DAL_EF.Entities
{
    public partial class EFTruck
    {
        public int TruckId { get; set; }
        public string TruckNumber { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Capacity { get; set; }
        public string? FuelType { get; set; }
        public decimal? FuelConsumption { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Vin { get; set; }
        public string? EngineNumber { get; set; }
        public string? ChassisNumber { get; set; }
        public string? InsurancePolicyNumber { get; set; }
        public DateTime? InsuranceExpirationDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<EFExpense> Expenses { get; set; }
        public virtual ICollection<EFInspection> Inspections { get; set; }
        public virtual ICollection<EFRepair> Repairs { get; set; }
    }
}