using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(s => s.Description).HasColumnName("Description");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(s=>s.User);
        builder.HasOne(s=>s.Company);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }

    private IEnumerable<Supplier> getSeeds()
    {

        List<Supplier> data = new()
        {
            new(SupplierConfigIds[0],CompanyConfiguration.CompanyConfigIds[0],1,"stajci satici"),
            //new(Guid.NewGuid(),"Telefon",id,"asan əlaqə"),
        };
        return data;
    }

    public static List<Guid> SupplierConfigIds = new()
    {
        Guid.NewGuid(),
    };
}