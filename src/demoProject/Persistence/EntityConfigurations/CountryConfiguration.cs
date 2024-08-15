using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.BarcodeCode).HasColumnName("BarcodeCode").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasMany(c => c.Cities);

        builder.HasData(getSeeds());
    }

    private IEnumerable<Country> getSeeds()
    {
        List<Country> seeds = new List<Country>() {
        new(CountryConfigIds[0],"Azerbaijan","476"),
        new(CountryConfigIds[1],"Turkey","869")
        };
        return seeds.ToArray();
    }

    public static List<Guid> CountryConfigIds = new() {
        Guid.NewGuid(),
        Guid.NewGuid()
     };
}