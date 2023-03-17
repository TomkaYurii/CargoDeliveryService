using System;
using System.Collections.Generic;
using FakeDataDriverDbGenerator.Configurations;
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            //modelBuilder.ApplyConfiguration(new DriverConfiguration());




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
