using Application.Features.Companies.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Companies.Constants.CompaniesOperationClaims;

namespace Application.Features.Companies.Queries.GetList;

public class GetListCompanyQuery : IRequest<GetListResponse<GetListCompanyListItemDto>>//, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCompanies({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCompanies";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyQueryHandler : IRequestHandler<GetListCompanyQuery, GetListResponse<GetListCompanyListItemDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetListCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyListItemDto>> Handle(GetListCompanyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Company> companies = await _companyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken,
                enableTracking:false
            );

            GetListResponse<GetListCompanyListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyListItemDto>>(companies);
            return response;
        }
    }
}