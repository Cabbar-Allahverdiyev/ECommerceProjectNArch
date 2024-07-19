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
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(p => p.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(p => p.SupplierId).HasColumnName("SupplierId").IsRequired();
        builder.Property(p => p.DiscountId).HasColumnName("DiscountId").IsRequired();
        builder.Property(p => p.ProductColorId).HasColumnName("ProductColorId").IsRequired();
       // builder.Property(p => p.ProductInventorId).HasColumnName("ProductInventorId").IsRequired();//InventorId edib yoxla
        //builder.Property(p => p.BarcodeId).HasColumnName("BarcodeId").IsRequired();
        builder.Property(p => p.UnitsOnOrder).HasColumnName("UnitsOnOrder");
        builder.Property(p => p.ReorderLevel).HasColumnName("ReorderLevel");
        builder.Property(p => p.PurchasePrice).HasColumnName("PurchasePrice").IsRequired();
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.QuantityPerUnit).HasColumnName("QuantityPerUnit");
        builder.Property(p => p.SKU).HasColumnName("SKU").IsRequired();
        builder.Property(p => p.Description).HasColumnName("Description");
        builder.Property(p => p.IsDiscontinued).HasColumnName("IsDiscontinued").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(c => c.Brand);
        builder.HasOne(c => c.Category);
        builder.HasOne(c => c.Supplier);
        builder.HasOne(c => c.Discount);
        builder.HasOne(c => c.ProductColor);
        builder.HasOne(c => c.ProductInventor).WithOne(i => i.Product).HasForeignKey<ProductInventor>(i => i.ProductId);
        builder.HasOne(c => c.Barcode).WithOne(b => b.Product).HasForeignKey<Barcode>(b => b.ProductId);

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}