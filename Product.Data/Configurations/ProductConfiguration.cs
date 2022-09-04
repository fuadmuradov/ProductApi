using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Configurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product.Core.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Product.Core.Entities.Product> builder)
        {
            builder.Property(x => x.ProductName).IsRequired(true).HasMaxLength(150);
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.ProductCategoryId).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.State).HasDefaultValue(false);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
