using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class MakerConfiguration : IEntityTypeConfiguration<Maker>
    {
        public void Configure(EntityTypeBuilder<Maker> builder)
        {
            builder.Property(m => m.MakerName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(m => m.MakerName).IsUnique();
            builder.Property(m => m.IsDeleted).HasDefaultValue(false);
        }
    }
}
