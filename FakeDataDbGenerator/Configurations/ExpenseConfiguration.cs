using FakeDataDriverDbGenerator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeDataDriverDbGenerator.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> modelbuilder)
        {
            modelbuilder.HasKey(e => e.Id);
            modelbuilder.Property(e => e.Id).HasColumnName("Id");

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

        modelbuilder.HasOne(e => e.Driver)
                    .WithMany(d => d.Expenses)
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expenses__Driver__412EB0B6");

            modelbuilder.HasOne(e => e.Truck)
                        .WithMany(t => t.Expenses)
                        .HasForeignKey(e => e.TruckId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Expenses__TruckI__4222D4EF");
        }
    }
}
