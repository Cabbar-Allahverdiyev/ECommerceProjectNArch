using Application.Features.ProductBrands.Constants;
using Application.Features.ProductBrands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductBrands.Constants.ProductBrandsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductBrands.Queries.GetById;

public class GetByIdProductBrandQuery : IRequest<GetByIdProductBrandResponse>//, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductBrandQueryHandler : IRequestHandler<GetByIdProductBrandQuery, GetByIdProductBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly ProductBrandBusinessRules _productBrandBusinessRules;

        public GetByIdProductBrandQueryHandler(IMapper mapper, IProductBrandRepository productBrandRepository, ProductBrandBusinessRules productBrandBusinessRules)
        {
            _mapper = mapper;
            _productBrandRepository = productBrandRepository;
            _productBrandBusinessRules = productBrandBusinessRules;
        }

        public async Task<GetByIdProductBrandResponse> Handle(GetByIdProductBrandQuery request, CancellationToken cancellationToken)
        {
            ProductBrand? productBrand = await _productBrandRepository.GetAsync(predicate: pb => pb.Id == request.Id,
                                                                                cancellationToken: cancellationToken,
                                                                                enableTracking:false,
                                                                                include:pb=>pb.Include(pb=>pb.Products));
            await _productBrandBusinessRules.ProductBrandShouldExistWhenSelected(productBrand);

            GetByIdProductBrandResponse response = _mapper.Map<GetByIdProductBrandResponse>(productBrand);
            return response;
        }
    }
}