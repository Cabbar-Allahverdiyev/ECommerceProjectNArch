using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using Application.Features.Countries.Queries.GetById;
using Application.Features.Countries.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Countries.Dtos;
using Application.Features.Countries.Queries.GetByName;
using Application.Features.Countries.Queries.GetListByDynamicCountry;

namespace Application.Features.Countries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, CreatedCountryResponse>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, UpdatedCountryResponse>().ReverseMap();
        CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        CreateMap<Country, DeletedCountryResponse>().ReverseMap();

        CreateMap<City, GetCityInCountryDto>().ReverseMap();

        CreateMap<Country, GetByIdCountryResponse>().ForMember(dest=>dest.Cities,act=>act.MapFrom(c=>c.Cities)).ReverseMap();
        CreateMap<Country, GetByNameCountryResponse>().ForMember(dest=>dest.Cities,act=>act.MapFrom(c=>c.Cities)).ReverseMap();
        CreateMap<Country, GetListCountryListItemDto>().ForMember(dest => dest.Cities, act => act.MapFrom(c => c.Cities)).ReverseMap();
        CreateMap<IPaginate<Country>, GetListResponse<GetListCountryListItemDto>>().ReverseMap();

        CreateMap<Country, GetListByDynamicCountryItemDto>().ForMember(dest => dest.Cities, act => act.MapFrom(c => c.Cities)).ReverseMap();
        CreateMap<IPaginate<Country>, GetListResponse<GetListByDynamicCountryItemDto>>().ReverseMap();
    }
}