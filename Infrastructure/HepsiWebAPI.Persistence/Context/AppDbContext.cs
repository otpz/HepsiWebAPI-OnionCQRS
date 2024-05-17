﻿using HepsiWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HepsiWebAPI.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){}

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
