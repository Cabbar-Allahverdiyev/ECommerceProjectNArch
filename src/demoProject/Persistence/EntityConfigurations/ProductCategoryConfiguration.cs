﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.Name).HasColumnName("Name").IsRequired();
        builder.Property(pc => pc.ParentId).HasColumnName("ParentId");
        builder.Property(pc => pc.Description).HasColumnName("Description");
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(c => c.Parent);
        builder.HasMany(c=>c.Products);

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }

    private IEnumerable<ProductCategory> getSeeds()
    {
       
        List<ProductCategory> data = new()
        {
            new(ProductCategoryConfigIds[0],"Elektronika","rahat dasimaq"),
            new(ProductCategoryConfigIds[1],"Telefon","asan əlaqə"),
            new(ProductCategoryConfigIds[2],ProductCategoryConfigIds[0],"Telefon","asan əlaqə"),
        };
        return data;
    }

    public static List<Guid> ProductCategoryConfigIds = new() {
        Guid.NewGuid(),
        Guid.NewGuid(),
        Guid.NewGuid()
     };
}