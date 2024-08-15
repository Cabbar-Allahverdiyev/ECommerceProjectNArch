using Application.Features.ProductColors.Constants;
using Application.Features.ProductColors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.ProductColors.Constants.ProductColorsOperationClaims;

namespace Application.Features.ProductColors.Queries.GetByName;

public class GetByNameProductColorQuery : IRequest<GetByNameProductColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? Name { get; set; }
    public string[] Roles => new[] { Admin, Read, ProductColorsOperationClaims.GetByNameProductColor };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameProductColor";
    public string CacheGroupKey => "GetProductColors";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameProductColorQueryHandler : IRequestHandler<GetByNameProductColorQuery, GetByNameProductColorResponse>
    {
        private readonly IProductColorRepository _productColorRepository;
        private readonly IMapper _mapper;
        private readonly ProductColorBusinessRules _productColorBusinessRules;

        public GetByNameProductColorQueryHandler(IMapper mapper,
                                                 ProductColorBusinessRules productColorBusinessRules,
                                                 IProductColorRepository productColorRepository)
        {
            _mapper = mapper;
            _productColorBusinessRules = productColorBusinessRules;
            _productColorRepository = productColorRepository;
        }

        public async Task<GetByNameProductColorResponse> Handle(GetByNameProductColorQuery request, CancellationToken cancellationToken)
        {
            ProductColor? color = await _productColorRepository.GetAsync(
                predicate:c=>string.Equals(c.Name,request.Name,StringComparison.OrdinalIgnoreCase),
                include:c=>c.Include(c=>c.Products),
                enableTracking:false,
                cancellationToken:cancellationToken
                );
            GetByNameProductColorResponse response = _mapper.Map<GetByNameProductColorResponse>(color);
            return response;
        }
    }
}
