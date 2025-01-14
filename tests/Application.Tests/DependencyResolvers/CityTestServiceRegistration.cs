using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetByName;
using Application.Features.Cities.Queries.GetList;
using Application.Features.Cities.Queries.GetListByDynamicCity;
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

        services.AddTransient<GetByIdCityQuery>();
        services.AddTransient<GetByNameCityQuery>();
        services.AddTransient<GetListCityQuery>();
        services.AddTransient<GetListByDynamicCityQuery>();

        services.AddTransient<GetByIdCityQueryValidator>();
        services.AddTransient<GetByNameCityQueryValidator>();
    }
}
