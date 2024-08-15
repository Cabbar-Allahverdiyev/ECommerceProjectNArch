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

namespace Application.Features.ProductBrands.Commands.Delete;

public class DeleteProductBrandCommand : IRequest<DeletedProductBrandResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductBrandsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductBrands";

    public class DeleteProductBrandCommandHandler : IRequestHandler<DeleteProductBrandCommand, DeletedProductBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly ProductBrandBusinessRules _productBrandBusinessRules;

        public DeleteProductBrandCommandHandler(IMapper mapper, IProductBrandRepository productBrandRepository,
                                         ProductBrandBusinessRules productBrandBusinessRules)
        {
            _mapper = mapper;
            _productBrandRepository = productBrandRepository;
            _productBrandBusinessRules = productBrandBusinessRules;
        }

        public async Task<DeletedProductBrandResponse> Handle(DeleteProductBrandCommand request, CancellationToken cancellationToken)
        {
            ProductBrand? productBrand = await _productBrandRepository.GetAsync(predicate: pb => pb.Id == request.Id, cancellationToken: cancellationToken);
            await _productBrandBusinessRules.ProductBrandShouldExistWhenSelected(productBrand);

            await _productBrandRepository.DeleteAsync(productBrand!);

            DeletedProductBrandResponse response = _mapper.Map<DeletedProductBrandResponse>(productBrand);
            return response;
        }
    }
}