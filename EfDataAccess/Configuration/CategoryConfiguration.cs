using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(c => c.CategoryName).IsUnique();
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        }
    }
}
