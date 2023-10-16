using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
       
        
       
       #region Companies
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Delete" });
       
       #endregion
       
       
       #region Cities
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.GetByNameCityQuery" });

       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.GetByNameCity" });

       
       #endregion
       
       
       #region Countries
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Delete" });
       
       #endregion
       
       
       #region Discounts
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Delete" });
       
       #endregion
       
        return seeds;
    }
}
