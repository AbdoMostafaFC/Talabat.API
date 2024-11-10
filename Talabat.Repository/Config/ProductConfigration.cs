using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Config
{
    internal class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(80);
            builder.Property(p => p.PictureUrl).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasPrecision(18,2);
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p=>p.CategoryId);
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p=>p.BrandId);
        }
    }
}
