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
        CreateMap<Discount, GetByIdDiscountResponse>().ReverseMap();
        CreateMap<Discount, GetByNameDiscountResponse>().ReverseMap();
        CreateMap<Discount, GetListDiscountListItemDto>().ReverseMap();
        CreateMap<IPaginate<Discount>, GetListResponse<GetListDiscountListItemDto>>().ReverseMap();
    }
}