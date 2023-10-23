using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.ToTable("ProductBrands").HasKey(pb => pb.Id);

        builder.Property(pb => pb.Id).HasColumnName("Id").IsRequired();
        builder.Property(pb => pb.Name).HasColumnName("Name");
        builder.Property(pb => pb.Description).HasColumnName("Description");
        builder.Property(pb => pb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pb => pb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pb => pb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pb => !pb.DeletedDate.HasValue);
    }
}