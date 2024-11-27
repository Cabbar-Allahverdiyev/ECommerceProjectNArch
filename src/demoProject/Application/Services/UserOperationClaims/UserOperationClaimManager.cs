using Application.Features.Sellers.Constants;
using Application.Features.Shops.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.OperationClaims;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserOperationClaims;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimRepository _userUserOperationClaimRepository;
    private readonly UserOperationClaimBusinessRules _userUserOperationClaimBusinessRules;
    private readonly IOperationClaimService _operationClaimService;

    public UserOperationClaimManager(
        IUserOperationClaimRepository userUserOperationClaimRepository,
        UserOperationClaimBusinessRules userUserOperationClaimBusinessRules
,
        IOperationClaimService operationClaimService)
    {
        _userUserOperationClaimRepository = userUserOperationClaimRepository;
        _userUserOperationClaimBusinessRules = userUserOperationClaimBusinessRules;
        _operationClaimService = operationClaimService;
    }

    public async Task<UserOperationClaim?> GetAsync(
        Expression<Func<UserOperationClaim, bool>> predicate,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserOperationClaim? userUserOperationClaim = await _userUserOperationClaimRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaim;
    }

    public async Task<IPaginate<UserOperationClaim>?> GetListAsync(
        Expression<Func<UserOperationClaim, bool>>? predicate = null,
        Func<IQueryable<UserOperationClaim>, IOrderedQueryable<UserOperationClaim>>? orderBy = null,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserOperationClaim> userUserOperationClaimList = await _userUserOperationClaimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaimList;
    }

    public async Task<UserOperationClaim> AddAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userUserOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim addedUserOperationClaim = await _userUserOperationClaimRepository.AddAsync(userUserOperationClaim);

        return addedUserOperationClaim;
    }

    public async Task<UserOperationClaim> UpdateAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userUserOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenUpdated(
            userUserOperationClaim.Id,
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim updatedUserOperationClaim = await _userUserOperationClaimRepository.UpdateAsync(userUserOperationClaim);

        return updatedUserOperationClaim;
    }

    public async Task<UserOperationClaim> DeleteAsync(UserOperationClaim userUserOperationClaim, bool permanent = false)
    {
        UserOperationClaim deletedUserOperationClaim = await _userUserOperationClaimRepository.DeleteAsync(userUserOperationClaim);
        return deletedUserOperationClaim;
    }

    public async Task<UserOperationClaim> AddShopClaimOnUser(int userId)
    {
        OperationClaim? getClaim = await _operationClaimService.GetAsync(
            predicate:c => c.Name == ShopsOperationClaims.Shop,
            enableTracking:false);
        if (getClaim != null) {return await this.AddAsync(new(userId, getClaim.Id)); }
        else { throw new BusinessException(UserOperationClaimsBusinessMessages.ShopClaimNotExists); }
    }

    public async Task<UserOperationClaim> RemoveShopClaimOnUser(int userId)
    {
        OperationClaim? getClaim = await _operationClaimService.GetAsync(c => c.Name == ShopsOperationClaims.Shop);
        UserOperationClaim? userOperationClaim = await this.GetAsync(
            predicate:o=>o.UserId==userId && o.OperationClaimId==getClaim.Id);
        if (userOperationClaim != null) { return await this.DeleteAsync(userOperationClaim); }
        else { throw new BusinessException(UserOperationClaimsBusinessMessages.UserOperationClaimNotExists); }
        throw new BusinessException(UserOperationClaimsBusinessMessages.ShopClaimNotExists);
    }

    public async Task<UserOperationClaim> AddSellerClaimOnUser(int userId)
    {
        OperationClaim? getClaim = await _operationClaimService.GetAsync(
            predicate:c => c.Name == SellersOperationClaims.Seller,
            enableTracking:false);
        if (getClaim != null) {return await this.AddAsync(new(userId, getClaim.Id)); }
        else { throw new BusinessException(UserOperationClaimsBusinessMessages.SellerClaimNotExists); }
    }
     
    public async Task<UserOperationClaim> RemoveSellerClaimOnUser(int userId)
    {
        OperationClaim? getClaim = await _operationClaimService.GetAsync(c => c.Name == SellersOperationClaims.Seller);
        UserOperationClaim? userOperationClaim = await this.GetAsync(
            predicate: o => o.UserId == userId && o.OperationClaimId == getClaim.Id);
        if (userOperationClaim != null) { return await this.DeleteAsync(userOperationClaim); }
        else { throw new BusinessException(UserOperationClaimsBusinessMessages.UserOperationClaimNotExists); }
        throw new BusinessException(UserOperationClaimsBusinessMessages.SellerClaimNotExists);
    }
}
