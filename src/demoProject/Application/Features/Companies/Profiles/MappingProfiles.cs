using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Queries.GetByName;

namespace Application.Features.Companies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        CreateMap<Company, CreatedCompanyResponse>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
        CreateMap<Company, UpdatedCompanyResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
        CreateMap<Company, DeletedCompanyResponse>().ReverseMap();

        CreateMap<City, GetCityInCompanyDto>().ReverseMap();
        CreateMap<Supplier, GetSuppliersInCompanyQueryDto>().ReverseMap();

        CreateMap<Company, GetByIdCompanyResponse>()
            .ForMember(dest=>dest.City, opt=>opt.MapFrom(src=>src.City))
            .ForMember(dest=>dest.Suppliers, opt=>opt.MapFrom(src=>src.Suppliers))
            .ReverseMap();
        CreateMap<Company, GetByNameCompanyResponse>()
            .ForMember(dest=>dest.City, opt=>opt.MapFrom(src=>src.City))
            .ForMember(dest => dest.Suppliers, opt => opt.MapFrom(src => src.Suppliers))
            .ReverseMap();

        CreateMap<Company, GetListCompanyListItemDto>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Suppliers, opt => opt.MapFrom(src => src.Suppliers))
            .ReverseMap();
        CreateMap<IPaginate<Company>, GetListResponse<GetListCompanyListItemDto>>().ReverseMap();
    }
}