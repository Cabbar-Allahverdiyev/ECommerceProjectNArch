using Application.Features.Barcodes.Constants;
using Application.Features.Barcodes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Barcodes.Constants.BarcodesOperationClaims;

namespace Application.Features.Barcodes.Commands.Create;

public class CreateBarcodeCommand : IRequest<CreatedBarcodeResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ProductId { get; set; }
    public string? BarcodeNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, BarcodesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetBarcodes";

    public class CreateBarcodeCommandHandler : IRequestHandler<CreateBarcodeCommand, CreatedBarcodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBarcodeRepository _barcodeRepository;
        private readonly BarcodeBusinessRules _barcodeBusinessRules;

        public CreateBarcodeCommandHandler(IMapper mapper, IBarcodeRepository barcodeRepository,
                                         BarcodeBusinessRules barcodeBusinessRules)
        {
            _mapper = mapper;
            _barcodeRepository = barcodeRepository;
            _barcodeBusinessRules = barcodeBusinessRules;
        }

        public async Task<CreatedBarcodeResponse> Handle(CreateBarcodeCommand request, CancellationToken cancellationToken)
        {
            Barcode barcode = _mapper.Map<Barcode>(request);
            barcode.Id=Guid.NewGuid();
            await _barcodeRepository.AddAsync(barcode);

            CreatedBarcodeResponse response = _mapper.Map<CreatedBarcodeResponse>(barcode);
            return response;
        }
    }
}