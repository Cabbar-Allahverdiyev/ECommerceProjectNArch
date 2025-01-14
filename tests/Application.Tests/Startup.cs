using Application.Tests.DependencyResolvers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddUsersServices();
        services.AddBarcodeServices();
        services.AddCityServices();
        services.AddCompanyServices();
        services.AddCountryServices();
        services.AddDiscountServices();
        services.AddProductServices();
        services.AddProductBrandServices();
        services.AddProductCategoryServices();
        services.AddProductColorServices();
        services.AddProductInventorServices();
        services.AddSellerServices();
        services.AddShopServices();
        services.AddSupplierServices();
    }
}
