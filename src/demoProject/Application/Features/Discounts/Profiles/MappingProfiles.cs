using Application.Features.Discounts.Commands.Create;
using Application.Features.Discounts.Commands.Delete;
using Application.Features.Discounts.Commands.Update;
using Application.Features.Discounts.Queries.GetById;
using Application.Features.Discounts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Discounts.Queries.GetByName;
using Application.Features.Discounts.Dtos;
using Application.Features.Discounts.Queries.GetListByDynamicDiscount;

namespace Application.Features.Discounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Discount, CreateDiscountCommand>().ReverseMap();
        CreateMap<Discount, CreatedDiscountResponse>().ReverseMap();
        CreateMap<Discount, UpdateDiscountCommand>().ReverseMap();
        CreateMap<Discount, UpdatedDiscountResponse>().ReverseMap();
        CreateMap<Discount, DeleteDiscountCommand>().ReverseMap();
        CreateMap<Discount, DeletedDiscountResponse>().ReverseMap();

        CreateMap<Product, GetProductsInDiscountDto>().ReverseMap();
        
        CreateMap<Discount, GetByIdDiscountResponse>().ForMember(dest=>dest.Products,act=>act.MapFrom(src=>src.Products)).ReverseMap();
        CreateMap<Discount, GetByNameDiscountQueryResponse>().ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<Discount, GetListDiscountListItemDto>().ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<IPaginate<Discount>, GetListResponse<GetListDiscountListItemDto>>().ReverseMap();
        
        CreateMap<Discount, GetListByDynamicDiscountItemDto>().ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<IPaginate<Discount>, GetListResponse<GetListByDynamicDiscountItemDto>>().ReverseMap();
    }
}