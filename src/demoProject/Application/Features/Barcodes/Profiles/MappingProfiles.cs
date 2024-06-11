using Application.Features.Barcodes.Commands.Create;
using Application.Features.Barcodes.Commands.Delete;
using Application.Features.Barcodes.Commands.Update;
using Application.Features.Barcodes.Queries.GetById;
using Application.Features.Barcodes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Barcodes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Barcode, CreateBarcodeCommand>().ReverseMap();
        CreateMap<Barcode, CreatedBarcodeResponse>().ReverseMap();
        CreateMap<Barcode, UpdateBarcodeCommand>().ReverseMap();
        CreateMap<Barcode, UpdatedBarcodeResponse>().ReverseMap();
        CreateMap<Barcode, DeleteBarcodeCommand>().ReverseMap();
        CreateMap<Barcode, DeletedBarcodeResponse>().ReverseMap();
        CreateMap<Barcode, GetByIdBarcodeResponse>().ReverseMap();
        CreateMap<Barcode, GetListBarcodeListItemDto>().ReverseMap();
        CreateMap<IPaginate<Barcode>, GetListResponse<GetListBarcodeListItemDto>>().ReverseMap();
    }
}