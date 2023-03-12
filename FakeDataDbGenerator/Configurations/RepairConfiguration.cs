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
    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure( EntityTypeBuilder<Repair> modelbuilder)
        {
            modelbuilder.Property(e => e.RepairId).HasColumnName("RepairID");

            modelbuilder.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

            modelbuilder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(e => e.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(e => e.Description).HasMaxLength(200);

            modelbuilder.Property(e => e.RepairDate).HasColumnType("date");

            modelbuilder.Property(e => e.TruckId).HasColumnName("TruckID");

            modelbuilder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.HasOne(d => d.Truck)
                .WithMany(p => p.Repairs)
                .HasForeignKey(d => d.TruckId)
                .HasConstraintName("FK__Repairs__TruckID__34C8D9D1");
        }
    }
}
