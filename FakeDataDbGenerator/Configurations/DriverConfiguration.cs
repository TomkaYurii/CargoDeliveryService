using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeDataDriverDbGenerator.Entities;

namespace FakeDataDriverDbGenerator.Configurations
{
        public class DriverConfiguration : IEntityTypeConfiguration<Driver>
        {
            public void Configure(EntityTypeBuilder<Driver> modelbuilder)
            {
                modelbuilder.HasIndex(e => e.PhotoId, "UQ__Drivers__21B7B583AB601A5C")
                    .IsUnique();

                modelbuilder.HasIndex(e => e.CompanyId, "UQ__Drivers__2D971C4D3AD2DF5B")
                    .IsUnique();

                modelbuilder.Property(e => e.DriverId).HasColumnName("DriverID");

                modelbuilder.Property(e => e.Address).HasMaxLength(100);

                modelbuilder.Property(e => e.Birthdate).HasColumnType("date");

                modelbuilder.Property(e => e.CompanyId).HasColumnName("CompanyID");

                modelbuilder.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                modelbuilder.Property(e => e.DeletedAt).HasColumnType("datetime");

                modelbuilder.Property(e => e.DriverLicenseCategory).HasMaxLength(50);

                modelbuilder.Property(e => e.DriverLicenseExpirationDate).HasColumnType("date");

                modelbuilder.Property(e => e.DriverLicenseIssuingAuthority).HasMaxLength(100);

                modelbuilder.Property(e => e.DriverLicenseIssuingDate).HasColumnType("date");

                modelbuilder.Property(e => e.DriverLicenseNumber).HasMaxLength(20);

                modelbuilder.Property(e => e.Email).HasMaxLength(50);

                modelbuilder.Property(e => e.EmploymentEndDate).HasColumnType("date");

                modelbuilder.Property(e => e.EmploymentStartDate).HasColumnType("date");

                modelbuilder.Property(e => e.EmploymentStatus).HasMaxLength(50);

                modelbuilder.Property(e => e.FirstName).HasMaxLength(50);

                modelbuilder.Property(e => e.Gender).HasMaxLength(10);

                modelbuilder.Property(e => e.IdentificationExpirationDate).HasColumnType("date");

                modelbuilder.Property(e => e.IdentificationNumber).HasMaxLength(50);

                modelbuilder.Property(e => e.IdentificationType).HasMaxLength(50);

                modelbuilder.Property(e => e.LastName).HasMaxLength(50);

                modelbuilder.Property(e => e.MaritalStatus).HasMaxLength(20);

                modelbuilder.Property(e => e.MiddleName).HasMaxLength(50);

                modelbuilder.Property(e => e.Nationality).HasMaxLength(50);

                modelbuilder.Property(e => e.Phone).HasMaxLength(20);

                modelbuilder.Property(e => e.PhotoId).HasColumnName("PhotoID");

                modelbuilder.Property(e => e.PlaceOfBirth).HasMaxLength(100);

                modelbuilder.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                modelbuilder.HasOne(d => d.Company)
                    .WithOne(p => p.Driver)
                    .HasForeignKey<Driver>(d => d.CompanyId)
                    .HasConstraintName("FK__Drivers__Company__3B75D760");

                modelbuilder.HasOne(d => d.Photo)
                    .WithOne(p => p.Driver)
                    .HasForeignKey<Driver>(d => d.PhotoId)
                    .HasConstraintName("FK__Drivers__PhotoID__3C69FB99");
            }
        }
}

