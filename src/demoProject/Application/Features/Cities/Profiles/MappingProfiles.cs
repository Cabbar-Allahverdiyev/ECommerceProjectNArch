using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Cities.Queries.GetByName;
using Application.Features.Cities.Dtos;

namespace Application.Features.Cities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CreateCityCommand>().ReverseMap();
        CreateMap<City, CreatedCityResponse>().ReverseMap();
        CreateMap<City, UpdateCityCommand>().ReverseMap();
        CreateMap<City, UpdatedCityResponse>().ReverseMap();
        CreateMap<City, DeleteCityCommand>().ReverseMap();
        CreateMap<City, DeletedCityResponse>().ReverseMap();

        CreateMap<Company, GetCompanyInCityQueryDto>().ReverseMap();
        CreateMap<Country, GetCountryInCityQueryDto>().ReverseMap();

        CreateMap<City, GetByIdCityResponse>().ReverseMap();
        CreateMap<City, GetByIdCityResponse>().ForMember(dest=>dest.Companies,opt=>opt.MapFrom(src=>src.Companies)).ReverseMap();
        CreateMap<City, GetByIdCityResponse>().ForMember(dest=>dest.Country,opt=>opt.MapFrom(src=>src.Country)).ReverseMap();

        CreateMap<City, GetByNameCityResponse>().ReverseMap();
        CreateMap<City, GetByNameCityResponse>().ForMember(dest => dest.Companies, opt => opt.MapFrom(src => src.Companies)).ReverseMap();
        CreateMap<City, GetByNameCityResponse>().ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country)).ReverseMap();

        CreateMap<City, GetListCityListItemDto>().ReverseMap();
        CreateMap<City, GetListCityListItemDto>().ForMember(dest => dest.Companies, opt => opt.MapFrom(src => src.Companies)).ReverseMap();
        CreateMap<City, GetListCityListItemDto>().ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country)).ReverseMap();
        CreateMap<IPaginate<City>, GetListResponse<GetListCityListItemDto>>().ReverseMap();
    }
}