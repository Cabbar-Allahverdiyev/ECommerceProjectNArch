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

namespace Application.Features.ProductInventors.Commands.Update;

public class UpdateProductInventorCommand : IRequest<UpdatedProductInventorResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductInventorsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductInventors";

    public class UpdateProductInventorCommandHandler : IRequestHandler<UpdateProductInventorCommand, UpdatedProductInventorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductInventorRepository _productInventorRepository;
        private readonly ProductInventorBusinessRules _productInventorBusinessRules;

        public UpdateProductInventorCommandHandler(IMapper mapper, IProductInventorRepository productInventorRepository,
                                         ProductInventorBusinessRules productInventorBusinessRules)
        {
            _mapper = mapper;
            _productInventorRepository = productInventorRepository;
            _productInventorBusinessRules = productInventorBusinessRules;
        }

        public async Task<UpdatedProductInventorResponse> Handle(UpdateProductInventorCommand request, CancellationToken cancellationToken)
        {
            ProductInventor? productInventor = await _productInventorRepository.GetAsync(predicate: pi => pi.Id == request.Id, cancellationToken: cancellationToken);
            await _productInventorBusinessRules.ProductInventorShouldExistWhenSelected(productInventor);
            productInventor = _mapper.Map(request, productInventor);

            await _productInventorRepository.UpdateAsync(productInventor!);

            UpdatedProductInventorResponse response = _mapper.Map<UpdatedProductInventorResponse>(productInventor);
            return response;
        }
    }
}