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

    public async Task DiscountIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Discount? discount = await _discountRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DiscountShouldExistWhenSelected(discount);
    }
}