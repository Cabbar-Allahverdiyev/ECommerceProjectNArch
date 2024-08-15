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

namespace Application.Features.ProductBrands.Commands.Update;

public class UpdateProductBrandCommand : IRequest<UpdatedProductBrandResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductBrandsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductBrands";

    public class UpdateProductBrandCommandHandler : IRequestHandler<UpdateProductBrandCommand, UpdatedProductBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly ProductBrandBusinessRules _productBrandBusinessRules;

        public UpdateProductBrandCommandHandler(IMapper mapper, IProductBrandRepository productBrandRepository,
                                         ProductBrandBusinessRules productBrandBusinessRules)
        {
            _mapper = mapper;
            _productBrandRepository = productBrandRepository;
            _productBrandBusinessRules = productBrandBusinessRules;
        }

        public async Task<UpdatedProductBrandResponse> Handle(UpdateProductBrandCommand request, CancellationToken cancellationToken)
        {
            ProductBrand? productBrand = await _productBrandRepository.GetAsync(predicate: pb => pb.Id == request.Id, cancellationToken: cancellationToken);
            await _productBrandBusinessRules.ProductBrandShouldExistWhenSelected(productBrand);
            await _productBrandBusinessRules.ProductBrandNameShouldNotExistWhenUpdated(productBrand.Id,request.Name,cancellationToken);
            productBrand = _mapper.Map(request, productBrand);

            await _productBrandRepository.UpdateAsync(productBrand!);

            UpdatedProductBrandResponse response = _mapper.Map<UpdatedProductBrandResponse>(productBrand);
            return response;
        }
    }
}