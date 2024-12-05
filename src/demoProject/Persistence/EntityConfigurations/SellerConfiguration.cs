using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(s => s.ShopId).HasColumnName("ShopId").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(s => s.User);
        builder.HasOne(s => s.Shop)
            .WithMany(sh=>sh.Sellers)
            .HasForeignKey(s=>s.ShopId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private IEnumerable<Seller> getSeeds()
    {
        List<Seller> data = new()
        {
            new(SellerConfigIds[0],1,ShopConfiguration.ShopConfigIds[0]),
            new(SellerConfigIds[1],2,ShopConfiguration.ShopConfigIds[1])
        };

        return data;
    }

    public static List<Guid> SellerConfigIds = new() {
        Guid.NewGuid(),
        Guid.NewGuid()
    };

}