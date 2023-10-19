using Application.Features.Discounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Discounts.Rules;

public class DiscountBusinessRules : BaseBusinessRules
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountBusinessRules(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public Task DiscountShouldExistWhenSelected(Discount? discount)
    {
        if (discount == null)
            throw new BusinessException(DiscountsBusinessMessages.DiscountNotExists);
        return Task.CompletedTask;
    }
    public Task DiscountShouldNotExistWhenSelected(Discount? discount)
    {
        if (discount != null)
            throw new BusinessException(DiscountsBusinessMessages.DiscountNameAlreadyExists);
        return Task.CompletedTask;
    }

    public async Task DiscountIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Discount? discount = await _discountRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DiscountShouldExistWhenSelected(discount);
    }
    public async Task DiscountIdShouldNotExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Discount? discount = await _discountRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DiscountShouldNotExistWhenSelected(discount);
    }

    public async Task DiscountNameShouldNotExistWhenSelected(Discount? discount, CancellationToken cancellationToken)
    {
        if (discount == null)
            throw new BusinessException(DiscountsBusinessMessages.DiscountIsNull);
        Discount? result = await _discountRepository.GetAsync(
        predicate: d => string.Equals(d.Name, discount.Name, StringComparison.OrdinalIgnoreCase),
        enableTracking: false,
        cancellationToken: cancellationToken);

        await DiscountShouldNotExistWhenSelected(result);
    }

    public async Task DiscountNameShouldNotExistWhenUpdated(Discount? discount, string newName, CancellationToken cancellationToken)
    {
        if (discount == null)
            throw new BusinessException(DiscountsBusinessMessages.DiscountIsNull);
        Discount? result = await _discountRepository.GetAsync(
        predicate: d => string.Equals(d.Name, newName, StringComparison.OrdinalIgnoreCase) && d.Id != discount.Id,
        enableTracking: false,
        cancellationToken: cancellationToken);
        await DiscountShouldNotExistWhenSelected(result);
    }

    
}