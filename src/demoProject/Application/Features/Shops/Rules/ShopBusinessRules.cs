using Application.Features.Shops.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Domain.Entities;
using Nest;
using System.Threading;

namespace Application.Features.Shops.Rules;

public class ShopBusinessRules : BaseBusinessRules
{
    private readonly IShopRepository _shopRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;

    public ShopBusinessRules(IShopRepository shopRepository,
                             ICompanyRepository companyRepository,
                             IUserRepository userRepository)
    {
        _shopRepository = shopRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
    }

    public Task ShopShouldExistWhenSelected(Shop? shop)
    {
        if (shop == null)
            throw new BusinessException(ShopsBusinessMessages.ShopNotExists);
        return Task.CompletedTask;
    }

    public Task CompanyShouldExistWhenSelected(Company? company)
    {
        if (company == null)
            throw new BusinessException(ShopsBusinessMessages.CompanyNotExists);
        return Task.CompletedTask;
    }

    public Task UserShouldExistWhenSelected(User? user)
    {
        if (user == null)
            throw new BusinessException(ShopsBusinessMessages.UserNotExists);
        return Task.CompletedTask;
    }


    public async Task ShopIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Shop? shop = await _shopRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShopShouldExistWhenSelected(shop);
    }

    public async Task CompanyIdShouldExistWhenSelected(Guid companyId, CancellationToken cancellationToken)
    {
        Company? company = await _companyRepository.GetAsync(
           predicate: s => s.Id == companyId,
           enableTracking: false,
           cancellationToken: cancellationToken
       );
        await CompanyShouldExistWhenSelected(company);
    }

    public async Task UserIdShouldExistWhenSelected(int userId, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(
           predicate: s => s.Id == userId,
           enableTracking: false,
           cancellationToken: cancellationToken
       );
        await UserShouldExistWhenSelected(user);
    }
}