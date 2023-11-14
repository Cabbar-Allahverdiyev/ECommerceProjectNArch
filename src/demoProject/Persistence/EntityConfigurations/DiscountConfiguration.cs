using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discounts").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.DiscountPercent).HasColumnName("DiscountPercent").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d => d.Description).HasColumnName("Description");
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(d => d.Products);

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }

    private IEnumerable<Discount> getSeeds()
    {
        List<Discount> seeds = new List<Discount>() {
        new(DiscountConfigIds[0],15,"Ucuz endirim"),
        new(DiscountConfigIds[1],25, "Ela endirim")
        };
        return seeds.ToArray();
    }

    public static List<Guid> DiscountConfigIds = new() {
        Guid.NewGuid(),
        Guid.NewGuid()
     };
}