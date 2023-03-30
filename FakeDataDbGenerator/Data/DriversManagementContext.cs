﻿using System;
using System.Collections.Generic;
using FakeDataDriverDbGenerator.Configurations;
using FakeDataDriverDbGenerator.Entities;
using FakeDataDriverDbGenerator.Seeders;
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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TOMKA;Initial Catalog=DriversManagement2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
            modelBuilder.ApplyConfiguration(new RepairConfiguration());
            modelBuilder.ApplyConfiguration(new TruckConfiguration());

            var databaseSeeder = new DriversManagementDatabaseSeeder();

            modelBuilder.Entity<Company>().HasData(databaseSeeder.Companies);
            modelBuilder.Entity<Driver>().HasData(databaseSeeder.Drivers);
            modelBuilder.Entity<Expense>().HasData(databaseSeeder.Expenses);
            modelBuilder.Entity<Inspection>().HasData(databaseSeeder.Inspections);
            modelBuilder.Entity<Photo>().HasData(databaseSeeder.Photos);
            modelBuilder.Entity<Repair>().HasData(databaseSeeder.Repairs);
            modelBuilder.Entity<Truck>().HasData(databaseSeeder.Trucks);
        }
    }
}