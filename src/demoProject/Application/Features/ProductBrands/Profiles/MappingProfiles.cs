using Application.Features.ProductBrands.Commands.Create;
using Application.Features.ProductBrands.Commands.Delete;
using Application.Features.ProductBrands.Commands.Update;
using Application.Features.ProductBrands.Queries.GetById;
using Application.Features.ProductBrands.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.ProductBrands.Queries.GetByName;
using Application.Features.ProductBrands.Dtos;

namespace Application.Features.ProductBrands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductBrand, CreateProductBrandCommand>().ReverseMap();
        CreateMap<ProductBrand, CreatedProductBrandResponse>().ReverseMap();
        CreateMap<ProductBrand, UpdateProductBrandCommand>().ReverseMap();
        CreateMap<ProductBrand, UpdatedProductBrandResponse>().ReverseMap();
        CreateMap<ProductBrand, DeleteProductBrandCommand>().ReverseMap();
        CreateMap<ProductBrand, DeletedProductBrandResponse>().ReverseMap();

        CreateMap<Product, GetProductsInBrandDto>().ReverseMap();
        CreateMap<ProductBrand, GetByIdProductBrandResponse>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<ProductBrand, GetByNameProductBrandResponse>().ForMember(dest=>dest.Products,opt=>opt.MapFrom(src=>src.Products)).ReverseMap();
        CreateMap<ProductBrand, GetListProductBrandListItemDto>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<IPaginate<ProductBrand>, GetListResponse<GetListProductBrandListItemDto>>().ReverseMap();

        CreateMap<ProductBrand, GetListProductBrandListItemDto>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<IPaginate<ProductBrand>, GetListResponse<GetListProductBrandListItemDto>>().ReverseMap();
    }
}