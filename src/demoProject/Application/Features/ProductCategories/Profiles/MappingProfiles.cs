using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Commands.Delete;
using Application.Features.ProductCategories.Commands.Update;
using Application.Features.ProductCategories.Queries.GetById;
using Application.Features.ProductCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.ProductCategories.Queries.GetByName;
using Application.Features.ProductCategories.Dtos;

namespace Application.Features.ProductCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductCategory, CreateProductCategoryCommand>().ReverseMap();
        CreateMap<ProductCategory, CreatedProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, UpdateProductCategoryCommand>().ReverseMap();
        CreateMap<ProductCategory, UpdatedProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, DeleteProductCategoryCommand>().ReverseMap();
        CreateMap<ProductCategory, DeletedProductCategoryResponse>().ReverseMap();

        CreateMap<ProductCategory, GetParentCategoryInProductCategoryDto>().ReverseMap();  
        CreateMap<Product, GetProductsInProductCategoryDto>().ReverseMap();  

        CreateMap<ProductCategory, GetByIdProductCategoryResponse>()
            .ForMember(dest=>dest.Parent,act=>act.MapFrom(src=>src.Parent))
            .ForMember(dest=>dest.Products,act=>act.MapFrom(src=>src.Products))
            .ReverseMap();
        CreateMap<ProductCategory, GetByNameProductCategoryResponse>()
            .ForMember(dest => dest.Parent, act => act.MapFrom(src => src.Parent))
            .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products))
            .ReverseMap();
        CreateMap<ProductCategory, GetListProductCategoryListItemDto>()
            .ForMember(dest => dest.Parent, act => act.MapFrom(src => src.Parent))
            .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Products))
            .ReverseMap();
        CreateMap<IPaginate<ProductCategory>, GetListResponse<GetListProductCategoryListItemDto>>().ReverseMap();
    }
}