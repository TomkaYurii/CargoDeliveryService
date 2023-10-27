namespace CargoDeliveryBlog.Databases.EntityConfigurations;

using CargoDeliveryBlog.Domain.BlogPosts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    /// <summary>
    /// The database configuration for BlogPosts. 
    /// </summary>
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        // Relationship Marker -- Deleting or modifying this comment could cause incomplete relationship scaffolding
        builder.HasMany(x => x.Likes)
            .WithOne(x => x.BlogPost);
        builder.HasMany(x => x.Comments)
            .WithOne(x => x.BlogPost);
        builder.HasOne(x => x.User)
            .WithOne(x => x.BlogPost)
            .HasForeignKey<BlogPost>(s => s.Id);
        builder.HasOne(x => x.Driver)
            .WithOne(x => x.BlogPost)
            .HasForeignKey<BlogPost>(s => s.Id);

        // Property Marker -- Deleting or modifying this comment could cause incomplete relationship scaffolding
        
        // example for a more complex value object
        // builder.OwnsOne(x => x.PhysicalAddress, opts =>
        // {
        //     opts.Property(x => x.Line1).HasColumnName("physical_address_line1");
        //     opts.Property(x => x.Line2).HasColumnName("physical_address_line2");
        //     opts.Property(x => x.City).HasColumnName("physical_address_city");
        //     opts.Property(x => x.State).HasColumnName("physical_address_state");
        //     opts.OwnsOne(x => x.PostalCode, o =>
        //         {
        //             o.Property(x => x.Value).HasColumnName("physical_address_postal_code");
        //         }).Navigation(x => x.PostalCode)
        //         .IsRequired();
        //     opts.Property(x => x.Country).HasColumnName("physical_address_country");
        // }).Navigation(x => x.PhysicalAddress)
        //     .IsRequired();
    }
}
