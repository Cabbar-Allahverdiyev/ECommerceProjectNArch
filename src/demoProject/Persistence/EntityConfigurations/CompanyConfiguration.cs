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

        //builder.HasData(new Company[] {
        //new(){Id=Guid.NewGuid(),Name="AzerAgroMMC",AddressLine1="S.Esgerova ev 8",CityId=}
        //});
    }
}