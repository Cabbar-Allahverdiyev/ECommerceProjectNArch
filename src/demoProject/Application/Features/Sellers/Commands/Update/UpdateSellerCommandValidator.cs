using FluentValidation;

namespace Application.Features.Sellers.Commands.Update;

public class UpdateSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
{
    public UpdateSellerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
    }
}