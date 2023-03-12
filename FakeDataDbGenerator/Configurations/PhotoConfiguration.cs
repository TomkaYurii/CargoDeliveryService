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
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> modelbuilder)
        {
            modelbuilder.Property(e => e.PhotoId).HasColumnName("PhotoID");

            modelbuilder.Property(e => e.ContentType).HasMaxLength(50);

            modelbuilder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(e => e.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(e => e.FileName).HasMaxLength(255);

            modelbuilder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }
}
