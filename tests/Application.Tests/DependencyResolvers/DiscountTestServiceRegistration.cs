using Application.Features.Discounts.Commands.Create;
using Application.Features.Discounts.Commands.Delete;
using Application.Features.Discounts.Commands.Update;
using Application.Features.Discounts.Queries.GetById;
using Application.Features.Discounts.Queries.GetByName;
using Application.Features.Discounts.Queries.GetList;
using Application.Features.Discounts.Queries.GetListByDynamicDiscount;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class DiscountTestServiceRegistration
{
    public static void AddDiscountServices(this IServiceCollection services)
    {
        services.AddTransient<DiscountFakeData>();
        services.AddTransient<CreateDiscountCommand>();
        services.AddTransient<UpdateDiscountCommand>();
        services.AddTransient<DeleteDiscountCommand>();

        services.AddTransient<CreateDiscountCommandValidator>();
        services.AddTransient<UpdateDiscountCommandValidator>();
        services.AddTransient<DeleteDiscountCommandValidator>();

        services.AddTransient<GetByNameDiscountQuery>();
        services.AddTransient<GetByIdDiscountQuery>();
        services.AddTransient<GetListDiscountQuery>();
        services.AddTransient<GetListByDynamicDiscountQuery>();

        services.AddTransient<GetByNameDiscountQueryValidator>();
        services.AddTransient<GetByIdDiscountValidator>();
    }
}
