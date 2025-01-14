using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetById;
using Application.Features.Sellers.Queries.GetByShopIdSeller;
using Application.Features.Sellers.Queries.GetByUserIdSeller;
using Application.Features.Sellers.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class SellerTestServiceRegistration
{
    public static void AddSellerServices(this IServiceCollection services)
    {
        services.AddTransient<SellerFakeData>();

        services.AddTransient<CreateSellerCommand>();
        services.AddTransient<UpdateSellerCommand>();
        services.AddTransient<DeleteSellerCommand>();

        services.AddTransient<CreateSellerCommandValidator>();
        services.AddTransient<UpdateSellerCommandValidator>();
        services.AddTransient<DeleteSellerCommandValidator>();

        services.AddTransient<GetByIdSellerQuery>();
        services.AddTransient<GetByShopIdSellerQuery>();
        services.AddTransient<GetByUserIdSellerQuery>();
        services.AddTransient<GetListSellerQuery>();
        //services.AddTransient<GetListByDynamicSellerQuery>();

        services.AddTransient<GetByShopIdSellerQueryValidator>();
        services.AddTransient<GetByUserIdSellerQueryValidator>();
        services.AddTransient<GetByIdSellerQueryValidator>();


    }
}
