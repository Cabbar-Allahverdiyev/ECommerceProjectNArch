using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Companies.Constants.CompaniesOperationClaims;

namespace Application.Features.Companies.Queries.GetByNameCompany;

public class GetByNameCompanyQuery : IRequest<GetByNameCompanyResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? Name { get; set; }

    public string[] Roles => new[] { Admin, Read, CompaniesOperationClaims.GetByNameCompany };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameCompany";
    public string CacheGroupKey => "GetCompanies";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameCompanyQueryHandler : IRequestHandler<GetByNameCompanyQuery, GetByNameCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyBusinessRules _companyBusinessRules;

        public GetByNameCompanyQueryHandler(IMapper mapper,ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules)
        {
            _mapper = mapper;
            _companyRepository = companyRepository; 
            _companyBusinessRules = companyBusinessRules;
        }

        public async Task<GetByNameCompanyResponse> Handle(GetByNameCompanyQuery request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.GetAsync(predicate: c=>string.Equals(c.Name, request.Name, StringComparison.OrdinalIgnoreCase),
                                                                include: c => c.Include(c => c.City),
                                                                cancellationToken: cancellationToken,
                                                                enableTracking: false);
            await _companyBusinessRules.CompanyShouldExistWhenSelected(company);

            GetByNameCompanyResponse response = _mapper.Map<GetByNameCompanyResponse>(company);
            return response;
        }
    }
}
