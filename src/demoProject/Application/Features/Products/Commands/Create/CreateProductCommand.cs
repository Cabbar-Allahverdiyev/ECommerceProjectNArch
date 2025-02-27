using Application.Features.Products.Constants;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Products.Constants.ProductsOperationClaims;
using Application.Services.ProductInventors;
using Application.Common.Helpers.ProductHelpers;
using Application.Services.Barcodes;
using Application.Services.Shops;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ShopId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Guid SupplierId { get; set; }
    public Guid DiscountId { get; set; }
    public Guid ProductColorId { get; set; }
    public string? BarcodeNumber { get; set; }
    public int Quantity { get; set; }
    public int UnitsOnOrder { get; set; } = 0;
    public int ReorderLevel { get; set; } = 0;
    public decimal PurchasePrice { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Name { get; set; }
    public string? QuantityPerUnit { get; set; }
    public string? Description { get; set; }
    public bool IsDiscontinued { get; set; } = true;

    public string[] Roles => new[] { Admin, Write, ProductsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProducts";

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IProductInventorsService _productInventorsService;
        private readonly IBarcodesService _barcodesService;
        public readonly IShopsService _shopsService;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository,
                                         ProductBusinessRules productBusinessRules,
                                         IProductInventorsService productInventorsService,
                                         IBarcodesService barcodesService, 
                                         IShopsService shopsService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productBusinessRules = productBusinessRules;
            _productInventorsService = productInventorsService;
            _barcodesService = barcodesService;
            _shopsService = shopsService;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            await _productBusinessRules.ProductPurchasePriceShouldBeLessThanUnitPrice(request.PurchasePrice, request.UnitPrice);
            await _productBusinessRules.ProductNameShouldNotHasSupplierAndColorUsedAlreadyWhenInsert(
                request.Name,
                request.SupplierId,
                request.ProductColorId,
                cancellationToken);
            await _productBusinessRules.BarcdeNumberShouldNotExistWhenInserted(request.BarcodeNumber,cancellationToken);

            product.Id = Guid.NewGuid();
            product.ShopId = request.ShopId;
            product.SKU = await product.GenerateSKU();
            await _productRepository.AddAsync(product);
            ProductInventor productInventor = await _productInventorsService.AddAsync(new(productId: product.Id, quantity: request.Quantity));
            Barcode barcode = await _barcodesService.AddAsync(new( product.Id, request.BarcodeNumber), request.SupplierId);
            CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);
            return response;
        }
    }
}