using Application.Features.ProductInventors.Commands.Create;
using Application.Features.ProductInventors.Commands.Delete;
using Application.Features.ProductInventors.Commands.Update;
using Application.Features.ProductInventors.Queries.GetById;
using Application.Features.ProductInventors.Queries.GetList;
using Application.Features.ProductInventors.Queries.GetListByDynamicProductInventor;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class ProductInventorTestServiceRegistration
{
    public static void AddProductInventorServices(this IServiceCollection services)
    {
        services.AddTransient<ProductInventorFakeData>();
        services.AddTransient<CreateProductInventorCommand>();
        services.AddTransient<UpdateProductInventorCommand>();
        services.AddTransient<DeleteProductInventorCommand>();

        services.AddTransient<CreateProductInventorCommandValidator>();
        services.AddTransient<UpdateProductInventorCommandValidator>();
        services.AddTransient<DeleteProductInventorCommandValidator>();

        services.AddTransient<GetByIdProductInventorQuery>();
        services.AddTransient<GetListProductInventorQuery>();
        services.AddTransient<GetListByDynamicProductInventorQuery>();

        services.AddTransient<GetByIdProductInventorQueryValidator>();
    }
}
