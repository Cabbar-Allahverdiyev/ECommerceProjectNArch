using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetByName;
using Application.Features.Products.Queries.GetList;
using Application.Features.Products.Queries.GetListByDynamicProduct;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class ProductTestServiceRegistration
{
    public static void AddProductServices(this IServiceCollection services)
    {
        services.AddTransient<ProductFakeData>();

        services.AddTransient<CreateProductCommand>();
        services.AddTransient<UpdateProductCommand>();
        services.AddTransient<DeleteProductCommand>();

        services.AddTransient<CreateProductCommandValidator>();
        services.AddTransient<UpdateProductCommandValidator>();
        services.AddTransient<DeleteProductCommandValidator>();

        services.AddTransient<GetByNameProductQuery>();
        services.AddTransient<GetByIdProductQuery>();
        services.AddTransient<GetListProductQuery>();
        services.AddTransient<GetListByDynamicProductQuery>();

        services.AddTransient<GetByNameProductQueryValidator>();
        services.AddTransient<GetByIdProductQueryValidator>();


    }
}
