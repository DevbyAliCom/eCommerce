using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.EntityConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
