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

namespace Application.Features.Barcodes.Commands.Update;

public class UpdateBarcodeCommand : IRequest<UpdatedBarcodeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? BarcodeNumber { get; set; }
    public Product? Product { get; set; }

    public string[] Roles => new[] { Admin, Write, BarcodesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetBarcodes";

    public class UpdateBarcodeCommandHandler : IRequestHandler<UpdateBarcodeCommand, UpdatedBarcodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBarcodeRepository _barcodeRepository;
        private readonly BarcodeBusinessRules _barcodeBusinessRules;

        public UpdateBarcodeCommandHandler(IMapper mapper, IBarcodeRepository barcodeRepository,
                                         BarcodeBusinessRules barcodeBusinessRules)
        {
            _mapper = mapper;
            _barcodeRepository = barcodeRepository;
            _barcodeBusinessRules = barcodeBusinessRules;
        }

        public async Task<UpdatedBarcodeResponse> Handle(UpdateBarcodeCommand request, CancellationToken cancellationToken)
        {
            Barcode? barcode = await _barcodeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _barcodeBusinessRules.BarcodeShouldExistWhenSelected(barcode);
            barcode = _mapper.Map(request, barcode);

            await _barcodeRepository.UpdateAsync(barcode!);

            UpdatedBarcodeResponse response = _mapper.Map<UpdatedBarcodeResponse>(barcode);
            return response;
        }
    }
}