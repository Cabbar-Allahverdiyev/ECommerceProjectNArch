using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Products.Queries.GetByName;
using Application.Features.Products.Dtos;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreatedProductResponse>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, UpdatedProductResponse>().ReverseMap();
        CreateMap<Product, DeleteProductCommand>().ReverseMap();
        CreateMap<Product, DeletedProductResponse>().ReverseMap();

        CreateMap<Product, GetInventorInProductQueryDto>().ReverseMap();
        CreateMap<Product, GetDiscountInProductQueryDto>().ReverseMap();
        CreateMap<Product, GetSupplierInProductQueryDto>().ReverseMap();
        CreateMap<Product, GetBrandInProductQueryDto>().ReverseMap();
        CreateMap<Product, GetCategoryInProductQueryDto>().ReverseMap();

        CreateMap<Product, GetByIdProductResponse>().ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Brand,act=>act.MapFrom(src=>src.Brand)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Category,act=>act.MapFrom(src=>src.Category)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Discount,act=>act.MapFrom(src=>src.Discount)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Inventor,act=>act.MapFrom(src=>src.ProductInventor)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Supplier,act=>act.MapFrom(src=>src.Supplier)).ReverseMap();

        CreateMap<Product, GetByNameProductResponse>().ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Brand, act => act.MapFrom(src => src.Brand)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Inventor, act => act.MapFrom(src => src.ProductInventor)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.Supplier)).ReverseMap();

        CreateMap<Product, GetListProductListItemDto>().ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Brand, act => act.MapFrom(src => src.Brand)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Inventor, act => act.MapFrom(src => src.ProductInventor)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.Supplier)).ReverseMap();
        CreateMap<IPaginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();
    }
}