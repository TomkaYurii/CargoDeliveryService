using Drivers.DAL_EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drivers.DAL_EF.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<EFCompany>
    {
        public void Configure(EntityTypeBuilder<EFCompany> modelbuilder)
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
