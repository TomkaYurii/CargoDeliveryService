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
                modelbuilder.HasIndex(d => d.PhotoId, "UQ__Drivers__21B7B583AB601A5C")
                    .IsUnique();

                modelbuilder.HasIndex(d => d.CompanyId, "UQ__Drivers__2D971C4D3AD2DF5B")
                    .IsUnique();
                modelbuilder.HasKey(d => d.Id);
                modelbuilder.Property(d => d.Id).HasColumnName("Id");

                modelbuilder.Property(d => d.Address).HasMaxLength(100);

                modelbuilder.Property(d => d.Birthdate).HasColumnType("date");

                modelbuilder.Property(d => d.CompanyId).HasColumnName("CompanyID");

                modelbuilder.Property(d => d.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                modelbuilder.Property(d => d.DeletedAt).HasColumnType("datetime");

                modelbuilder.Property(d => d.DriverLicenseCategory).HasMaxLength(50);

                modelbuilder.Property(d => d.DriverLicenseExpirationDate).HasColumnType("date");

                modelbuilder.Property(d => d.DriverLicenseIssuingAuthority).HasMaxLength(100);

                modelbuilder.Property(d => d.DriverLicenseIssuingDate).HasColumnType("date");

                modelbuilder.Property(d => d.DriverLicenseNumber).HasMaxLength(20);

                modelbuilder.Property(d => d.Email).HasMaxLength(50);

                modelbuilder.Property(d => d.EmploymentEndDate).HasColumnType("date");

                modelbuilder.Property(d => d.EmploymentStartDate).HasColumnType("date");

                modelbuilder.Property(d => d.EmploymentStatus).HasMaxLength(50);

                modelbuilder.Property(d => d.FirstName).HasMaxLength(50);

                modelbuilder.Property(d => d.Gender).HasMaxLength(10);

                modelbuilder.Property(d => d.IdentificationExpirationDate).HasColumnType("date");

                modelbuilder.Property(d => d.IdentificationNumber).HasMaxLength(50);

                modelbuilder.Property(d => d.IdentificationType).HasMaxLength(50);

                modelbuilder.Property(d => d.LastName).HasMaxLength(50);

                modelbuilder.Property(d => d.MaritalStatus).HasMaxLength(20);

                modelbuilder.Property(d => d.MiddleName).HasMaxLength(50);

                modelbuilder.Property(d => d.Nationality).HasMaxLength(50);

                modelbuilder.Property(d => d.Phone).HasMaxLength(20);

                modelbuilder.Property(d => d.PhotoId).HasColumnName("PhotoID");

                modelbuilder.Property(d => d.PlaceOfBirth).HasMaxLength(100);

                modelbuilder.Property(d => d.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                modelbuilder.HasOne(d => d.Company)
                    .WithOne(c => c.Driver)
                    .HasForeignKey<Driver>(d => d.CompanyId)
                    .HasConstraintName("FK__Drivers__Company__3B75D760");

                modelbuilder.HasOne(d => d.Photo)
                    .WithOne(p => p.Driver)
                    .HasForeignKey<Driver>(d => d.PhotoId)
                    .HasConstraintName("FK__Drivers__PhotoID__3C69FB99");
            }
        }
}