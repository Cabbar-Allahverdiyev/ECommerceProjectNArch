using Application.Features.ProductColors.Commands.Create;
using Application.Features.ProductColors.Commands.Delete;
using Application.Features.ProductColors.Commands.Update;
using Application.Features.ProductColors.Queries.GetById;
using Application.Features.ProductColors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.ProductColors.Dtos;

namespace Application.Features.ProductColors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductColor, CreateProductColorCommand>().ReverseMap();
        CreateMap<ProductColor, CreatedProductColorResponse>().ReverseMap();
        CreateMap<ProductColor, UpdateProductColorCommand>().ReverseMap();
        CreateMap<ProductColor, UpdatedProductColorResponse>().ReverseMap();
        CreateMap<ProductColor, DeleteProductColorCommand>().ReverseMap();
        CreateMap<ProductColor, DeletedProductColorResponse>().ReverseMap();

        CreateMap<Product, GetProductsInProductColorDto>().ReverseMap();

        CreateMap<ProductColor, GetByIdProductColorResponse>().ReverseMap().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<ProductColor, GetByNameProductColorResponse>().ReverseMap().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<ProductColor, GetListProductColorListItemDto>().ReverseMap().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<IPaginate<ProductColor>, GetListResponse<GetListProductColorListItemDto>>().ReverseMap();
    }
}