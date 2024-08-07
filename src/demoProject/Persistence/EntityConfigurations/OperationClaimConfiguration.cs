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
       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.GetByNameCompany" });

       seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.GetListByDynamicCompany" });

       
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

       seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.GetListByDynamicCity" });

       
       #endregion
       
       
       #region Countries
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.GetByNameCountry" });

       seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.GetListByDynamicCountry" });

       
       #endregion
       
       
       #region Discounts
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Discounts.GetListByDynamicDiscount" });

       
       #endregion
       
       
       #region ProductBrands
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductBrands.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductBrands.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductBrands.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductBrands.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductBrands.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductBrands.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductBrands.GetByName" });

       
       #endregion
       
       
       #region ProductCategories
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.GetByNameProductCategory" });

       
       #endregion
       
       
       #region ProductInventors
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductInventors.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductInventors.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductInventors.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductInventors.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductInventors.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductInventors.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductInventors.GetByNameProductInventor" });

       
       #endregion
       
       
       #region Products
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Products.GetByNameProduct" });

       
       #endregion
       
       
       #region Suppliers
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.GetByUserIdSupplier" });

       seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.GetByCompanyIdSuppier" });

       
       #endregion
       
       
       #region ProductColors
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Delete" });
       
       #endregion
       
       
       #region ProductColors
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Delete" });
       
       #endregion
       
       
       #region Barcodes
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.Admin" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.Read" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.Write" });
       
       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.Add" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.Update" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.Delete" });
       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.GetByBarcodeNumber" });

       seeds.Add(new OperationClaim { Id = ++id, Name = "Barcodes.GetListByDynamicBarcode" });

       
       #endregion
       
        return seeds;
    }
}
