using Application.Features.ProductColors.Constants;
using Application.Features.ProductColors.Rules;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.ProductColors.Constants.ProductColorsOperationClaims;

namespace Application.Features.ProductColors.Queries.GetByNameProductColor;

public class GetByNameProductColorQuery : IRequest<GetByNameProductColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{

    public string[] Roles => new[] { Admin, Read, ProductColorsOperationClaims.GetByNameProductColor };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameProductColor";
    public string CacheGroupKey => "GetProductColors";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameProductColorQueryHandler : IRequestHandler<GetByNameProductColorQuery, GetByNameProductColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ProductColorBusinessRules _productColorBusinessRules;

        public GetByNameProductColorQueryHandler(IMapper mapper, ProductColorBusinessRules productColorBusinessRules)
        {
            _mapper = mapper;
            _productColorBusinessRules = productColorBusinessRules;
        }

        public async Task<GetByNameProductColorResponse> Handle(GetByNameProductColorQuery request, CancellationToken cancellationToken)
        {
            GetByNameProductColorResponse response = _mapper.Map<GetByNameProductColorResponse>(null);
            return response;
        }
    }
}
