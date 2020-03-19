using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.SupplierName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(s => s.SupplierName).IsUnique();
            builder.Property(s => s.IsDeleted).HasDefaultValue(false);
        }
    }
}
