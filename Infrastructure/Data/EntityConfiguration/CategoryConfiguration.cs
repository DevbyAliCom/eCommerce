using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            // Self-referencing relationship for hierarchical levels
            builder.HasOne(c => c.Parent)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Description).HasMaxLength(2000);

        }
    }
}
