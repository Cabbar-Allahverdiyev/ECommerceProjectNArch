using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Queries.GetByName;
using Application.Features.Companies.Queries.GetList;
using Application.Features.Companies.Queries.GetListByDynamicCompany;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class CompanyTestServiceRegistration
{
    public static void AddCompanyServices(this IServiceCollection services)
    {
        services.AddTransient<CompanyFakeData>();

        services.AddTransient<CreateCompanyCommand>();
        services.AddTransient<UpdateCompanyCommand>();
        services.AddTransient<DeleteCompanyCommand>();

        services.AddTransient<CreateCompanyCommandValidator>();
        services.AddTransient<UpdateCompanyCommandValidator>();
        services.AddTransient<DeleteCompanyCommandValidator>();

        services.AddTransient<GetByNameCompanyQuery>();
        services.AddTransient<GetByIdCompanyQuery>();
        services.AddTransient<GetListCompanyQuery>();
        services.AddTransient<GetListByDynamicCompanyQuery>();

        services.AddTransient<GetByNameCompanyQueryValidator>();
        services.AddTransient<GetByIdCompanyQueryValidator>();


    }
}
