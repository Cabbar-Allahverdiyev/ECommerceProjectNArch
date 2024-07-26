using Application.Features.Barcodes.Constants;
using Application.Features.Barcodes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Barcodes.Constants.BarcodesOperationClaims;

namespace Application.Features.Barcodes.Queries.GetByBarcodeNumber;

public class GetByBarcodeNumberQuery : IRequest<GetByBarcodeNumberResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? BarcodeNumber { get; set; }
    public string[] Roles => new[] { Admin, Read, BarcodesOperationClaims.GetByBarcodeNumber };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByBarcodeNumber";
    public string CacheGroupKey => "GetBarcodes";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByBarcodeNumberQueryHandler : IRequestHandler<GetByBarcodeNumberQuery, GetByBarcodeNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly BarcodeBusinessRules _barcodeBusinessRules;
        private readonly IBarcodeRepository _barcodeRepository;

        public GetByBarcodeNumberQueryHandler(IMapper mapper,
                                              BarcodeBusinessRules barcodeBusinessRules,
                                              IBarcodeRepository barcodeRepository)
        {
            _mapper = mapper;
            _barcodeBusinessRules = barcodeBusinessRules;
            _barcodeRepository = barcodeRepository;
        }

        public async Task<GetByBarcodeNumberResponse> Handle(GetByBarcodeNumberQuery request, CancellationToken cancellationToken)
        {
            Barcode? barcode = await _barcodeRepository.GetAsync(
               predicate:b => string.Equals(b.BarcodeNumber, request.BarcodeNumber,StringComparison.OrdinalIgnoreCase),
               include: b=>b.Include(b=>b.Product),
               enableTracking: false,
               cancellationToken: cancellationToken);

            await _barcodeBusinessRules.BarcodeShouldExistWhenSelected(barcode);
            GetByBarcodeNumberResponse response = _mapper.Map<GetByBarcodeNumberResponse>(null);
            return response;
        }
    }
}
