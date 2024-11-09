using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {

            builder.HasKey(pt => new { pt.ProductId, pt.TagId });

            builder.HasOne(pt => pt.Product)
                   .WithMany(p => p.Tags)
                   .HasForeignKey(pt => pt.ProductId)
                   .OnDelete(DeleteBehavior.Cascade); // Delete ProductTag if Product is deleted

            builder.HasOne(pt => pt.Tag)
                   .WithMany(t => t.ProductTags)
                   .HasForeignKey(pt => pt.TagId)
                   .OnDelete(DeleteBehavior.Cascade); // Delete ProductTag if Tag is deleted
        }
    }
}
