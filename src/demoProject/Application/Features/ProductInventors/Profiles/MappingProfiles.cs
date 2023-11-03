using Application.Features.ProductInventors.Commands.Create;
using Application.Features.ProductInventors.Commands.Delete;
using Application.Features.ProductInventors.Commands.Update;
using Application.Features.ProductInventors.Queries.GetById;
using Application.Features.ProductInventors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductInventors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductInventor, CreateProductInventorCommand>().ReverseMap();
        CreateMap<ProductInventor, CreatedProductInventorResponse>().ReverseMap();
        CreateMap<ProductInventor, UpdateProductInventorCommand>().ReverseMap();
        CreateMap<ProductInventor, UpdatedProductInventorResponse>().ReverseMap();
        CreateMap<ProductInventor, DeleteProductInventorCommand>().ReverseMap();
        CreateMap<ProductInventor, DeletedProductInventorResponse>().ReverseMap();
        CreateMap<ProductInventor, GetByIdProductInventorResponse>().ReverseMap();
        CreateMap<ProductInventor, GetListProductInventorListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductInventor>, GetListResponse<GetListProductInventorListItemDto>>().ReverseMap();
    }
}