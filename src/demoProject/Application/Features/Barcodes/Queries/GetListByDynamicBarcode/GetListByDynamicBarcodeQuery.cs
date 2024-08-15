using Application.Features.Barcodes.Constants;
using Application.Features.Barcodes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Barcodes.Constants.BarcodesOperationClaims;

namespace Application.Features.Barcodes.Queries.GetListByDynamicBarcode;

public class GetListByDynamicBarcodeQuery : IRequest<GetListResponse<GetListByDynamicBarcodeItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public GetListByDynamicBarcodeQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicBarcodeQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }
    public string[] Roles => new[] { Admin, Read, BarcodesOperationClaims.GetListByDynamicBarcode };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicBarcode";
    public string CacheGroupKey => "GetBarcodes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByDynamicBarcodeQueryHandler : IRequestHandler<GetListByDynamicBarcodeQuery, GetListResponse<GetListByDynamicBarcodeItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly BarcodeBusinessRules _barcodeBusinessRules;
        public readonly IBarcodeRepository _barcodeRepository;

        public GetListByDynamicBarcodeQueryHandler(IMapper mapper,
                                                   BarcodeBusinessRules barcodeBusinessRules,
                                                   IBarcodeRepository barcodeRepository)
        {
            _mapper = mapper;
            _barcodeBusinessRules = barcodeBusinessRules;
            _barcodeRepository = barcodeRepository;
        }

        public async Task<GetListResponse<GetListByDynamicBarcodeItemDto>> Handle(GetListByDynamicBarcodeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Barcode> barcodes = await _barcodeRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: b => b.Include(b => b.Product),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListByDynamicBarcodeItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicBarcodeItemDto>>(barcodes);
            return response;
        }
    }
}
