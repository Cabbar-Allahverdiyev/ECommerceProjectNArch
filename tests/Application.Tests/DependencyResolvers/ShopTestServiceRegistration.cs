using Application.Features.Shops.Commands.Create;
using Application.Features.Shops.Commands.Delete;
using Application.Features.Shops.Commands.Update;
using Application.Features.Shops.Queries.GetByCompanyId;
using Application.Features.Shops.Queries.GetById;
using Application.Features.Shops.Queries.GetByUserId;
using Application.Features.Shops.Queries.GetList;
using Application.Features.Shops.Queries.GetListByCompanyName;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class ShopTestServiceRegistration
{
    public static void AddShopServices(this IServiceCollection services)
    {
        services.AddTransient<ShopFakeData>();

        services.AddTransient<CreateShopCommand>();
        services.AddTransient<UpdateShopCommand>();
        services.AddTransient<DeleteShopCommand>();

        services.AddTransient<CreateShopCommandValidator>();
        services.AddTransient<UpdateShopCommandValidator>();
        services.AddTransient<DeleteShopCommandValidator>();

        services.AddTransient<GetByIdShopQuery>();
        services.AddTransient<GetByCompanyIdShopQuery>();
        services.AddTransient<GetByUserIdShopQuery>();
        services.AddTransient<GetListByCompanyNameShopQuery>();
        services.AddTransient<GetListShopQuery>();
        //services.AddTransient<GetListByDynamicShopQuery>();

        services.AddTransient<GetByIdShopQueryValidator>();
        services.AddTransient<GetByCompanyIdShopQueryValidator>();
        services.AddTransient<GetByUserIdShopQueryValidator>();
        services.AddTransient<GetListByCompanyNameShopQueryValidator>();


    }
}
