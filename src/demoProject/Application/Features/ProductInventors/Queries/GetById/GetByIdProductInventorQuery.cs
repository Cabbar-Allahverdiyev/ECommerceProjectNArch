using Application.Features.ProductInventors.Constants;
using Application.Features.ProductInventors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductInventors.Constants.ProductInventorsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductInventors.Queries.GetById;

public class GetByIdProductInventorQuery : IRequest<GetByIdProductInventorResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductInventorQueryHandler : IRequestHandler<GetByIdProductInventorQuery, GetByIdProductInventorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductInventorRepository _productInventorRepository;
        private readonly ProductInventorBusinessRules _productInventorBusinessRules;

        public GetByIdProductInventorQueryHandler(IMapper mapper, IProductInventorRepository productInventorRepository, ProductInventorBusinessRules productInventorBusinessRules)
        {
            _mapper = mapper;
            _productInventorRepository = productInventorRepository;
            _productInventorBusinessRules = productInventorBusinessRules;
        }

        public async Task<GetByIdProductInventorResponse> Handle(GetByIdProductInventorQuery request, CancellationToken cancellationToken)
        {
            ProductInventor? productInventor = await _productInventorRepository.GetAsync(
                predicate: pi => pi.Id == request.Id,
                include: i => i.Include(i => i.Product),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _productInventorBusinessRules.ProductInventorShouldExistWhenSelected(productInventor);

            GetByIdProductInventorResponse response = _mapper.Map<GetByIdProductInventorResponse>(productInventor);
            return response;
        }
    }
}