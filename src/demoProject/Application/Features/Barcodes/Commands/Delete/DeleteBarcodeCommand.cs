using Application.Features.Barcodes.Constants;
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

namespace Application.Features.Barcodes.Commands.Delete;

public class DeleteBarcodeCommand : IRequest<DeletedBarcodeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BarcodesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetBarcodes";

    public class DeleteBarcodeCommandHandler : IRequestHandler<DeleteBarcodeCommand, DeletedBarcodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBarcodeRepository _barcodeRepository;
        private readonly BarcodeBusinessRules _barcodeBusinessRules;

        public DeleteBarcodeCommandHandler(IMapper mapper, IBarcodeRepository barcodeRepository,
                                         BarcodeBusinessRules barcodeBusinessRules)
        {
            _mapper = mapper;
            _barcodeRepository = barcodeRepository;
            _barcodeBusinessRules = barcodeBusinessRules;
        }

        public async Task<DeletedBarcodeResponse> Handle(DeleteBarcodeCommand request, CancellationToken cancellationToken)
        {
            Barcode? barcode = await _barcodeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _barcodeBusinessRules.BarcodeShouldExistWhenSelected(barcode);

            await _barcodeRepository.DeleteAsync(barcode!);

            DeletedBarcodeResponse response = _mapper.Map<DeletedBarcodeResponse>(barcode);
            return response;
        }
    }
}