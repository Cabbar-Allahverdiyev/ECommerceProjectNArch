using Application.Features.Sellers.Constants;
using Application.Services.Repositories;
using Application.Services.Shops;
using Application.Services.UsersService;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Sellers.Rules;

public class SellerBusinessRules : BaseBusinessRules
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IUserService _userService;
    private readonly IShopsService _shopsService;

    public SellerBusinessRules(ISellerRepository sellerRepository,
                               IUserService userService,
                               IShopsService shopsService)
    {
        _sellerRepository = sellerRepository;
        _userService = userService;
        _shopsService = shopsService;
    }

    public Task SellerShouldExistWhenSelected(Seller? seller)
    {
        if (seller == null)
            throw new BusinessException(SellersBusinessMessages.SellerNotExists);
        return Task.CompletedTask;
    }

    public Task UserShouldExistWhenSelected(User? user)
    {
        if (user == null)
            throw new BusinessException(SellersBusinessMessages.UserNotExists);
        return Task.CompletedTask;
    }

    public Task ShopShouldExistWhenSelected(Shop? shop)
    {
        if (shop == null)
            throw new BusinessException(SellersBusinessMessages.ShopNotExists);
        return Task.CompletedTask;
    }

    public async Task SellerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Seller? seller = await _sellerRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SellerShouldExistWhenSelected(seller);
    }

    public async Task UserIdShouldExistWhenSelected(int userId, CancellationToken cancellationToken)
    {
        User? user = await _userService.GetAsync(
            predicate: s => s.Id == userId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserShouldExistWhenSelected(user);
    }

    public async Task ShopIdShouldExistWhenSelected(Guid shopId, CancellationToken cancellationToken)
    {
        Shop? shop = await _shopsService.GetAsync(
            predicate: s => s.Id == shopId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShopShouldExistWhenSelected(shop);
    }
}