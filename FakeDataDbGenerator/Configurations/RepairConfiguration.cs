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
            modelbuilder.HasKey(r => r.Id);
            modelbuilder.Property(r => r.Id).HasColumnName("Id");

            modelbuilder.Property(r => r.Cost).HasColumnType("decimal(10, 2)");

            modelbuilder.Property(r => r.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(r => r.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(r => r.Description).HasMaxLength(2000);

            modelbuilder.Property(r => r.RepairDate).HasColumnType("date");

            modelbuilder.Property(r => r.TruckId).HasColumnName("TruckID");

            modelbuilder.Property(r => r.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.HasOne(r => r.Truck)
                .WithMany(t => t.Repairs)
                .HasForeignKey(r => r.TruckId)
                .HasConstraintName("FK__Repairs__TruckID__34C8D9D1");
        }
    }
}
