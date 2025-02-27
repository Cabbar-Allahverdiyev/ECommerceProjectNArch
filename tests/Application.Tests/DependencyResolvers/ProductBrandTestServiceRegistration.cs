﻿using Application.Features.ProductBrands.Commands.Create;
using Application.Features.ProductBrands.Commands.Delete;
using Application.Features.ProductBrands.Commands.Update;
using Application.Features.ProductBrands.Queries.GetById;
using Application.Features.ProductBrands.Queries.GetByName;
using Application.Features.ProductBrands.Queries.GetList;
using Application.Features.ProductBrands.Queries.GetListByDynamicProductBrand;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class ProductBrandTestServiceRegistration
{
    public static void AddProductBrandServices(this IServiceCollection services)
    {
        services.AddTransient<ProductBrandFakeData>();
        services.AddTransient<CreateProductBrandCommand>();
        services.AddTransient<UpdateProductBrandCommand>();
        services.AddTransient<DeleteProductBrandCommand>();

        services.AddTransient<CreateProductBrandCommandValidator>();
        services.AddTransient<UpdateProductBrandCommandValidator>();
        services.AddTransient<DeleteProductBrandCommandValidator>();

        services.AddTransient<GetByNameProductBrandQuery>();
        services.AddTransient<GetByIdProductBrandQuery>();
        services.AddTransient<GetListProductBrandQuery>();
        services.AddTransient<GetListByDynamicProductBrandQuery>();

        services.AddTransient<GetByNameProductBrandQueryValidator>();
        services.AddTransient<GetByIdProductBrandValidator>();
    }
}
