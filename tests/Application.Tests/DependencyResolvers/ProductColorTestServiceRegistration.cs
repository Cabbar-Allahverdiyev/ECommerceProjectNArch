using Application.Features.ProductColors.Commands.Create;
using Application.Features.ProductColors.Commands.Delete;
using Application.Features.ProductColors.Commands.Update;
using Application.Features.ProductColors.Queries.GetById;
using Application.Features.ProductColors.Queries.GetByName;
using Application.Features.ProductColors.Queries.GetList;
using Application.Features.ProductColors.Queries.GetListByDynamicProductColor;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class ProductColorTestServiceRegistration
{
    public static void AddProductColorServices(this IServiceCollection services)
    {
        services.AddTransient<ProductColorFakeData>();

        services.AddTransient<CreateProductColorCommand>();
        services.AddTransient<UpdateProductColorCommand>();
        services.AddTransient<DeleteProductColorCommand>();

        services.AddTransient<CreateProductColorCommandValidator>();
        services.AddTransient<UpdateProductColorCommandValidator>();
        services.AddTransient<DeleteProductColorCommandValidator>();

        services.AddTransient<GetByNameProductColorQuery>();
        services.AddTransient<GetByIdProductColorQuery>();
        services.AddTransient<GetListProductColorQuery>();
        services.AddTransient<GetListByDynamicProductColorQuery>();

        services.AddTransient<GetByNameProductColorQueryValidator>();
        services.AddTransient<GetByIdProductColorQueryValidator>();


    }
}
