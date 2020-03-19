using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(300);
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(p => p.ProductName).IsUnique();
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}
