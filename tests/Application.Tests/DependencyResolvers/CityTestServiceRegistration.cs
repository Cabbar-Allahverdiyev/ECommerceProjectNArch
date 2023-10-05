using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class CityTestServiceRegistration
{
    public static void AddCityServices(this IServiceCollection services)
    {
        services.AddTransient<CityFakeData>();
        services.AddTransient<CreateCityCommand>();
        services.AddTransient<UpdateCityCommand>();
        services.AddTransient<DeleteCityCommand>();

        services.AddTransient<CreateCityCommandValidator>();
        services.AddTransient<UpdateCityCommandValidator>();
        services.AddTransient<DeleteCityCommandValidator>();
    }
}
