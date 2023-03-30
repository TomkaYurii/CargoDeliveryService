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
    public class InspectionConfiguration : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> modelbuilder)
        {
            modelbuilder.HasKey(i => i.InspectionId);
            modelbuilder.Property(e => e.InspectionId).HasColumnName("InspectionID");

            modelbuilder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(e => e.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(e => e.Description).HasMaxLength(500);

            modelbuilder.Property(e => e.InspectionDate).HasColumnType("date");

            modelbuilder.Property(e => e.TruckId).HasColumnName("TruckID");

            modelbuilder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.HasOne(d => d.Truck)
                .WithMany(p => p.Inspections)
                .HasForeignKey(d => d.TruckId)
                .HasConstraintName("FK__Inspectio__Truck__300424B4");
        }
    }
}
