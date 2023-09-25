using Application.Features.Companies.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;
using System.Threading;

namespace Application.Features.Companies.Rules;

public class CompanyBusinessRules : BaseBusinessRules
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyBusinessRules(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public Task CompanyShouldExistWhenSelected(Company? company)
    {
        if (company == null)
            throw new BusinessException(CompaniesBusinessMessages.CompanyNotExists);
        return Task.CompletedTask;
    }
    public Task CompanyShouldNotExistWhenSelected(Company? company)
    {
        if (company != null)
            throw new BusinessException(CompaniesBusinessMessages.CompanyExists);
        return Task.CompletedTask;
    }

    public async Task CompanyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Company? company = await _companyRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyShouldExistWhenSelected(company);
    }

    public async Task CompanyNameShouldNotExistWhenSelected(string? name, CancellationToken cancellationToken)
    {
        Company? company = await _companyRepository.GetAsync(
            predicate: c => string.Equals(c.Name, name,StringComparison.OrdinalIgnoreCase),
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyShouldNotExistWhenSelected(company);
    }

    public async Task CompanyEmailShouldNotExistWhenSelected(string? email, CancellationToken cancellationToken)
    {
        Company? company = await _companyRepository.GetAsync(
             predicate: c => string.Equals(c.Email, email, StringComparison.OrdinalIgnoreCase),
             enableTracking: false,
             cancellationToken: cancellationToken
         );
        await CompanyShouldNotExistWhenSelected(company);
    }

    public  async Task CompanyPhoneNumberShouldNotExistWhenSelected(string? phoneNumber, CancellationToken cancellationToken)
    {
        Company? company = await _companyRepository.GetAsync(
             predicate: c => c.PhoneNumber==phoneNumber,
             enableTracking: false,
             cancellationToken: cancellationToken
         );
        await CompanyShouldNotExistWhenSelected(company);
    }

    public async Task CompanyNameShouldNotExistWhenUptaded(Company? company,string newName, CancellationToken cancellationToken)
    {
        Company? result = await _companyRepository.GetAsync(
            predicate: c => string.Equals(c.Name,newName, StringComparison.OrdinalIgnoreCase)
                         && c.Id!=company.Id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyShouldNotExistWhenSelected(result);
    }

    public async  Task CompanyEmailShouldNotExistWhenUptaded(Company? company,string newEmail, CancellationToken cancellationToken)
    {
        Company? result = await _companyRepository.GetAsync(
            predicate: c => string.Equals(c.Email, newEmail, StringComparison.OrdinalIgnoreCase)
                         && c.Id != company.Id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyShouldNotExistWhenSelected(result);
    }

    public async Task CompanyPhoneNumberShouldNotExistWhenUptaded(Company? company, string newNumber,CancellationToken cancellationToken)
    {
        Company? result = await _companyRepository.GetAsync(
           predicate: c => c.PhoneNumber==newNumber
                        && c.Id != company.Id,
           enableTracking: false,
           cancellationToken: cancellationToken
       );
        await CompanyShouldNotExistWhenSelected(result);
    }
}