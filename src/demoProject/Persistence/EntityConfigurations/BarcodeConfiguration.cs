using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BarcodeConfiguration : IEntityTypeConfiguration<Barcode>
{
    public void Configure(EntityTypeBuilder<Barcode> builder)
    {
        builder.ToTable("Barcodes").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(b => b.BarcodeNumber).HasColumnName("BarcodeNumber").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        //builder.HasOne(b=>b.Product).WithOne(p=>p.Barcode).HasForeignKey<Product>(p=>p.BarcodeId);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}