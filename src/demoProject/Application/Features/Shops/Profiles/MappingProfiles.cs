using Application.Features.Shops.Commands.Create;
using Application.Features.Shops.Commands.Delete;
using Application.Features.Shops.Commands.Update;
using Application.Features.Shops.Queries.GetById;
using Application.Features.Shops.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Shops.Queries.GetListByCompanyName;
using Application.Features.Shops.Queries.GetByUserId;
using Application.Features.Shops.Queries.GetByCompanyId;

namespace Application.Features.Shops.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Shop, CreateShopCommand>().ReverseMap();
        CreateMap<Shop, CreatedShopResponse>().ReverseMap();
        CreateMap<Shop, UpdateShopCommand>().ReverseMap();
        CreateMap<Shop, UpdatedShopResponse>().ReverseMap();
        CreateMap<Shop, DeleteShopCommand>().ReverseMap();
        CreateMap<Shop, DeletedShopResponse>().ReverseMap();
        CreateMap<Shop, GetByIdShopResponse>().ReverseMap(); 
        CreateMap<Shop, GetByUserIdShopResponse>().ReverseMap(); 
        CreateMap<Shop, GetByCompanyIdShopResponse>().ReverseMap(); 

        CreateMap<Shop, GetListShopListItemDto>().ReverseMap();
        CreateMap<Shop, GetListByCompanyNameShopListItemDto>().ReverseMap();
        CreateMap<IPaginate<Shop>, GetListResponse<GetListShopListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Shop>, GetListResponse<GetListByCompanyNameShopListItemDto>>().ReverseMap();
    }
}