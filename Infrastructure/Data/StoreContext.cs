﻿using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data.EntityConfiguration;


namespace Infrastructure.Data
{
    public class StoreContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
           
        }
    }
}