using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products"); 

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(250) 
                .IsRequired(); 

            builder.Property(p => p.Description)
                .HasMaxLength(2000);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(p => p.Type)
                .HasMaxLength(250);

            builder.Property(p => p.Brand)
                .HasMaxLength(250);

            builder.Property(p => p.PictureUrl)
                .HasMaxLength(500);
        }
    }
}
