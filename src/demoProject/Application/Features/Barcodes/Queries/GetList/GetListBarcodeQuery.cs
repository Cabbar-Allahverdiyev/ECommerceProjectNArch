using Application.Features.Barcodes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Barcodes.Constants.BarcodesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Barcodes.Queries.GetList;

public class GetListBarcodeQuery : IRequest<GetListResponse<GetListBarcodeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListBarcodes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetBarcodes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBarcodeQueryHandler : IRequestHandler<GetListBarcodeQuery, GetListResponse<GetListBarcodeListItemDto>>
    {
        private readonly IBarcodeRepository _barcodeRepository;
        private readonly IMapper _mapper;

        public GetListBarcodeQueryHandler(IBarcodeRepository barcodeRepository, IMapper mapper)
        {
            _barcodeRepository = barcodeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBarcodeListItemDto>> Handle(GetListBarcodeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Barcode> barcodes = await _barcodeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: b => b.Include(b => b.Product),
                enableTracking:false,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBarcodeListItemDto> response = _mapper.Map<GetListResponse<GetListBarcodeListItemDto>>(barcodes);
            return response;
        }
    }
}