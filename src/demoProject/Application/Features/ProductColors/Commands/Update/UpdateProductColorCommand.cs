using Application.Features.ProductColors.Constants;
using Application.Features.ProductColors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductColors.Constants.ProductColorsOperationClaims;

namespace Application.Features.ProductColors.Commands.Update;

public class UpdateProductColorCommand : IRequest<UpdatedProductColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductColorsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductColors";

    public class UpdateProductColorCommandHandler : IRequestHandler<UpdateProductColorCommand, UpdatedProductColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductColorRepository _productColorRepository;
        private readonly ProductColorBusinessRules _productColorBusinessRules;

        public UpdateProductColorCommandHandler(IMapper mapper, IProductColorRepository productColorRepository,
                                         ProductColorBusinessRules productColorBusinessRules)
        {
            _mapper = mapper;
            _productColorRepository = productColorRepository;
            _productColorBusinessRules = productColorBusinessRules;
        }

        public async Task<UpdatedProductColorResponse> Handle(UpdateProductColorCommand request, CancellationToken cancellationToken)
        {
            ProductColor? productColor = await _productColorRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _productColorBusinessRules.ProductColorShouldExistWhenSelected(productColor);
            productColor = _mapper.Map(request, productColor);

            await _productColorRepository.UpdateAsync(productColor!);

            UpdatedProductColorResponse response = _mapper.Map<UpdatedProductColorResponse>(productColor);
            return response;
        }
    }
}