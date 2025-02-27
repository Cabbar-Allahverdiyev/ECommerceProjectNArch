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
using Application.Features.Products.Queries.GetListByDynamicProduct;

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

        CreateMap<ProductInventor, GetInventorInProductQueryDto>().ReverseMap();
        CreateMap<Discount, GetDiscountInProductQueryDto>().ReverseMap();
        CreateMap<Supplier, GetSupplierInProductQueryDto>().ReverseMap();
        CreateMap<ProductBrand, GetBrandInProductQueryDto>().ReverseMap();
        CreateMap<ProductCategory, GetCategoryInProductQueryDto>().ReverseMap();
        CreateMap<Barcode, GetBarcodeInProductQueryDto>().ReverseMap();
        CreateMap<ProductColor, GetColorInProductQueryDto>().ReverseMap();

        CreateMap<Product, GetByIdProductResponse>().ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Brand,act=>act.MapFrom(src=>src.Brand)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Category,act=>act.MapFrom(src=>src.Category)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Discount,act=>act.MapFrom(src=>src.Discount)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Inventor,act=>act.MapFrom(src=>src.Inventor)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Supplier,act=>act.MapFrom(src=>src.Supplier)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Barcode,act=>act.MapFrom(src=>src.Barcode)).ReverseMap();
        CreateMap<Product, GetByIdProductResponse>().ForMember(dest=>dest.Color,act=>act.MapFrom(src=>src.ProductColor)).ReverseMap();

        CreateMap<Product, GetByNameProductResponse>().ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Brand, act => act.MapFrom(src => src.Brand)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Inventor, act => act.MapFrom(src => src.Inventor)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.Supplier)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Barcode, act => act.MapFrom(src => src.Barcode)).ReverseMap();
        CreateMap<Product, GetByNameProductResponse>().ForMember(dest => dest.Color, act => act.MapFrom(src => src.ProductColor)).ReverseMap();

        CreateMap<Product, GetListProductListItemDto>().ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Brand, act => act.MapFrom(src => src.Brand)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Inventor, act => act.MapFrom(src => src.Inventor)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.Supplier)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Barcode, act => act.MapFrom(src => src.Barcode)).ReverseMap();
        CreateMap<Product, GetListProductListItemDto>().ForMember(dest => dest.Color, act => act.MapFrom(src => src.ProductColor)).ReverseMap();
        CreateMap<IPaginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();

        CreateMap<Product, GetListByDynamicProductItemDto>().ReverseMap();
        CreateMap<Product, GetListByDynamicProductItemDto>().ForMember(dest => dest.Brand, act => act.MapFrom(src => src.Brand)).ReverseMap();
        CreateMap<Product, GetListByDynamicProductItemDto>().ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category)).ReverseMap();
        CreateMap<Product, GetListByDynamicProductItemDto>().ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount)).ReverseMap();
        CreateMap<Product, GetListByDynamicProductItemDto>().ForMember(dest => dest.Inventor, act => act.MapFrom(src => src.Inventor)).ReverseMap();
        CreateMap<Product, GetListByDynamicProductItemDto>().ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.Supplier)).ReverseMap();
        CreateMap<Product, GetListByDynamicProductItemDto>().ForMember(dest => dest.Barcode, act => act.MapFrom(src => src.Barcode)).ReverseMap();
        CreateMap<Product, GetListByDynamicProductItemDto>().ForMember(dest => dest.Color, act => act.MapFrom(src => src.ProductColor)).ReverseMap();
        CreateMap<IPaginate<Product>, GetListResponse<GetListByDynamicProductItemDto>>().ReverseMap();
    }
}