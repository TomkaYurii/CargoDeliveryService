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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> modelbuilder)
        { 
        modelbuilder.HasKey(e => e.ExpensesId)
                    .HasName("PK__Expenses__DFC8A07C5CE04B84");

        modelbuilder.Property(e => e.ExpensesId).HasColumnName("ExpensesID");

        modelbuilder.Property(e => e.Category)
                    .HasMaxLength(255)
                    .IsUnicode(false);

        modelbuilder.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

        modelbuilder.Property(e => e.Date).HasColumnType("date");

        modelbuilder.Property(e => e.DeletedAt).HasColumnType("datetime");

        modelbuilder.Property(e => e.DriverId).HasColumnName("DriverID");

        modelbuilder.Property(e => e.DriverPayment).HasColumnType("decimal(10, 2)");

        modelbuilder.Property(e => e.FuelCost).HasColumnType("decimal(10, 2)");

        modelbuilder.Property(e => e.MaintenanceCost).HasColumnType("decimal(10, 2)");

        modelbuilder.Property(e => e.Note).HasColumnType("text");

        modelbuilder.Property(e => e.TruckId).HasColumnName("TruckID");

        modelbuilder.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

        modelbuilder.HasOne(d => d.Driver)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expenses__Driver__412EB0B6");

        modelbuilder.HasOne(d => d.Truck)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expenses__TruckI__4222D4EF");
    });
    }
}
