using Application.Features.Barcodes.Commands.Create;
using Application.Features.Barcodes.Commands.Delete;
using Application.Features.Barcodes.Commands.Update;
using Application.Features.Barcodes.Queries.GetByBarcodeNumber;
using Application.Features.Barcodes.Queries.GetById;
using Application.Features.Barcodes.Queries.GetList;
using Application.Features.Barcodes.Queries.GetListByDynamicBarcode;
using Application.Tests.Mocks.FakeData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.DependencyResolvers;
public static class BarcodeTestServiceRegistration
{
    public static void AddBarcodeServices(this IServiceCollection services)
    {
        services.AddTransient<BarcodeFakeData>();

        services.AddTransient<CreateBarcodeCommand>();
        services.AddTransient<UpdateBarcodeCommand>();
        services.AddTransient<DeleteBarcodeCommand>();

        services.AddTransient<CreateBarcodeCommandValidator>();
        services.AddTransient<UpdateBarcodeCommandValidator>();
        services.AddTransient<DeleteBarcodeCommandValidator>();

        services.AddTransient<GetByBarcodeNumberQuery>();
        services.AddTransient<GetByIdBarcodeQuery>();
        services.AddTransient<GetListBarcodeQuery>();
        services.AddTransient<GetListByDynamicBarcodeQuery>();

        services.AddTransient<GetByBarcodeNumberQueryValidator>();
        services.AddTransient<GetByIdBarcodeQueryValidator>();


    }
}
