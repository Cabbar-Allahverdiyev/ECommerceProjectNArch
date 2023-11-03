using Application.Features.Suppliers.Commands.Create;
using Application.Features.Suppliers.Commands.Delete;
using Application.Features.Suppliers.Commands.Update;
using Application.Features.Suppliers.Queries.GetById;
using Application.Features.Suppliers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Suppliers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Supplier, CreateSupplierCommand>().ReverseMap();
        CreateMap<Supplier, CreatedSupplierResponse>().ReverseMap();
        CreateMap<Supplier, UpdateSupplierCommand>().ReverseMap();
        CreateMap<Supplier, UpdatedSupplierResponse>().ReverseMap();
        CreateMap<Supplier, DeleteSupplierCommand>().ReverseMap();
        CreateMap<Supplier, DeletedSupplierResponse>().ReverseMap();
        CreateMap<Supplier, GetByIdSupplierResponse>().ReverseMap();
        CreateMap<Supplier, GetListSupplierListItemDto>().ReverseMap();
        CreateMap<IPaginate<Supplier>, GetListResponse<GetListSupplierListItemDto>>().ReverseMap();
    }
}