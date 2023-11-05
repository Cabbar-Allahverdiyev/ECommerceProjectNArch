using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CountryId).HasColumnName("CountryId").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(c => c.Companies);
        builder.HasOne(c => c.Country);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(new City[] {
        new(CityConfigIds[0],"Baku",CountryConfiguration.CountryConfigIds[0],DateTime.UtcNow),
        new(CityConfigIds[1],"Yevlakh",CountryConfiguration.CountryConfigIds[1],DateTime.UtcNow)
        });
    }

    public static List<Guid> CityConfigIds = new() {
        Guid.NewGuid(),
        Guid.NewGuid()
    };
}