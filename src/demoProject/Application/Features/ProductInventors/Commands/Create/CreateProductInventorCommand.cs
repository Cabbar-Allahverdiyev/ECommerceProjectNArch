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

namespace Application.Features.ProductInventors.Commands.Create;

public class CreateProductInventorCommand : IRequest<CreatedProductInventorResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Quantity { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductInventorsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductInventors";

    public class CreateProductInventorCommandHandler : IRequestHandler<CreateProductInventorCommand, CreatedProductInventorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductInventorRepository _productInventorRepository;
        private readonly ProductInventorBusinessRules _productInventorBusinessRules;

        public CreateProductInventorCommandHandler(IMapper mapper, IProductInventorRepository productInventorRepository,
                                         ProductInventorBusinessRules productInventorBusinessRules)
        {
            _mapper = mapper;
            _productInventorRepository = productInventorRepository;
            _productInventorBusinessRules = productInventorBusinessRules;
        }

        public async Task<CreatedProductInventorResponse> Handle(CreateProductInventorCommand request, CancellationToken cancellationToken)
        {
            ProductInventor productInventor = _mapper.Map<ProductInventor>(request);
            productInventor.Id=Guid.NewGuid();

            await _productInventorRepository.AddAsync(productInventor);

            CreatedProductInventorResponse response = _mapper.Map<CreatedProductInventorResponse>(productInventor);
            return response;
        }
    }
}