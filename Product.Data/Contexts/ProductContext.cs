using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Contexts
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product.Core.Entities.Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            
        }


    }
}
