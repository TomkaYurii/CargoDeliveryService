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
            modelbuilder.HasKey(p => p.Id);
            modelbuilder.Property(p => p.Id).HasColumnName("Id");

            modelbuilder.Property(p => p.ContentType).HasMaxLength(50);

            modelbuilder.Property(p => p.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            modelbuilder.Property(p => p.DeletedAt).HasColumnType("datetime");

            modelbuilder.Property(p => p.FileName).HasMaxLength(255);

            modelbuilder.Property(p => p.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }
}
