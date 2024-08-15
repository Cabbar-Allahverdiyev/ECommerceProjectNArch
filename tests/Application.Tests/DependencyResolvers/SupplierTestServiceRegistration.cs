using Application.Features.Suppliers.Commands.Create;
using Application.Features.Suppliers.Commands.Delete;
using Application.Features.Suppliers.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class SupplierTestServiceRegistration
{
    public static void AddSupplierServices(this IServiceCollection services)
    {
        services.AddTransient<SupplierFakeData>();
        services.AddTransient<CreateSupplierCommand>();
        services.AddTransient<UpdateSupplierCommand>();
        services.AddTransient<DeleteSupplierCommand>();

        services.AddTransient<CreateSupplierCommandValidator>();
        services.AddTransient<UpdateSupplierCommandValidator>();
        services.AddTransient<DeleteSupplierCommandValidator>();
    }
}
