using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data.EntityConfiguration;
using System;


namespace Infrastructure.Data
{
    public class StoreContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
            base.OnModelCreating(modelBuilder);


        }
    }
}
