using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.SupplierId).HasColumnName("SupplierId");
        builder.Property(p => p.DiscountId).HasColumnName("DiscountId");
        builder.Property(p => p.InventorId).HasColumnName("InventorId");
        builder.Property(p => p.UnitsOnOrder).HasColumnName("UnitsOnOrder");
        builder.Property(p => p.ReorderLevel).HasColumnName("ReorderLevel");
        builder.Property(p => p.PurchasePrice).HasColumnName("PurchasePrice");
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.QuantityPerUnit).HasColumnName("QuantityPerUnit");
        builder.Property(p => p.SKU).HasColumnName("SKU");
        builder.Property(p => p.Description).HasColumnName("Description");
        builder.Property(p => p.IsDiscontinued).HasColumnName("IsDiscontinued");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}