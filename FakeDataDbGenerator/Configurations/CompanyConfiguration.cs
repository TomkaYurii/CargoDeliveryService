using FakeDataDriverDbGenerator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FakeDataDriverDbGenerator.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> modelbuilder)
        {
            modelbuilder.Property(e => e.CompanyId).HasColumnName("CompanyID");
            modelbuilder.Property(e => e.Address).HasMaxLength(100);

            modelbuilder.Property(e => e.CompanyName).HasMaxLength(100);

            modelbuilder.Property(e => e.ContactEmail).HasMaxLength(50);

            modelbuilder.Property(e => e.ContactPerson).HasMaxLength(100);

            modelbuilder.Property(e => e.ContactPhone).HasMaxLength(20);

            modelbuilder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(e => e.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(e => e.Email).HasMaxLength(50);

            modelbuilder.Property(e => e.Phone).HasMaxLength(20);

            modelbuilder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

        }
    }
}
