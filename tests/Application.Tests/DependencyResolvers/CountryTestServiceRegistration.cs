using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class CountryTestServiceRegistration
{
    public static void AddCountryServices(this IServiceCollection services)
    {
        services.AddTransient<CountryFakeData>();
        services.AddTransient<CreateCountryCommand>();
        services.AddTransient<UpdateCountryCommand>();
        services.AddTransient<DeleteCountryCommand>();

        services.AddTransient<CreateCountryCommandValidator>();
        services.AddTransient<UpdateCountryCommandValidator>();
        services.AddTransient<DeleteCountryCommandValidator>();
    }
}
