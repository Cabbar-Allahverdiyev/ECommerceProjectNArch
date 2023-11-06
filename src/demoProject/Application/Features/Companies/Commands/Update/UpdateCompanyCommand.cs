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

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyCommand : IRequest<UpdatedCompanyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, CompaniesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCompanies";

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdatedCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyBusinessRules _companyBusinessRules;

        public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository,
                                         CompanyBusinessRules companyBusinessRules)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _companyBusinessRules = companyBusinessRules;
        }

        public async Task<UpdatedCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _companyBusinessRules.CompanyShouldExistWhenSelected(company);
            await _companyBusinessRules.CompanyNameShouldNotExistWhenUptaded(company,request.Name, cancellationToken);
            await _companyBusinessRules.CompanyEmailShouldNotExistWhenUptaded(company,request.Email, cancellationToken);
            await _companyBusinessRules.CompanyPhoneNumberShouldNotExistWhenUptaded(company,request.PhoneNumber, cancellationToken);

            company = _mapper.Map(request, company);

            await _companyRepository.UpdateAsync(company!);

            UpdatedCompanyResponse response = _mapper.Map<UpdatedCompanyResponse>(company);
            return response;
        }
    }
}