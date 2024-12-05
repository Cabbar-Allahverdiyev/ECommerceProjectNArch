using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShopConfiguration : IEntityTypeConfiguration<Shop>
{
    public void Configure(EntityTypeBuilder<Shop> builder)
    {
        builder.ToTable("Shops").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(s => s.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(s=>s.User);
        builder.HasOne(s=>s.Company);
        builder.HasMany(s=>s.Sellers);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private IEnumerable<Shop> getSeeds()
    {

        List<Shop> data = new()
        {
            new(ShopConfigIds[0],1,CompanyConfiguration.CompanyConfigIds[0]),
            new(ShopConfigIds[1],2,CompanyConfiguration.CompanyConfigIds[1])
        };
        return data;
    }

    public static List<Guid> ShopConfigIds = new() {
        Guid.NewGuid(),
        Guid.NewGuid()
    };
}