using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Companies.Constants.CompaniesOperationClaims;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyCommand : IRequest<CreatedCompanyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public int CityId { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, CompaniesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCompanies";

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreatedCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyBusinessRules _companyBusinessRules;

        public CreateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository,
                                         CompanyBusinessRules companyBusinessRules)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _companyBusinessRules = companyBusinessRules;
        }

        public async Task<CreatedCompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            await _companyBusinessRules.CompanyNameShouldNotExistWhenSelected(request.Name,cancellationToken);
            await _companyBusinessRules.CompanyEmailShouldNotExistWhenSelected(request.Email, cancellationToken);
            await _companyBusinessRules.CompanyPhoneNumberShouldNotExistWhenSelected(request.PhoneNumber, cancellationToken);

            Company company = _mapper.Map<Company>(request);
            await _companyBusinessRules.CompanyShouldExistWhenSelected(company);

            await _companyRepository.AddAsync(company);

            CreatedCompanyResponse response = _mapper.Map<CreatedCompanyResponse>(company);
            return response;
        }
    }
}