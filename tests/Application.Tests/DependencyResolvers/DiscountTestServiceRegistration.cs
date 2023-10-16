using Application.Features.Discounts.Commands.Create;
using Application.Features.Discounts.Commands.Delete;
using Application.Features.Discounts.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class DiscountTestServiceRegistration
{
    public static void AddDiscountServices(IServiceCollection services)
    {
        services.AddTransient<DiscountFakeData>();
        services.AddTransient<CreateDiscountCommand>();
        services.AddTransient<UpdateDiscountCommand>();
        services.AddTransient<DeleteDiscountCommand>();

        services.AddTransient<CreateDiscountCommandValidator>();
        services.AddTransient<UpdateDiscountCommandValidator>();
        services.AddTransient<DeleteDiscountCommandValidator>();
    }
}
