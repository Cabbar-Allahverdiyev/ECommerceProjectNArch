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
        Guid barcodeId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
        Guid barcodeId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");

        Guid productId1= Guid.Parse("11111111-1111-1111-1111-111111111111");
        Guid productId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");

        builder.HasData(getSeeds());

    }

    private IEnumerable<Barcode> getSeeds()
    {
        IList<Barcode> seeds = new Barcode[]
        {
            new(BarcodeConfigids[0],ProductConfiguration.ProductConfigIds[0],"6281020104549"),
            new(BarcodeConfigids[1],ProductConfiguration.ProductConfigIds[1],"5901234123457"),
        };
        return seeds;
    }

    public static List<Guid> BarcodeConfigids = new()
    {
          Guid.NewGuid(),  Guid.NewGuid(),
    };
}