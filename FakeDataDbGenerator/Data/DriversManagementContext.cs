using System;
using System.Collections.Generic;
using FakeDataDriverDbGenerator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeDataDriverDbGenerator.Data
{
    public partial class DriversManagementContext : DbContext
    {
        public DriversManagementContext()
        {
        }

        public DriversManagementContext(DbContextOptions<DriversManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<Inspection> Inspections { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<Repair> Repairs { get; set; } = null!;
        public virtual DbSet<Truck> Trucks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TOMKA;Initial Catalog=DriversManagement;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactPerson).HasMaxLength(100);

                entity.Property(e => e.ContactPhone).HasMaxLength(20);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasIndex(e => e.PhotoId, "UQ__Drivers__21B7B583AB601A5C")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId, "UQ__Drivers__2D971C4D3AD2DF5B")
                    .IsUnique();

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DriverLicenseCategory).HasMaxLength(50);

                entity.Property(e => e.DriverLicenseExpirationDate).HasColumnType("date");

                entity.Property(e => e.DriverLicenseIssuingAuthority).HasMaxLength(100);

                entity.Property(e => e.DriverLicenseIssuingDate).HasColumnType("date");

                entity.Property(e => e.DriverLicenseNumber).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmploymentEndDate).HasColumnType("date");

                entity.Property(e => e.EmploymentStartDate).HasColumnType("date");

                entity.Property(e => e.EmploymentStatus).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IdentificationExpirationDate).HasColumnType("date");

                entity.Property(e => e.IdentificationNumber).HasMaxLength(50);

                entity.Property(e => e.IdentificationType).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MaritalStatus).HasMaxLength(20);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.PlaceOfBirth).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Company)
                    .WithOne(p => p.Driver)
                    .HasForeignKey<Driver>(d => d.CompanyId)
                    .HasConstraintName("FK__Drivers__Company__3B75D760");

                entity.HasOne(d => d.Photo)
                    .WithOne(p => p.Driver)
                    .HasForeignKey<Driver>(d => d.PhotoId)
                    .HasConstraintName("FK__Drivers__PhotoID__3C69FB99");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.ExpensesId)
                    .HasName("PK__Expenses__DFC8A07C5CE04B84");

                entity.Property(e => e.ExpensesId).HasColumnName("ExpensesID");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.DriverPayment).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FuelCost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MaintenanceCost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.TruckId).HasColumnName("TruckID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expenses__Driver__412EB0B6");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expenses__TruckI__4222D4EF");
            });

            modelBuilder.Entity<Inspection>(entity =>
            {
                entity.Property(e => e.InspectionId).HasColumnName("InspectionID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InspectionDate).HasColumnType("date");

                entity.Property(e => e.TruckId).HasColumnName("TruckID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.Inspections)
                    .HasForeignKey(d => d.TruckId)
                    .HasConstraintName("FK__Inspectio__Truck__300424B4");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.ContentType).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(e => e.RepairId).HasColumnName("RepairID");

                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.RepairDate).HasColumnType("date");

                entity.Property(e => e.TruckId).HasColumnName("TruckID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.Repairs)
                    .HasForeignKey(d => d.TruckId)
                    .HasConstraintName("FK__Repairs__TruckID__34C8D9D1");
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.Property(e => e.TruckId).HasColumnName("TruckID");

                entity.Property(e => e.ChassisNumber).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.EngineNumber).HasMaxLength(50);

                entity.Property(e => e.FuelConsumption).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.FuelType).HasMaxLength(50);

                entity.Property(e => e.InsuranceExpirationDate).HasColumnType("date");

                entity.Property(e => e.InsurancePolicyNumber).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.RegistrationNumber).HasMaxLength(20);

                entity.Property(e => e.TruckNumber).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Vin)
                    .HasMaxLength(50)
                    .HasColumnName("VIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
