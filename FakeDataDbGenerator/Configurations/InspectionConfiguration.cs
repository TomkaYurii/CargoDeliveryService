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
            modelbuilder.HasKey(i => i.Id);
            modelbuilder.Property(i => i.Id).HasColumnName("Id");

            modelbuilder.Property(i => i.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(i => i.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(i => i.Description).HasMaxLength(500);

            modelbuilder.Property(i => i.InspectionDate).HasColumnType("date");

            modelbuilder.Property(i => i.TruckId).HasColumnName("TruckID");

            modelbuilder.Property(i => i.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.HasOne(i => i.Truck)
                .WithMany(t => t.Inspections)
                .HasForeignKey(i => i.TruckId)
                .HasConstraintName("FK__Inspectio__Truck__300424B4");
        }
    }
}
