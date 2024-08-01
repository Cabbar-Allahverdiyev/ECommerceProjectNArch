using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
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
using static Application.Features.Companies.Constants.CompaniesOperationClaims;

namespace Application.Features.Companies.Queries.GetListByDynamicCompany;

public class GetListByDynamicCompanyQuery : IRequest<GetListResponse<GetListByDynamicCompanyItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest  PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public string[] Roles => new[] { Admin, Read, CompaniesOperationClaims.GetListByDynamicCompany };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicCompany";
    public string CacheGroupKey => "GetCompanies";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicCompanyQueryHandler : IRequestHandler<GetListByDynamicCompanyQuery, GetListResponse<GetListByDynamicCompanyItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly CompanyBusinessRules _companyBusinessRules;
        private readonly ICompanyRepository _companyRepository;

        public GetListByDynamicCompanyQueryHandler(IMapper mapper,
                                                   CompanyBusinessRules companyBusinessRules,
                                                   ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyBusinessRules = companyBusinessRules;
            _companyRepository = companyRepository;
        }

        public async Task<GetListResponse<GetListByDynamicCompanyItemDto>> Handle(GetListByDynamicCompanyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Company> companies = await _companyRepository.GetListByDynamicAsync(
                dynamic:request.DynamicQuery,
                 index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.City).Include(c => c.Suppliers),
                cancellationToken: cancellationToken
                );

            GetListResponse<GetListByDynamicCompanyItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicCompanyItemDto>>(companies);
            return response;
        }
    }
}
