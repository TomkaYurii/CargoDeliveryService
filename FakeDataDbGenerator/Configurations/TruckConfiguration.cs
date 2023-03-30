using FakeDataDriverDbGenerator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDataDriverDbGenerator.Configurations
{
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure (EntityTypeBuilder<Truck> modelbuilder)
        {
            modelbuilder.HasKey(t => t.TruckId);
            modelbuilder.Property(t => t.TruckId).HasColumnName("TruckID");

            modelbuilder.Property(e => e.ChassisNumber).HasMaxLength(50);

            modelbuilder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(e => e.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(e => e.EngineNumber).HasMaxLength(50);

            modelbuilder.Property(e => e.FuelConsumption).HasColumnType("decimal(4, 2)");

            modelbuilder.Property(e => e.FuelType).HasMaxLength(50);

            modelbuilder.Property(e => e.InsuranceExpirationDate).HasColumnType("date");

            modelbuilder.Property(e => e.InsurancePolicyNumber).HasMaxLength(50);

            modelbuilder.Property(e => e.Model).HasMaxLength(50);

            modelbuilder.Property(e => e.RegistrationNumber).HasMaxLength(20);

            modelbuilder.Property(e => e.TruckNumber).HasMaxLength(20);

            modelbuilder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(e => e.Vin)
                .HasMaxLength(50)
                .HasColumnName("VIN");
        }
    }
}
