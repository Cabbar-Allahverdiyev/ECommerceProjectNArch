using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductInventorConfiguration : IEntityTypeConfiguration<ProductInventor>
{
    public void Configure(EntityTypeBuilder<ProductInventor> builder)
    {
        builder.ToTable("ProductInventors").HasKey(pi => pi.Id);

        builder.Property(pi => pi.Id).HasColumnName("Id").IsRequired();
        builder.Property(pi => pi.Quantity).HasColumnName("Quantity");
        builder.Property(pi => pi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pi => pi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pi => pi.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(i => i.Product).WithOne(p=>p.Inventor);

        builder.HasQueryFilter(pi => !pi.DeletedDate.HasValue);
       // builder.HasData(getSeeds());
    }

    private IEnumerable<ProductInventor> getSeeds()
    {
        
        List<ProductInventor> data = new()
        {
            new(ProductInventorConfigIds[0],1),
            new(ProductInventorConfigIds[0],2),
            new(ProductInventorConfigIds[0],5),
            new(ProductInventorConfigIds[0],8),
          
        };
        return data;
    }

    public static List<Guid> ProductInventorConfigIds = new()
    {
        Guid.NewGuid(),
        Guid.NewGuid(),
        Guid.NewGuid(),
        Guid.NewGuid()
    };
}