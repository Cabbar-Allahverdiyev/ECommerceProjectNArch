using Application.Features.Barcodes.Constants;
using Application.Features.Barcodes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Barcodes.Constants.BarcodesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Barcodes.Queries.GetById;

public class GetByIdBarcodeQuery : IRequest<GetByIdBarcodeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBarcodeQueryHandler : IRequestHandler<GetByIdBarcodeQuery, GetByIdBarcodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBarcodeRepository _barcodeRepository;
        private readonly BarcodeBusinessRules _barcodeBusinessRules;

        public GetByIdBarcodeQueryHandler(IMapper mapper, IBarcodeRepository barcodeRepository, BarcodeBusinessRules barcodeBusinessRules)
        {
            _mapper = mapper;
            _barcodeRepository = barcodeRepository;
            _barcodeBusinessRules = barcodeBusinessRules;
        }

        public async Task<GetByIdBarcodeResponse> Handle(GetByIdBarcodeQuery request, CancellationToken cancellationToken)
        {
            Barcode? barcode = await _barcodeRepository.GetAsync(predicate: b => b.Id == request.Id,
                include: b => b.Include(b => b.Product),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _barcodeBusinessRules.BarcodeShouldExistWhenSelected(barcode);

            GetByIdBarcodeResponse response = _mapper.Map<GetByIdBarcodeResponse>(barcode);
            return response;
        }
    }
}