using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Commands.Delete;
using Application.Features.ProductCategories.Commands.Update;
using Application.Features.ProductCategories.Queries.GetById;
using Application.Features.ProductCategories.Queries.GetByName;
using Application.Features.ProductCategories.Queries.GetList;
using Application.Features.ProductCategories.Queries.GetListByDynamicProductCategory;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class ProductCategoryTestServiceRegistration
{
    public static void AddProductCategoryServices(this IServiceCollection services)
    {
        services.AddTransient<ProductCategoryFakeData>();
        services.AddTransient<CreateProductCategoryCommand>();
        services.AddTransient<UpdateProductCategoryCommand>();
        services.AddTransient<DeleteProductCategoryCommand>();

        services.AddTransient<CreateProductCategoryCommandValidator>();
        services.AddTransient<UpdateProductCategoryCommandValidator>();
        services.AddTransient<DeleteProductCategoryCommandValidator>();

        services.AddTransient<GetByNameProductCategoryQuery>();
        services.AddTransient<GetByIdProductCategoryQuery>();
        services.AddTransient<GetListProductCategoryQuery>();
        services.AddTransient<GetListByDynamicProductCategoryQuery>();

        services.AddTransient<GetByNameProductCategoryQueryValidator>();
        services.AddTransient<GetByIdProductCategoryQueryValidator>();
    }
}
