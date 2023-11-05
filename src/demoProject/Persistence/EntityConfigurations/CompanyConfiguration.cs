using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired(); 
        builder.Property(c => c.AddressLine1).HasColumnName("AddressLine1");
        builder.Property(c => c.AddressLine2).HasColumnName("AddressLine2");
        builder.Property(c => c.CityId).HasColumnName("CityId");
        builder.Property(c => c.Email).HasColumnName("Email");
        builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(c => c.City);

        builder.HasData(getSeeds());
    }

    private IEnumerable<Company> getSeeds()
    {
       
        List<Company> data = new()
        {

            new(Guid.NewGuid(),"ABC","yyyyy","aaaa",CityConfiguration.CityConfigIds[0],"aaa@aaa.com","0554696363"),
            new(Guid.NewGuid(),"Telefon","aaaaaa","aaaaaa",CityConfiguration.CityConfigIds[1],"avd@ads.com","0554446655"),
        };
        return data;
    }
}