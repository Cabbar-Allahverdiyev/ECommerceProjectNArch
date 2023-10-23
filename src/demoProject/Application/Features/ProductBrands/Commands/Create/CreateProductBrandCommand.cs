using Application.Features.ProductBrands.Constants;
using Application.Features.ProductBrands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductBrands.Constants.ProductBrandsOperationClaims;

namespace Application.Features.ProductBrands.Commands.Create;

public class CreateProductBrandCommand : IRequest<CreatedProductBrandResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductBrandsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductBrands";

    public class CreateProductBrandCommandHandler : IRequestHandler<CreateProductBrandCommand, CreatedProductBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly ProductBrandBusinessRules _productBrandBusinessRules;

        public CreateProductBrandCommandHandler(IMapper mapper, IProductBrandRepository productBrandRepository,
                                         ProductBrandBusinessRules productBrandBusinessRules)
        {
            _mapper = mapper;
            _productBrandRepository = productBrandRepository;
            _productBrandBusinessRules = productBrandBusinessRules;
        }

        public async Task<CreatedProductBrandResponse> Handle(CreateProductBrandCommand request, CancellationToken cancellationToken)
        {
            ProductBrand? productBrand = _mapper.Map<ProductBrand>(request);
            await _productBrandBusinessRules.ProductBrandShouldExistWhenSelected(productBrand);
            await _productBrandBusinessRules.ProductBrandNameShouldNotExistWhenSelected(request.Name,cancellationToken);
            productBrand.Id = Guid.NewGuid();

            await _productBrandRepository.AddAsync(productBrand);

            CreatedProductBrandResponse response = _mapper.Map<CreatedProductBrandResponse>(productBrand);
            return response;
        }
    }
}