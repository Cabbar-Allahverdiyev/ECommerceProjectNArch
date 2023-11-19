using Application.Features.Suppliers.Commands.Create;
using Application.Features.Suppliers.Commands.Delete;
using Application.Features.Suppliers.Commands.Update;
using Application.Features.Suppliers.Queries.GetById;
using Application.Features.Suppliers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Application.Features.Suppliers.Dtos;
using Application.Features.Suppliers.Queries.GetByUserId;
using Application.Features.Suppliers.Queries.GetByCompanyId;

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

        CreateMap<User, GetUserInSupplierQueryDto>().ReverseMap();
        CreateMap<Company, GetCompanyInSupplierQueryDto>().ReverseMap();
        CreateMap<Product,GetProductsInSupplierQueryDto>().ReverseMap();

        CreateMap<Supplier, GetByIdSupplierResponse>()
            .ForMember(dest=>dest.User,act=>act.MapFrom(src=>src.User))
            .ForMember(dest=>dest.Company,act=>act.MapFrom(src=>src.Company))
            .ForMember(dest=>dest.Products,act=>act.MapFrom(src=>src.Products)).ReverseMap();

        CreateMap<Supplier, GetByUserIdSupplierResponse>()
           .ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
           .ForMember(dest => dest.Company, act => act.MapFrom(src => src.Company))
           .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products)).ReverseMap();

        CreateMap<Supplier, GetByCompanyIdSupplierResponse>()
           .ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
           .ForMember(dest => dest.Company, act => act.MapFrom(src => src.Company))
           .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products)).ReverseMap();

        CreateMap<Supplier, GetListSupplierListItemDto>()
            .ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
            .ForMember(dest => dest.Company, act => act.MapFrom(src => src.Company))
            .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products)).ReverseMap();

        CreateMap<IPaginate<Supplier>, GetListResponse<GetListSupplierListItemDto>>().ReverseMap();
    }
}