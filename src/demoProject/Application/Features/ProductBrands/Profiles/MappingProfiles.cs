using Application.Features.ProductBrands.Commands.Create;
using Application.Features.ProductBrands.Commands.Delete;
using Application.Features.ProductBrands.Commands.Update;
using Application.Features.ProductBrands.Queries.GetById;
using Application.Features.ProductBrands.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

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
        CreateMap<ProductBrand, GetByIdProductBrandResponse>().ReverseMap();
        CreateMap<ProductBrand, GetListProductBrandListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductBrand>, GetListResponse<GetListProductBrandListItemDto>>().ReverseMap();
    }
}