using Application.Features.ProductInventors.Constants;
using Application.Features.ProductInventors.Constants;
using Application.Features.ProductInventors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductInventors.Constants.ProductInventorsOperationClaims;

namespace Application.Features.ProductInventors.Commands.Delete;

public class DeleteProductInventorCommand : IRequest<DeletedProductInventorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductInventorsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductInventors";

    public class DeleteProductInventorCommandHandler : IRequestHandler<DeleteProductInventorCommand, DeletedProductInventorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductInventorRepository _productInventorRepository;
        private readonly ProductInventorBusinessRules _productInventorBusinessRules;

        public DeleteProductInventorCommandHandler(IMapper mapper, IProductInventorRepository productInventorRepository,
                                         ProductInventorBusinessRules productInventorBusinessRules)
        {
            _mapper = mapper;
            _productInventorRepository = productInventorRepository;
            _productInventorBusinessRules = productInventorBusinessRules;
        }

        public async Task<DeletedProductInventorResponse> Handle(DeleteProductInventorCommand request, CancellationToken cancellationToken)
        {
            ProductInventor? productInventor = await _productInventorRepository.GetAsync(predicate: pi => pi.Id == request.Id, cancellationToken: cancellationToken);
            await _productInventorBusinessRules.ProductInventorShouldExistWhenSelected(productInventor);

            await _productInventorRepository.DeleteAsync(productInventor!);

            DeletedProductInventorResponse response = _mapper.Map<DeletedProductInventorResponse>(productInventor);
            return response;
        }
    }
}