using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
{
    public void Configure(EntityTypeBuilder<ProductColor> builder)
    {
        builder.ToTable("ProductColors").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.Name).HasColumnName("Name").IsRequired();
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(c => c.Products);

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }
    private IEnumerable<ProductColor> getSeeds()
    {

        List<ProductColor> data = new()
        {
            new(ProductColorConfigIds[0],"Red"),
            new(ProductColorConfigIds[1],"Blue"),
            new(ProductColorConfigIds[2],"Orange"),
        };
        return data;
    }

    public static List<Guid> ProductColorConfigIds = new() {
        Guid.NewGuid(),
        Guid.NewGuid(),
        Guid.NewGuid()
     };
}